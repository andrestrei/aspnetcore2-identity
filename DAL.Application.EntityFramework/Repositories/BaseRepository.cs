using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Application.EntityFramework.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext RepositoryDbContext;
        protected DbSet<TEntity> RepositoryDbSet;

        public BaseRepository()
        {
            
        }
        public BaseRepository(IDataContext dataContext)
        {
            RepositoryDbContext = dataContext as DbContext ?? throw new ArgumentNullException("No EF DbContext");
            RepositoryDbSet = RepositoryDbContext.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> All()
        {
            return RepositoryDbSet.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> AllAsync() => await RepositoryDbSet.ToListAsync();

        public TEntity Find(params object[] id)
        {
            return RepositoryDbSet.Find(id);
        }

        public virtual Task<TEntity> FindAsync(params object[] id)
        {
            return RepositoryDbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return await RepositoryDbSet.FindAsync(keyValues: keyValues, cancellationToken: cancellationToken);
        }

        public void Add(TEntity entity)
        {
            RepositoryDbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await RepositoryDbSet.AddAsync(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity).Entity;
        }

        public void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity);
        }

        // remove single entity
        public void Remove(params object[] id)  // ei tea mis välja juures ID on
        {
            var entity = RepositoryDbSet.Find(id);
            Remove(entity);
        }

        // multiple entity removeimplementatins
    }
}
