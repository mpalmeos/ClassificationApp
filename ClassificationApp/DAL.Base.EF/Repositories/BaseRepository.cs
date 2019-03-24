using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, new()
    {
        
        protected readonly DbContext RepositoryDbContext;
        protected readonly DbSet<TEntity> RepositoryDbSet;

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

        public virtual async Task<IEnumerable<TEntity>> AllAsync()
        {
            var recordCount = await RepositoryDbSet.CountAsync();
            if (recordCount > 100)
            {
                throw new DataException($"Too many possibilities ({recordCount} > 100)! Aborting query.");
            }
            
            return await RepositoryDbSet.ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(params object[] id)
        {
            return await RepositoryDbSet.FindAsync(id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await RepositoryDbSet.AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await RepositoryDbContext.SaveChangesAsync();
        }
    }
}