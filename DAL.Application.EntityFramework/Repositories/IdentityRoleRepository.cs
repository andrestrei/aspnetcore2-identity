using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Identity.Interfaces;
using DAL.Interfaces;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Application.EntityFramework.Repositories
{
    public class IdentityRoleRepository<TKey, TIdentityRole> : BaseRepository<TIdentityRole>, IIdentityRoleRepository<TKey, TIdentityRole>
        where TKey : IEquatable<TKey>
        where TIdentityRole : IdentityRole<TKey>
    {
        public IdentityRoleRepository(IDataContext dataContext) : base(dataContext)
        {
            
        }
        public Task<TIdentityRole> FindByNameAsync(string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var firstOrDefaultAsync = RepositoryDbSet.FirstOrDefaultAsync(predicate: r => r.NormalizedName == normalizedName, cancellationToken: cancellationToken);
            return firstOrDefaultAsync;
        }
    }
}
