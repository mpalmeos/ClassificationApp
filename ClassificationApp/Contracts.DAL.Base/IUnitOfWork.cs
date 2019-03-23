using System.Threading.Tasks;

namespace Contracts.DAL.Base
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}