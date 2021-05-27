using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HikingWebApplication.Models
{
    public class Enums
    {
        public enum DificultyLevel
        {
            Easy = 1,
            Difficult = 2,
            Hard = 3,
        }

        public enum EstimateTime
        {
            [Display(Name = "0-1 Hours")]
            hours01 = 1,
            [Display(Name = "1-2 Hours")]
            hours12 = 2,
            [Display(Name = "2+ Hours")]
            hours2 = 3,
        }

        public enum Budget
        {
            [Display(Name = "Less than 5000")]
            LessThan5000 = 1,
            [Display(Name = "Less than 3000")]
            LessThan3000 = 2,
            [Display(Name = "Less than 1000")]
            LessThan1000 = 3,
        }

        public enum Evevation
        {
            [Display(Name = "Less than 1000")]
            LessThan1000 = 1,
            [Display(Name = "Less than 2000")]
            LessThan2000 = 2,
            [Display(Name = "Less than 3000")]
            LessThan3000 = 3,
            [Display(Name = "More than 3000")]
            MoreThan3000 = 4,
        }

        // Helper method to display the name of the enum values.
        public static string GetDisplayName(Enum value)
        {
            return value.GetType()?
           .GetMember(value.ToString())?.First()?
           .GetCustomAttribute<DisplayAttribute>()?
           .Name;
        }
    }
}
