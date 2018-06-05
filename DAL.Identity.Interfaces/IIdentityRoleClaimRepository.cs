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
    public interface IIdentityRoleClaimRepository<TKey> : IRepository<IdentityRoleClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
        Task<IList<Claim>> GetClaimsAsync(TKey roleId, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveClaimAsync(TKey roleId, Claim claim,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
