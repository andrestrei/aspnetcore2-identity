using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain.Identity;

namespace DAL.Identity.Interfaces
{
    public interface IIdentityUserRepository<TKey, TUser> : IRepository<TUser> 
        where TKey: IEquatable<TKey>
        where TUser : IdentityUser<TKey>
    {
        // Custom IdentityUserRepository methods here
        Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken));

        Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken));

        Task<List<TUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = default(CancellationToken));

        Task<List<TUser>> GetUsersInRoleAsync(TKey roleId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
