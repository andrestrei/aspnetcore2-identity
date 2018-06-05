using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppString.Areas.Identity.Models
{
    public class UserRolesCreateEditViewModel
    {
        public IdentityUserRole<string> IdentityUserRole { get; set; }
        public SelectList UserSelectList { get; set; }
        public SelectList RoleSelectList { get; set; }
    }
}
