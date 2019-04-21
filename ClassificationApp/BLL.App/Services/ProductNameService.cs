using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductNameService : BaseEntityService<ProductName, IAppUnitOfWork>, IProductNameService
    {
        public ProductNameService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}