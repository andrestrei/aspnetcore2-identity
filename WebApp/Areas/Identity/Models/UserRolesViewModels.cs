using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Identity.Models
{
    public class UserRole
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IdentityRole IdentityRole { get; set; }
    }

    public class UserRolesIndexViewModel
    {
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
    public class UserRolesCreateEditViewModel
    {
        public IdentityUserRole<int> IdentityUserRole { get; set; }
        public SelectList UserSelectList { get; set; }
        public SelectList RoleSelectList { get; set; }
    }
}
