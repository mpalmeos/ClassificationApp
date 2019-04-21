using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductCompanyService : BaseEntityService<ProductCompany, IAppUnitOfWork>, IProductCompanyService
    {
        public ProductCompanyService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}