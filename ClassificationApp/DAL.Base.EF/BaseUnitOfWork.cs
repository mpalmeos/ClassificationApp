using System.Threading.Tasks;
using Contracts.DAL.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        protected DbContext UnitOfWorkDbContext;

        public BaseUnitOfWork(DbContext unitOfWorkDbContext)
        {
            UnitOfWorkDbContext = unitOfWorkDbContext;
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