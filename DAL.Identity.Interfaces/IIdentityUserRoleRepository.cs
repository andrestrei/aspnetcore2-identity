using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain.Identity;

namespace DAL.Identity.Interfaces
{
    public interface IIdentityUserRoleRepository<TKey> : IRepository<IdentityUserRole<TKey>>
        where TKey : IEquatable<TKey>
    {
        Task<IdentityUserRole<TKey>> FindUserRoleAsync(TKey userId, TKey roleId, CancellationToken cancellationToken = default(CancellationToken));

        Task<List<string>> GetRolesAsync(TKey userId, CancellationToken cancellationToken = default(CancellationToken));

        Task<List<IdentityUserRole<TKey>>> UserRolesFullInfoAsync();
    }
}
