using System;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain.Identity;

namespace DAL.Identity.Interfaces
{
    public interface IIdentityRoleRepository<TKey, TIdentityRole> : IRepository<TIdentityRole>
        where TKey: IEquatable<TKey>
        where TIdentityRole : IdentityRole<TKey>
    {
        // Custom IdentityRoleRepository methods here
        Task<TIdentityRole> FindByNameAsync(string normalizedName, CancellationToken cancellationToken = default(CancellationToken));
    }
}
