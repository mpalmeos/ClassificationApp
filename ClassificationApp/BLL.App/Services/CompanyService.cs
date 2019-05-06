using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class CompanyService : 
        BaseEntityService<BLL.App.DTO.Company, DAL.App.DTO.Company, IAppUnitOfWork>, ICompanyService
    {
        public CompanyService(IAppUnitOfWork uow) : base(uow, new CompanyMapper())
        {
            ServiceRepository = Uow.Companies;
        }
    }
}