using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Identity.Interfaces;
using DAL.Interfaces;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Application.EntityFramework.Repositories
{
    public class IdentityUserRoleRepository<TKey> : BaseRepository<IdentityUserRole<TKey>>, IIdentityUserRoleRepository<TKey>
        where TKey : IEquatable<TKey>
    {
        public IdentityUserRoleRepository(IDataContext dataContext) : base(dataContext)
        {
            
        }

        public Task<IdentityUserRole<TKey>> FindUserRoleAsync(TKey userId, TKey roleId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetRolesAsync(TKey userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = RepositoryDbSet.Where(u => u.IdentityUserId.Equals(userId))
                .Include(a => a.IdentityRole)
                .Select(r => r.IdentityRole.Name);

            return query.ToListAsync(cancellationToken);
        }

        public Task<List<IdentityUserRole<TKey>>> UserRolesFullInfoAsync()
        {
            var query = RepositoryDbSet.Include(u => u.IdentityUser).Include(r => r.IdentityRole)
                .OrderBy(u => u.IdentityUser.NormalizedEmail).ThenBy(r => r.IdentityRole.NormalizedName);
            return query.ToListAsync();
        }
    }
}
