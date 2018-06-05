using DAL.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork<TKey> where TKey : IEquatable<TKey>
    {
        // Save changes to underlaying datastore (if supported)
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        // get standard repository for type TEntity
        IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class;

        // get custom repository, based on interface
        // see also IRepositoryProvider and IRepositoryFactory
        TRepository GetCustomRepository<TRepository>() where TRepository : class;
    }
}
