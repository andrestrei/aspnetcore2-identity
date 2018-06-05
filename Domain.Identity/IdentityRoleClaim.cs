﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;

namespace Domain.Identity
{
    public class IdentityRoleClaim : IdentityRoleClaim<int>
    {
        
    }

    public class IdentityRoleClaimStr : IdentityRoleClaim<string>
    {
        public IdentityRoleClaimStr()
        {
            IdentityRoleClaimId = Guid.NewGuid().ToString();
        }
    }


    /// <summary>
    /// Represents a claim that is granted to all users within a role.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key of the role associated with this claim.</typeparam>
    public class IdentityRoleClaim<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the identifier for this role claim.
        /// </summary>
        [Key]
        public TKey IdentityRoleClaimId { get; set; }

        /// <summary>
        /// Gets or sets the of the primary key of the role associated with this claim.
        /// </summary>
        public virtual TKey IdentityRoleId { get; set; }

        public virtual IdentityRole<TKey> IdentityRole { get; set; }

        /// <summary>
        /// Gets or sets the claim type for this claim.
        /// </summary>
        public virtual string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value for this claim.
        /// </summary>
        public virtual string ClaimValue { get; set; }

        /// <summary>
        /// Constructs a new claim with the type and value.
        /// </summary>
        /// <returns></returns>
        public virtual Claim ToClaim()
        {
            return new Claim(ClaimType, ClaimValue);
        }

        /// <summary>
        /// Initializes by copying ClaimType and ClaimValue from the other claim.
        /// </summary>
        /// <param name="other">The claim to initialize from.</param>
        public virtual void InitializeFromClaim(Claim other)
        {
            ClaimType = other?.Type;
            ClaimValue = other?.Value;
        }
    }
}
