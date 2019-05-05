using Contracts.DAL.Base.Repository;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ICompanyRepository : ICompanyRepository<DALAppDTO.Company>
    {
        
    }

    public interface ICompanyRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        
    }
}