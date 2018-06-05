using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Identity
{
    public class IdentityUserRole : IdentityUserRole<int>
    {
        
    }

    public class IdentityUserRoleStr : IdentityUserRole<string>
    {
        public IdentityUserRoleStr()
        {
            IdentityUserRoleId = Guid.NewGuid().ToString();
        }
    }
    /// <summary>
    /// Represents the link between a user and a role.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key used for users and roles.</typeparam>
    public class IdentityUserRole<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey IdentityUserRoleId { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the user that is linked to a role.
        /// </summary>
        public virtual TKey IdentityUserId { get; set; }

        public virtual IdentityUser<TKey> IdentityUser { get; set; } 

        /// <summary>
        /// Gets or sets the primary key of the role that is linked to the user.
        /// </summary>
        public virtual TKey IdentityRoleId { get; set; }

        public virtual IdentityRole<TKey> IdentityRole { get; set; }
    }
}
