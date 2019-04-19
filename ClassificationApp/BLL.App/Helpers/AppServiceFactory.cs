using BLL.App.Services;
using BLL.Base.Helpers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Microsoft.EntityFrameworkCore.Internal;

namespace BLL.App.Helpers
{
    public class AppServiceFactory : BaseServiceFactory<IAppUnitOfWork>
    {
        public AppServiceFactory()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            AddToCreationMethods<ICompanyService>(
                uow => new CompanyService(uow));
        }
    }
}