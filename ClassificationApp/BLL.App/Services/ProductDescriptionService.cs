using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductDescriptionService : BaseEntityService<ProductDescription, IAppUnitOfWork>, IProductDescriptionService
    {
        public ProductDescriptionService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}