using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity.Interfaces
{
    public interface IIdentityUserLoginRepository<TKey> : IRepository<IdentityUserLogin<TKey>>
        where TKey : IEquatable<TKey>
    {
        Task<IdentityUserLogin<TKey>> FindUserLoginAsync(TKey id, string loginProvider, string providerKey, CancellationToken cancellationToken = default(CancellationToken));
        Task<IdentityUserLogin<TKey>> FindUserLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<UserLoginInfo>> GetLoginsAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
