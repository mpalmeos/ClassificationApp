using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using Contracts.DAL.Base.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF
{
    public class BaseUnitOfWork<TDbContext> : IBaseUnitOfWork
        where TDbContext : DbContext
    {
        protected readonly TDbContext UnitOfWorkDbContext;
        protected readonly IBaseRepositoryProvider _repositoryProvider;

        public BaseUnitOfWork(TDbContext unitOfWorkDbContext, IBaseRepositoryProvider repositoryProvider)
        {
            UnitOfWorkDbContext = unitOfWorkDbContext;
            _repositoryProvider = repositoryProvider;
        }


        public IBaseRepository<TEntity> BaseRepository<TEntity>() 
            where TEntity : class, IBaseEntity, new()
        {
            return _repositoryProvider.GetEntityRepository<TEntity>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await UnitOfWorkDbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return UnitOfWorkDbContext.SaveChanges();
        }
    }
}