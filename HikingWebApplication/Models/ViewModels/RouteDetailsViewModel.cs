using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingWebApplication.Models.ViewModels
{
    public class RouteDetailsViewModel
    {
        public RouteModel SelectedRoute { get; set; }
        public List<RouteModel> AllRoutes { get; set; }
    }
}
