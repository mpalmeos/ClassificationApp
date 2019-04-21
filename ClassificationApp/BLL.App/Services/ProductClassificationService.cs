using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductClassificationService : BaseEntityService<ProductClassification, IAppUnitOfWork>, IProductClassificationService
    {
        public ProductClassificationService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}