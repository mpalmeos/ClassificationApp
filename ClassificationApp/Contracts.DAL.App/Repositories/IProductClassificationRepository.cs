using Contracts.DAL.Base.Repository;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IProductClassificationRepository : IProductClassificationRepository<DALAppDTO.ProductClassification>
    {
        
    }
    
    public interface IProductClassificationRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        
    }
}