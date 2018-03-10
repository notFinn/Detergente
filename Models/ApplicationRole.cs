using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Models
{
    public class ApplicationRole : IdentityRole
    {
        public Boolean Enable { get; set; }
    }
}
