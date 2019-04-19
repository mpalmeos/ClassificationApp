using System;
using System.Collections.Generic;

namespace Contracts.DAL.Base.Repository
{
    public interface IBaseRepositorySynchronous<TEntity> : IBaseRepositorySynchronous<TEntity, int>
        where TEntity : class, IBaseEntity<int>, new()
    {
        
    }
    
    public interface IBaseRepositorySynchronous<TEntity, TKey> : IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TKey : IComparable
    {
        List<TEntity> All();
        TEntity Find(params object[] id);
        void Add(TEntity entity);
    }
}