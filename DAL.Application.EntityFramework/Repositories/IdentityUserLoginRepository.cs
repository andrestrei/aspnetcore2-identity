using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Identity.Interfaces;
using DAL.Interfaces;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DAL.Application.EntityFramework.Repositories
{
    public class IdentityUserLoginRepository<TKey> : BaseRepository<IdentityUserLogin<TKey>>, IIdentityUserLoginRepository<TKey>
        where TKey : IEquatable<TKey>
    {
        public IdentityUserLoginRepository(IDataContext dataContext) : base(dataContext)
        {
            
        }

        public Task<IdentityUserLogin<TKey>> FindUserLoginAsync(TKey id, string loginProvider, string providerKey,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUserLogin<TKey>> FindUserLoginAsync(string loginProvider, string providerKey,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<List<UserLoginInfo>> GetLoginsAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
