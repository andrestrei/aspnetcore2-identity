using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Identity.Interfaces;
using DAL.Interfaces;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Application.EntityFramework.Repositories
{
    public class IdentityUserClaimRepository<TKey> : BaseRepository<IdentityUserClaim<TKey>>, IIdentityUserClaimRepository<TKey>
        where TKey : IEquatable<TKey>
    {
        public IdentityUserClaimRepository(IDataContext dataContext) : base(dataContext)
        {
            
        }

        public Task<List<Claim>> GetClaimsAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return RepositoryDbSet
                .Where(predicate: uc => uc.IdentityUserId.Equals(id))
                .Select(selector: c => c.ToClaim())
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public Task ReplaceClaimAsync(TKey id, Claim claim, Claim newClaim,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimsAsync(TKey id, IEnumerable<Claim> claims, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
