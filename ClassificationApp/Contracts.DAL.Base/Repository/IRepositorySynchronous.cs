using System.Collections.Generic;

namespace Contracts.DAL.Base.Repository
{
    public interface IRepositorySynchronous<TEntity> : IRepositoryCommon<TEntity>
        where TEntity : class, new()
    {
        IEnumerable<TEntity> All();
        TEntity Find(params object[] id);
        void Add(TEntity entity);
    }
}