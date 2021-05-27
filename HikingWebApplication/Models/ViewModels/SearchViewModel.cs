using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingWebApplication.Models.ViewModels
{
    public class SearchViewModel
    {
        public string Location { get; set; }
        public string People { get; set; }
        public Enums.DificultyLevel DificultyLevel { get; set; }
        public Enums.EstimateTime EstimateTime { get; set; }
        public Enums.Budget Budget { get; set; }
        public Enums.Evevation Evevation { get; set; }
        public bool IncludeExpert { get; set; }
        //public ApplicationUser User { get; set; }
    }
}
