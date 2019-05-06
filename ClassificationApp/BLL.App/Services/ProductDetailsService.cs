using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Mappers;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class ProductDetailsService :
        BaseEntityService<BLL.App.DTO.Customs.ProductDetails, DAL.App.DTO.Customs.ProductDetails, IAppUnitOfWork>, IProductDetailsService
    {
        public ProductDetailsService(IAppUnitOfWork uow) : base(uow, new ProductDetailsMapper())
        {
            ServiceRepository = Uow.ProductDetails;
        }
    }
}