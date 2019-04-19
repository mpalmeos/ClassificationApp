using System.Threading.Tasks;
using Contracts.DAL.Base.Repository;

namespace Contracts.DAL.Base
{
    public interface IBaseUnitOfWork
    {
        IBaseRepository<TEntity> BaseRepository<TEntity>()
            where TEntity : class, IBaseEntity, new();
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}