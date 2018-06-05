using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain.Identity;

namespace DAL.Identity.Interfaces
{
    public interface IIdentityUserClaimRepository<TKey> : IRepository<IdentityUserClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
        Task<List<Claim>> GetClaimsAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
        Task ReplaceClaimAsync(TKey id, Claim claim, Claim newClaim, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveClaimsAsync(TKey id, IEnumerable<Claim> claims, CancellationToken cancellationToken = default(CancellationToken));
    }
}
