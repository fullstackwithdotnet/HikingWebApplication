using HikingWebApplication.Data;
using HikingWebApplication.Models;
using HikingWebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HikingWebApplication.Controllers
{
    public class RouteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public RouteController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddRoute()
        {
            var routeModel = new RouteViewModel();
            routeModel.CreatedBy = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(routeModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRouteAsync(RouteViewModel routeViewModel)
        {
            try
            {


                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "RoutePhotos");
                var fileName = "";

                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }

                if (routeViewModel.Photo != null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(routeViewModel.Photo.FileName);
                    var filePath = Path.Combine(imagePath, fileName);


                    await using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await routeViewModel.Photo.CopyToAsync(fileStream);
                    }

                }

                var model = new RouteModel()
                {
                    Title = routeViewModel.Title,
                    Place = routeViewModel.Place,
                    Latitude = routeViewModel.Latitude,
                    Longitude = routeViewModel.Longitude,
                    Elevation = routeViewModel.Elevation,
                    Distance = routeViewModel.Distance,
                    DificultyLevel = routeViewModel.DificultyLevel,
                    EstimateTime = routeViewModel.EstimateTime,
                    PhotoPath = fileName,
                    Description = routeViewModel.Description,
                    SelectedRate = routeViewModel.SelectedRate,
                    Budget = routeViewModel.Budget,
                    NeedExpert = routeViewModel.NeedExpert,
                    CreatedBy = await _userManager.FindByNameAsync(User.Identity.Name)
                };

                await _context.Routes.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("EditProfile", "Home");
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        public async Task<IActionResult> RouteDetails(int id)
        {
            var routes = await _context.Routes.Include(r => r.CreatedBy).Where(r => !r.IsDeleted).ToListAsync();
            var model = new RouteDetailsViewModel()
            {
                AllRoutes = routes,
                SelectedRoute = routes.FirstOrDefault(r => r.Id == id)
            };
            return View(model);
        }
    }
}
