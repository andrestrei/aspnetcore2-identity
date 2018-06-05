using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain.Identity;

namespace DAL.Identity.Interfaces
{
    public interface IIdentityUserTokenRepository<TKey> : IRepository<IdentityUserToken<TKey>>
        where TKey : IEquatable<TKey>
    {
        Task<IdentityUserToken<TKey>> FindTokenAsync(TKey id, string loginProvider, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}
