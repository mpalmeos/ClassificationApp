using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductClassificationService : 
        BaseEntityService<BLL.App.DTO.ProductClassification, DAL.App.DTO.ProductClassification, IAppUnitOfWork>, IProductClassificationService
    {
        public ProductClassificationService(IAppUnitOfWork uow) : base(uow, new ProductClassificationMapper())
        {
            ServiceRepository = Uow.ProductClassifications;
        }
    }
}