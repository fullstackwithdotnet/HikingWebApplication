using HikingWebApplication.Data;
using HikingWebApplication.Models;
using HikingWebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HikingWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoadRoutesPartial(SearchObject searchData)
        {
            var routes = await _context.Routes.Include(r => r.CreatedBy)
                .Where(r => !r.IsDeleted)
                .ToListAsync();
            if (!string.IsNullOrEmpty(searchData.location))
            {
                routes = routes.FindAll(r => r.Title.ToLower().Contains(searchData.location.ToLower()) || r.Place.ToLower().Contains(searchData.location.ToLower()));
            }
            if (!string.IsNullOrEmpty(searchData.people))
            {
                routes = routes.FindAll(r => r.CreatedBy.FullName.ToLower().Contains(searchData.people.ToLower()));
            }
            if (searchData.difficulty != 0)
            {
                routes = routes.FindAll(r => (int)r.DificultyLevel == searchData.difficulty);
            }
            if (searchData.estimate != 0)
            {
                routes = routes.FindAll(r => (int)r.EstimateTime == searchData.estimate);
            }
            if (searchData.budget != 0)
            {
                routes = routes.FindAll(r => (int)r.Budget == searchData.budget);
            }
            if (searchData.elevation != 0)
            {
                routes = routes.FindAll(r => (int)r.Elevation == searchData.elevation);
            }
            if (searchData.needExpert)
            {
                routes = routes.FindAll(r => r.NeedExpert);
            }

            return PartialView("_RoutesPartial", routes);
        }

        [HttpGet]
        public async Task<JsonResult> GetLocationsAsync()
        {
            var routes = await _context.Routes.Include(r => r.CreatedBy).Where(r => !r.IsDeleted).ToListAsync();
            var locations = new List<GoogleLocationModel>();
            foreach (var item in routes)
            {
                var loc = new GoogleLocationModel()
                {
                    Lat = item.Latitude,
                    Lng = item.Longitude
                };

                locations.Add(loc);
            }
            return new JsonResult(locations);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var routes = await _context.Routes.Include(r => r.CreatedBy).Where(r => !r.IsDeleted && r.CreatedBy == user).ToListAsync();
            var model = new ProfileViewModel()
            {
                User = user,
                Routes = routes,
                Interests = user.Interests
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfileAsync(ProfileViewModel viewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.FullName = viewModel.User.FullName;
            user.PhoneNumber = viewModel.User.PhoneNumber;
            user.Interests = viewModel.Interests;

            await _context.SaveChangesAsync();

            return RedirectToAction("EditProfile");
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
