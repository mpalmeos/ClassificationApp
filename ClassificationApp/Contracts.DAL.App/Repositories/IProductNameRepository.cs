using ee.itcollege.mpalmeos.Contracts.DAL.Base.Repository;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IProductNameRepository : IProductNameRepository<DALAppDTO.ProductName>
    {
        
    }

    public interface IProductNameRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        
    }
}