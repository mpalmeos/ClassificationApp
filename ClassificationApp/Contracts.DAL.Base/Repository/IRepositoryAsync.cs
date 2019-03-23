using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DAL.Base.Repository
{
    public interface IRepositoryAsync<TEntity> : IRepositoryCommon<TEntity>
        where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> AllAsync();
        Task<TEntity> FindAsync(params object[] id);
        Task AddAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}