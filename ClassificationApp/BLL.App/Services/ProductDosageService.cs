using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductDosageService : BaseEntityService<ProductDosage, IAppUnitOfWork>, IProductDosageService
    {
        public ProductDosageService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}