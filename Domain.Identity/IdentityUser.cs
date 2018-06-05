using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Identity
{

    // based on https://github.com/aspnet/Identity/blob/dev/src/Microsoft.Extensions.Identity.Stores/IdentityUser.cs


    public class IdentityUser : IdentityUser<int>
    {
        public IdentityUser()
        {
            
        }

        public IdentityUser(string userName)
        {
            UserName = userName;
        }
    }

    public class IdentityUserStr : IdentityUser<string>
    {
        public IdentityUserStr()
        {
            IdentityUserId = Guid.NewGuid().ToString();
        }
        public IdentityUserStr(string userName)
        {
            UserName = userName;
        }
    }

    public class IdentityUser<TKey> where TKey : IEquatable<TKey>
    {

        //-----------------------------
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityUser{TKey}"/>.
        /// </summary>
        public IdentityUser() { }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityUser{TKey}"/>.
        /// </summary>
        /// <param name="userName">The user name.</param>
        public IdentityUser(string userName) : this()
        {
            UserName = userName;
        }

        /// <summary>
        /// Gets or sets the primary key for this user.
        /// </summary>
        [Key]
        public TKey IdentityUserId { get; set; }

        /// <summary>
        /// Gets or sets the user name for this user.
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string UserName { get; set; }

        /// <summary>
        /// Gets or sets the normalized user name for this user.
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string NormalizedUserName { get; set; }

        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the normalized email address for this user.
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string NormalizedEmail { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their email address.
        /// </summary>
        /// <value>True if the email address has been confirmed, otherwise false.</value>
        public virtual bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a salted and hashed representation of the password for this user.
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string PasswordHash { get; set; }

        /// <summary>
        /// A random value that must change whenever a users credentials change (password changed, login removed)
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string SecurityStamp { get; set; }

        /// <summary>
        /// A random value that must change whenever a user is persisted to the store
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets a telephone number for the user.
        /// </summary>
        [MaxLength(length: 255)]
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their telephone address.
        /// </summary>
        /// <value>True if the telephone number has been confirmed, otherwise false.</value>
        public virtual bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if two factor authentication is enabled for this user.
        /// </summary>
        /// <value>True if 2fa is enabled, otherwise false.</value>
        public virtual bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the date and time, in UTC, when any user lockout ends.
        /// </summary>
        /// <remarks>
        /// A value in the past means the user is not locked out.
        /// </remarks>
        public virtual DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the user could be locked out.
        /// </summary>
        /// <value>True if the user could be locked out, otherwise false.</value>
        public virtual bool LockoutEnabled { get; set; }

        /// <summary>
        /// Gets or sets the number of failed login attempts for the current user.
        /// </summary>
        public virtual int AccessFailedCount { get; set; }


        public virtual List<IdentityUserRole<TKey>> Roles { get; set; } = new List<IdentityUserRole<TKey>>();
        public virtual List<IdentityUserClaim<TKey>> Claims { get; set; } = new List<IdentityUserClaim<TKey>>();
        public virtual List<IdentityUserLogin<TKey>> Logins { get; set; } = new List<IdentityUserLogin<TKey>>();
        public virtual List<IdentityUserToken<TKey>> Tokens { get; set; } = new List<IdentityUserToken<TKey>>();

        /// <summary>
        /// Returns the username for this user.
        /// </summary>
        public override string ToString()
        {
            return UserName;
        }

    }
}
