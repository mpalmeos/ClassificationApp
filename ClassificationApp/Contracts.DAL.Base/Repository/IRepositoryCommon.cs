namespace Contracts.DAL.Base.Repository
{
    public interface IRepositoryCommon<TEntity> 
        where TEntity : class, new()
    {
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(params object[] id);
    }
}