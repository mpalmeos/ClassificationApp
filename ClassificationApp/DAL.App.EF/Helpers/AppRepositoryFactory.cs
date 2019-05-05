using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory<AppDbContext>
    {
        public AppRepositoryFactory()
        {
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            AddToCreationMethods<ICompanyRoleRepository>(dataContext => new CompanyRoleRepository(dataContext));
            AddToCreationMethods<ICompanyRepository>(dataContext => new CompanyRepository(dataContext));
            AddToCreationMethods<ICRoleRepository>(dataContext => new CRoleRepository(dataContext));
            AddToCreationMethods<IDescriptionRepository>(dataContext => new DescriptionRepository(dataContext));
            AddToCreationMethods<IDosageRepository>(dataContext => new DosageRepository(dataContext));
            AddToCreationMethods<IProductClassificationRepository>(dataContext => new ProductClassificationRepository(dataContext));
            AddToCreationMethods<IProductCompanyRepository>(dataContext => new ProductCompanyRepository(dataContext));
            AddToCreationMethods<IProductDescriptionRepository>(dataContext => new ProductDescriptionRepository(dataContext));
            AddToCreationMethods<IProductDosageRepository>(dataContext => new ProductDosageRepository(dataContext));
            AddToCreationMethods<IProductNameRepository>(dataContext => new ProductNameRepository(dataContext));
            AddToCreationMethods<IProductRepository>(dataContext => new ProductRepository(dataContext));
            AddToCreationMethods<IRouteOfAdministrationRepository>(dataContext => new RouteOfAdministrationRepository(dataContext));
        }
    }
}