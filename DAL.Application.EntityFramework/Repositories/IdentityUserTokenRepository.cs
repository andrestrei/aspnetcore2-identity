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
    public class IdentityUserTokenRepository<TKey> : BaseRepository<IdentityUserToken<TKey>>, IIdentityUserTokenRepository<TKey>
        where TKey : IEquatable<TKey>
    {
        public IdentityUserTokenRepository(IDataContext dataContext) : base(dataContext)
        {
            
        }
        public Task<IdentityUserToken<TKey>> FindTokenAsync(TKey id, string loginProvider, string name,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return RepositoryDbSet
                .FirstOrDefaultAsync(predicate: ut => ut.IdentityUserId.Equals(id) && ut.LoginProvider == loginProvider && ut.Name == name, cancellationToken: cancellationToken);

        }
    }
}
