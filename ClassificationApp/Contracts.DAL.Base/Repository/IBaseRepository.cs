using System;

namespace Contracts.DAL.Base.Repository
{
    public interface IBaseRepository<TEntity> : 
        IBaseRepositoryAsync<TEntity>, IBaseRepositorySynchronous<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
    }

    public interface IBaseRepository<TEntity, TKey> : IBaseRepositoryAsync<TEntity, TKey>,
        IBaseRepositorySynchronous<TEntity, TKey>
        where TKey : IComparable
        where TEntity : class, IBaseEntity<TKey>, new()
    {
        
    }
}