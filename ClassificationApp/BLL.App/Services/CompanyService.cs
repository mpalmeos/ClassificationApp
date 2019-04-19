using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class CompanyService : BaseEntityService<Company, IAppUnitOfWork>, ICompanyService
    {
        public CompanyService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}