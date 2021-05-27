using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingWebApplication.Models
{
    public class SearchObject
    {
        public string location { get; set; }
        public string people { get; set; }
        public int difficulty { get; set; }
        public int estimate { get; set; }
        public int budget { get; set; }
        public int elevation { get; set; }
        public bool needExpert { get; set; }
                
    }
}
