using System;
using System.Collections.Generic;
using System.Text;
using DAL.Application.EntityFramework.Repositories;
using DAL.Application.Interfaces.Repositories;
using DAL.Identity.Interfaces;
using DAL.Interfaces;
using DAL.Interfaces.Helpers;
using Domain;
using Domain.Identity;

namespace DAL.Application.EntityFramework.Helpers
{
    public class BaseRepositoryFactory : IRepositoryFactory
    {
        private readonly IDictionary<Type, Func<IDataContext, object>> _repositoryFactories;

        public BaseRepositoryFactory()
        {
            _repositoryFactories = GetCustomFactories();
        }

        //special repos with custom interfaces are registered here
        private static IDictionary<Type, Func<IDataContext, object>> GetCustomFactories()
        {
            return new Dictionary<Type, Func<IDataContext, object>>
            {
                // app repos
                {typeof(IBlahRepository), dbContext => new BlahRepository(dataContext: dbContext)},
                {typeof(IApplicationUserRepository), dbContext => new ApplicationUserRepository(dataContext: dbContext)},
                
                // Identity repos
                //{ typeof(IIdentityRoleRepository<int,IdentityRole<int>>), dbContext => new IdentityRoleRepository<int,IdentityRole<int>>(dbContext)},
                // string based
                {typeof(IIdentityRoleRepository<string,IdentityRoleStr>), dbContext => new IdentityRoleRepository<string,IdentityRoleStr>(dbContext)},
                // int based
                {typeof(IIdentityRoleRepository<int,IdentityRole>), dbContext => new IdentityRoleRepository<int,IdentityRole>(dbContext)},
                

                { typeof(IIdentityRoleClaimRepository<int>), dbContext => new IdentityRoleClaimRepository<int>(dataContext: dbContext)},
                { typeof(IIdentityRoleClaimRepository<string>), dbContext => new IdentityRoleClaimRepository<string>(dataContext: dbContext)},

                {typeof(IIdentityUserClaimRepository<int>), dbContext => new IdentityUserClaimRepository<int>(dataContext: dbContext)},
                {typeof(IIdentityUserClaimRepository<string>), dbContext => new IdentityUserClaimRepository<string>(dataContext: dbContext)},

                {typeof(IIdentityUserLoginRepository<int>), dbContext => new IdentityUserLoginRepository<int>(dataContext: dbContext)},
                {typeof(IIdentityUserLoginRepository<string>), dbContext => new IdentityUserLoginRepository<string>(dataContext: dbContext)},

                //{typeof(IIdentityUserRepository<int, IdentityUser<int>>), dbContext => new IdentityUserRepository<int, IdentityUser<int>>(dataContext: dbContext)},
                // string based
                {typeof(IIdentityUserRepository<string, IdentityUserStr>), dbContext => new IdentityUserRepository<string, IdentityUserStr>(dataContext: dbContext)},
                // int based
                {typeof(IIdentityUserRepository<int, ApplicationUser>), dbContext => new IdentityUserRepository<int, ApplicationUser>(dataContext: dbContext)},

                {typeof(IIdentityUserRoleRepository<int>), dbContext => new IdentityUserRoleRepository<int>(dataContext: dbContext)},
                {typeof(IIdentityUserRoleRepository<string>), dbContext => new IdentityUserRoleRepository<string>(dataContext: dbContext)},

                {typeof(IIdentityUserTokenRepository<int>), dbContext => new IdentityUserTokenRepository<int>(dataContext: dbContext)},
                {typeof(IIdentityUserTokenRepository<string>), dbContext => new IdentityUserTokenRepository<string>(dataContext: dbContext)},
                
            };
        }
        public Func<IDataContext, object> GetRepositoryFactoryForType<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Func<IDataContext, object> GetCustomRepositoryFactory<TEntity>() where TEntity : class
        {
            Func<IDataContext, object> factory;

            _repositoryFactories.TryGetValue(key: typeof(TEntity), value: out factory);

            return factory;
        }

        public Func<IDataContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class
        {
            // create new instance of EFRepository<TEntity>
            return dataContext => new BaseRepository<TEntity>(dataContext: dataContext);
        }
    }
}
