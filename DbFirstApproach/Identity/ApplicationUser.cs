using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DbFirstApproach.Identity
{
    public class ApplicationUser : IdentityUser
    {
        
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}