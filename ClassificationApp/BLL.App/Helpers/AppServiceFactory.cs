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
            AddToCreationMethods<ICompanyRoleService>(uow => new CompanyRoleService(uow));
            AddToCreationMethods<ICompanyService>(uow => new CompanyService(uow));
            AddToCreationMethods<ICRoleService>(uow => new CRoleService(uow));
            AddToCreationMethods<IDescriptionService>(uow => new DescriptionService(uow));
            AddToCreationMethods<IDosageService>(uow => new DosageService(uow));
            AddToCreationMethods<IProductClassificationService>(uow => new ProductClassificationService(uow));
            AddToCreationMethods<IProductCompanyService>(uow => new ProductCompanyService(uow));
            AddToCreationMethods<IProductDescriptionService>(uow => new ProductDescriptionService(uow));
            AddToCreationMethods<IProductDosageService>(uow => new ProductDosageService(uow));
            AddToCreationMethods<IProductNameService>(uow => new ProductNameService(uow));
            AddToCreationMethods<IProductService>(uow => new ProductService(uow));
            AddToCreationMethods<IRouteOfAdministrationService>(uow => new RouteOfAdministrationService(uow));
            
        }
    }
}