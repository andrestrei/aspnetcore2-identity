using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Identity
{
    public class IdentityUserLogin : IdentityUserLogin<int>
    {
        
    }

    public class IdentityUserLoginStr : IdentityUserLogin<string>
    {
        public IdentityUserLoginStr()
        {
            IdentityUserLoginId = Guid.NewGuid().ToString();
        }
    }
    /// <summary>
    /// Represents a login and its associated provider for a user.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key of the user associated with this login.</typeparam>
    public class IdentityUserLogin<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey IdentityUserLoginId { get; set; }
        /// <summary>
        /// Gets or sets the login provider for the login (e.g. facebook, google)
        /// </summary>
        public virtual string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the unique provider identifier for this login.
        /// </summary>
        public virtual string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the friendly name used in a UI for this login.
        /// </summary>
        public virtual string ProviderDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the of the primary key of the user associated with this login.
        /// </summary>
        public virtual TKey IdentityUserId { get; set; }
        public virtual IdentityUser<TKey> IdentityUser { get; set; }

    }
}
