using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductCompositionService : BaseEntityService<ProductComposition, IAppUnitOfWork>, IProductCompositionService
    {
        public ProductCompositionService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}