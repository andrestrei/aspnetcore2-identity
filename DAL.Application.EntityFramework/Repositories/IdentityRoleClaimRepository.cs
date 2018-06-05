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
    public class IdentityRoleClaimRepository<TKey> : BaseRepository<IdentityRoleClaim<TKey>>, IIdentityRoleClaimRepository<TKey> where TKey : IEquatable<TKey>
    {

        public IdentityRoleClaimRepository(IDataContext dataContext) : base(dataContext)
        {
            
        }
        public async Task<IList<Claim>> GetClaimsAsync(TKey roleId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await RepositoryDbSet.Where(predicate: rc => rc.IdentityRoleId.Equals(roleId)).Select(selector: c => new Claim(c.ClaimType, c.ClaimValue)).ToListAsync(cancellationToken: cancellationToken);
        }

        public Task RemoveClaimAsync(TKey roleId, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
