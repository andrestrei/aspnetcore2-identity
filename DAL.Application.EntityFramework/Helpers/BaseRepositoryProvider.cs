using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DAL.Interfaces.Helpers;
using DAL.Interfaces.Repositories;

namespace DAL.Application.EntityFramework.Helpers
{
    public class BaseRepositoryProvider<TContext> : IRepositoryProvider where TContext : IDataContext
    {
        private readonly IDataContext _dataContext;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly Dictionary<Type, object> _repositoryCache = new Dictionary<Type, object>();

        public BaseRepositoryProvider(TContext dataContext, IRepositoryFactory repositoryFactory)
        {
            _dataContext = dataContext;
            _repositoryFactory = repositoryFactory;
        }
        public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class
        {
            // kontrollerist jõuab päring siia, genericuna on kaasas klass, nt FooBar. Peame nüüd vaatama kuidas me repo tagastame
            return GetOrMakeRepository<IRepository<TEntity>>(_repositoryFactory.GetStandardRepositoryFactory<TEntity>());
        }

        public TRepository GetCustomRepository<TRepository>() where TRepository : class
        {
            // Kuidas siit harust andmebaasiContext delegaadini jõuab??
            return GetOrMakeRepository<TRepository>(_repositoryFactory.GetCustomRepositoryFactory<TRepository>());
        }

        private TRepository GetOrMakeRepository<TRepository>(Func<IDataContext, object> factory) where TRepository : class
        {
            // vaatame cache'i, kas seal on juba selline repo
            object repoObj;
            _repositoryCache.TryGetValue(key: typeof(TRepository), value: out repoObj);
            if (repoObj != null)
            {
                // kui oli olemas, siis tagastame
                return (TRepository)repoObj;
            }
                
            // Kui ei olnud, siis peame vastava repo looma
            return MakeRepository<TRepository>(factory: factory);
        }

        private TRepository MakeRepository<TRepository>(Func<IDataContext, object> factory) where TRepository : class
        {
            // kui factory delegaat on null, siis tuleb see luua, ehk siis proovime luua hoopis customrepot??? kuigi foobar oli standard
            var repositoryFactory = factory ?? _repositoryFactory.GetCustomRepositoryFactory<TRepository>();
            if (repositoryFactory == null)
            {
                // factory ei oska sellist repot luua
                throw new NotImplementedException(message: $"No factory for repository type {typeof(TRepository).FullName}");
            }
            // See rida veids arusaamatu. Anname delegaadile ette andmebaasi ühenduse ja cast'ime teda??? Okei, jah, andmebaasiyhendus on delegaadi sisendparameeter
            var repo = (TRepository)repositoryFactory(arg: _dataContext);

            // paneme repo cache'i
            _repositoryCache[key: typeof(TRepository)] = repo;
            return repo;
        }
    }
}
