using Contracts.DAL.Base.Repository;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{

    public interface IProductDescriptionRepository : IProductDescriptionRepository<DALAppDTO.ProductDescription>
    {
        
    }
    
    public interface IProductDescriptionRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        
    }
}