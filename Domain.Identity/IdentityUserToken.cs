using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Identity
{
    public class IdentityUserToken : IdentityUserToken<int>
    {
        
    }

    public class IdentityUserTokenStr : IdentityUserToken<string>
    {
        public IdentityUserTokenStr()
        {
            IdentityUserTokenId = Guid.NewGuid().ToString();
        }
    }

    /// <summary>
    /// Represents an authentication token for a user.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key used for users.</typeparam>
    public class IdentityUserToken<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey IdentityUserTokenId { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the user that the token belongs to.
        /// </summary>
        public virtual TKey IdentityUserId { get; set; }
        public virtual IdentityUser<TKey> IdentityUser { get; set; }

        /// <summary>
        /// Gets or sets the LoginProvider this token is from.
        /// </summary>
        public virtual string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the name of the token.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the token value.
        /// </summary>
        public virtual string Value { get; set; }
    }
}
