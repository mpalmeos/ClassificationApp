using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductDescriptionService : 
        BaseEntityService<BLL.App.DTO.ProductDescription, DAL.App.DTO.ProductDescription, IAppUnitOfWork>, IProductDescriptionService
    {
        public ProductDescriptionService(IAppUnitOfWork uow) : base(uow, new ProductDescriptionMapper())
        {
            ServiceRepository = Uow.ProductDescriptions;
        }
    }
}