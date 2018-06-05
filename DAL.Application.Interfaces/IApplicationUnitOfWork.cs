using DAL.Application.Interfaces.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Domain;
using System;
using DAL.Identity.Interfaces;
using Domain.Identity;

namespace DAL.Application.Interfaces
{
    public interface IApplicationUnitOfWork : IApplicationUnitOfWork<IdentityUser, IdentityRole>, IIdentityUnitOfWork
    {
        
    }

    public interface IApplicationUnitOfWorkStr : IApplicationUnitOfWorkStr<IdentityUserStr, IdentityRoleStr>, IIdentityUnitOfWorkStr
    {

    }


    public interface IApplicationUnitOfWork<TUser, TRole> : IApplicationUnitOfWork<int, TUser, TRole>, IIdentityUnitOfWork<TUser, TRole>
        where TUser : IdentityUser<int>
        where TRole : IdentityRole<int>
    {

    }

    public interface IApplicationUnitOfWorkStr<TUser, TRole> : IApplicationUnitOfWork<string, TUser, TRole>, IIdentityUnitOfWorkStr<TUser, TRole>
        where TUser : IdentityUser<string>
        where TRole : IdentityRole<string>
    {

    }



    public interface IApplicationUnitOfWork<TKey, TUser, TRole> : IIdentityUnitOfWork<TKey, TUser, TRole>
        where TKey : IEquatable<TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
    {
        IRepository<FooBar> FooBars { get; }

        IBlahRepository Blahs { get; }

        IApplicationUserRepository ApplicationUsers { get; }

    }
}
