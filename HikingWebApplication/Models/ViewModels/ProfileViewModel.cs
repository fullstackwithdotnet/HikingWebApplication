using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingWebApplication.Models.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public List<RouteModel> Routes { get; set; }
        public string Interests { get; set; }
  
    }
}
