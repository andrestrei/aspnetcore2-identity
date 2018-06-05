using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Application.Interfaces;
using DAL.Application.Interfaces.Repositories;
using DAL.Identity.Interfaces;
using DAL.Interfaces;
using DAL.Interfaces.Helpers;
using DAL.Interfaces.Repositories;
using Domain;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Application.EntityFramework
{
    public class ApplicationUnitOfWork : ApplicationUnitOfWork<IdentityUser, IdentityRole>, IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(IDataContext dataContext, IRepositoryProvider repositoryProvider) :base(dataContext, repositoryProvider)
        {
            
        }
    }

    public class ApplicationUnitOfWorkStr : ApplicationUnitOfWorkStr<IdentityUserStr, IdentityRoleStr>, IApplicationUnitOfWorkStr
    {
        public ApplicationUnitOfWorkStr(IDataContext dataContext, IRepositoryProvider repositoryProvider) : base(dataContext, repositoryProvider)
        {

        }
    }

    public class ApplicationUnitOfWork<TUser, TRole> : ApplicationUnitOfWork<int, TUser, TRole>, IApplicationUnitOfWork<TUser, TRole>

        where TUser : IdentityUser<int>
        where TRole : IdentityRole<int>
    {
        public ApplicationUnitOfWork(IDataContext dataContext, IRepositoryProvider repositoryProvider) :base(dataContext, repositoryProvider)
        {

        }
    }

    public class ApplicationUnitOfWorkStr<TUser, TRole> : ApplicationUnitOfWork<string, TUser, TRole>, IApplicationUnitOfWorkStr<TUser, TRole>

        where TUser : IdentityUser<string>
        where TRole : IdentityRole<string>
    {
        public ApplicationUnitOfWorkStr(IDataContext dataContext, IRepositoryProvider repositoryProvider) : base(dataContext, repositoryProvider)
        {

        }
    }


    public class ApplicationUnitOfWork<TKey, TUser, TRole> : IApplicationUnitOfWork<TKey, TUser, TRole> 
        where TKey : IEquatable<TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
    {
        private readonly IDataContext _dataContext;
        private readonly IRepositoryProvider _repositoryProvider;

        public ApplicationUnitOfWork()
        {
            
        }

        public ApplicationUnitOfWork(IDataContext dataContext, IRepositoryProvider repositoryProvider)
        {
            _dataContext = dataContext;
            _repositoryProvider = repositoryProvider;
        }

        // register all the repos that UOW uses and how to provide them
        public IRepository<FooBar> FooBars => GetEntityRepository<FooBar>();
        public IBlahRepository Blahs => GetCustomRepository<IBlahRepository>();
        public IApplicationUserRepository ApplicationUsers => GetCustomRepository<IApplicationUserRepository>();

        // identity repos
        public IIdentityUserRepository<TKey, TUser> IdentityUserRepository =>
            GetCustomRepository<IIdentityUserRepository<TKey, TUser>>();

        public IIdentityRoleRepository<TKey, TRole> IdentityRoleRepository =>
            GetCustomRepository<IIdentityRoleRepository<TKey, TRole>>();

        public IIdentityRoleClaimRepository<TKey> IdentityRoleClaimRepository =>
            GetCustomRepository<IIdentityRoleClaimRepository<TKey>>();

        public IIdentityUserRoleRepository<TKey> IdentityUserRoleRepository =>
            GetCustomRepository<IIdentityUserRoleRepository<TKey>>();

        public IIdentityUserLoginRepository<TKey> IdentityUserLoginRepository =>
            GetCustomRepository<IIdentityUserLoginRepository<TKey>>();

        public IIdentityUserClaimRepository<TKey> IdentityUserClaimRepository =>
            GetCustomRepository<IIdentityUserClaimRepository<TKey>>();

        public IIdentityUserTokenRepository<TKey> IdentityUserTokenRepository =>
            GetCustomRepository<IIdentityUserTokenRepository<TKey>>();

        public int SaveChanges()
        {
            return ((DbContext)_dataContext).SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return ((DbContext) _dataContext).SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            //CheckDisposed();
            return ((DbContext)_dataContext).SaveChangesAsync(cancellationToken: cancellationToken);
        }


        //entitity e.g. standard repository from the provider
        public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class
        {
            return _repositoryProvider.GetEntityRepository<TEntity>();
        }

        // custom repository
        public TRepository GetCustomRepository<TRepository>() where TRepository : class
        {
            return _repositoryProvider.GetCustomRepository<TRepository>();
        }


    }
}
