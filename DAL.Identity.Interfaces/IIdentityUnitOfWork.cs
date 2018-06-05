using System;
using Domain.Identity;
using DAL.Identity.Interfaces;
using DAL.Interfaces;

namespace DAL.Identity.Interfaces
{
    public interface IIdentityUnitOfWork : IIdentityUnitOfWork<IdentityUser, IdentityRole>
    {
        
    }

    public interface IIdentityUnitOfWorkStr : IIdentityUnitOfWorkStr<IdentityUserStr, IdentityRoleStr>
    {

    }

    public interface IIdentityUnitOfWork<TUser, TRole> : IIdentityUnitOfWork<int, TUser, TRole>
        where TUser : IdentityUser<int>
        where TRole : IdentityRole<int>
    {

    }

    public interface IIdentityUnitOfWorkStr<TUser, TRole> : IIdentityUnitOfWork<string, TUser, TRole>
        where TUser : IdentityUser<string>
        where TRole : IdentityRole<string>
    {

    }


    public interface IIdentityUnitOfWork<TKey, TUser, TRole> : IUnitOfWork<TKey>
        where TKey: IEquatable<TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
    {
        IIdentityUserRepository<TKey, TUser> IdentityUserRepository { get; }
        IIdentityRoleRepository<TKey, TRole> IdentityRoleRepository { get; }
        IIdentityRoleClaimRepository<TKey> IdentityRoleClaimRepository { get; }
        IIdentityUserRoleRepository<TKey> IdentityUserRoleRepository { get; }
        IIdentityUserLoginRepository<TKey> IdentityUserLoginRepository { get; }
        IIdentityUserClaimRepository<TKey> IdentityUserClaimRepository { get; }
        IIdentityUserTokenRepository<TKey> IdentityUserTokenRepository { get; }
    }
}
