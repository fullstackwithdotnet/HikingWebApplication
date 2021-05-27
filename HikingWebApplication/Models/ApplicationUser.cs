using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingWebApplication.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Interests { get; set; }
    }
}
