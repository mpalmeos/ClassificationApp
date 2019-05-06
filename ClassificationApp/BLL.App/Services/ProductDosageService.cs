using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductDosageService : 
        BaseEntityService<BLL.App.DTO.ProductDosage, DAL.App.DTO.ProductDosage, IAppUnitOfWork>, IProductDosageService
    {
        public ProductDosageService(IAppUnitOfWork uow) : base(uow, new ProductDosageMapper())
        {
            ServiceRepository = Uow.ProductDosages;
        }
    }
}