using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Identity
{
    // domain class for role
    public class IdentityRole : IdentityRole<int>
    {
        public IdentityRole() { }

        public IdentityRole(string roleName)
        {
            Name = roleName;
        }
    }

    public class IdentityRoleStr : IdentityRole<string>
    {
        public IdentityRoleStr()
        {
            IdentityRoleId = Guid.NewGuid().ToString();
        }
    }

    public class IdentityRole<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole{TKey}"/>.
        /// </summary>
        public IdentityRole() { }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole{TKey}"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }

        /// <summary>
        /// Gets or sets the primary key for this role.
        /// </summary>
        [Key]
        public virtual TKey IdentityRoleId { get; set; }

        /// <summary>
        /// Gets or sets the name for this role.
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the normalized name for this role.
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string NormalizedName { get; set; }

        /// <summary>
        /// A random value that should change whenever a role is persisted to the store
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();



        public virtual List<IdentityUserRole<TKey>> Users { get; set; } = new List<IdentityUserRole<TKey>>();
        public virtual List<IdentityRoleClaim<TKey>> IdentityRoleClaims { get; set; } = new List<IdentityRoleClaim<TKey>>();


        /// <summary>
        /// Returns the name of the role.
        /// </summary>
        /// <returns>The name of the role.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
