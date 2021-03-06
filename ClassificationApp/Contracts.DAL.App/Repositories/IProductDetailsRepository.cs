using ee.itcollege.mpalmeos.Contracts.DAL.Base.Repository;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IProductDetailsRepository : IProductDetailsRepository<DALAppDTO.Customs.ProductDetails>
    {
        
    }

    public interface IProductDetailsRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        
    }
}