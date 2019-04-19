using System;

namespace Contracts.DAL.Base.Repository
{
    public interface IBaseRepositoryCommon<TEntity, TKey> 
        where TEntity : class, IBaseEntity<TKey>, new()
        where TKey :  IComparable
    {
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(params object[] id);
    }
}