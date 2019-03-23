using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, new()
    {
        protected DbContext RepositoryDbContext;
        protected DbSet<TEntity> RepositoryDbSet;

        public BaseRepository(DbContext repositoryDbContext)
        {
            RepositoryDbContext = repositoryDbContext;
            RepositoryDbSet = RepositoryDbContext.Set<TEntity>();
        }

        public TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity).Entity;
        }

        public void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity);
        }

        public void Remove(params object[] id)
        {
            Remove(FindAsync(id).Result);
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await RepositoryDbSet.ToListAsync();
        }

        public Task<TEntity> FindAsync(params object[] id)
        {
            return RepositoryDbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await RepositoryDbSet.AddAsync(entity);
        }
    }
}