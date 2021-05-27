using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HikingWebApplication.Models.ViewModels
{
    public class RouteViewModel
    {

        public string Title { get; set; }
        public string Place { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Elevation { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Distance { get; set; }
        public Enums.Budget Budget { get; set; }
        public Enums.DificultyLevel DificultyLevel { get; set; }
        public Enums.EstimateTime EstimateTime { get; set; }
        public IFormFile Photo { get; set; }
        public string Description { get; set; }
        public int SelectedRate { get; set; }
        public bool NeedExpert { get; set; }

        public int[] Ratings = new[] { 5, 4, 3, 2, 1 };
        public ApplicationUser CreatedBy { get; set; }
    }
}
