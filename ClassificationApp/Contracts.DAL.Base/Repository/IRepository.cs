namespace Contracts.DAL.Base.Repository
{
    public interface IRepository<TEntity> : IRepositoryAsync<TEntity>
        where TEntity : class, new()
    {
    }
}