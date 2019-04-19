using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DAL.Base.Repository
{
    public interface IBaseRepositoryAsync<TEntity> : IBaseRepositoryAsync<TEntity, int>
        where TEntity : class, IBaseEntity<int>, new()
    {
        
    }
    
    public interface IBaseRepositoryAsync<TEntity, TKey> : IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TKey : IComparable
    {
        Task<List<TEntity>> AllAsync();
        Task<TEntity> FindAsync(params object[] id);
        Task AddAsync(TEntity entity);
    }
}