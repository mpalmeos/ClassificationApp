using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductCompanyService : 
        BaseEntityService<BLL.App.DTO.ProductCompany, DAL.App.DTO.ProductCompany, IAppUnitOfWork>, IProductCompanyService
    {
        public ProductCompanyService(IAppUnitOfWork uow) : base(uow, new ProductCompanyMapper())
        {
            ServiceRepository = Uow.ProductCompanies;
        }
    }
}