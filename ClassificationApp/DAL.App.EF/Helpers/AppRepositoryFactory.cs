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
            AddToCreationMethods<ICategoryRepository>(dataContext => new CategoryRepository(dataContext));
            AddToCreationMethods<ICompanyRoleRepository>(dataContext => new CompanyRoleRepository(dataContext));
            AddToCreationMethods<ICompanyRepository>(dataContext => new CompanyRepository(dataContext));
            AddToCreationMethods<ICompositionHerbRepository>(dataContext => new CompositionHerbRepository(dataContext));
            AddToCreationMethods<ICompositionRepository>(dataContext => new CompositionRepository(dataContext));
            AddToCreationMethods<ICompositionSubstanceRepository>(dataContext => new CompositionSubstanceRepository(dataContext));
            AddToCreationMethods<ICRoleRepository>(dataContext => new CRoleRepository(dataContext));
            AddToCreationMethods<IDescriptionRepository>(dataContext => new DescriptionRepository(dataContext));
            AddToCreationMethods<IDosageRepository>(dataContext => new DosageRepository(dataContext));
            AddToCreationMethods<IHerbFormRepository>(dataContext => new HerbFormRepository(dataContext));
            AddToCreationMethods<IHerbMedicinalRepository>(dataContext => new HerbMedicinalRepository(dataContext));
            AddToCreationMethods<IHerbPartRepository>(dataContext => new HerbPartRepository(dataContext));
            AddToCreationMethods<IHerbRepository>(dataContext => new HerbRepository(dataContext));
            AddToCreationMethods<IMedicinalDoseRepository>(dataContext => new MedicinalDoseRepository(dataContext));
            AddToCreationMethods<IPlantFormRepository>(dataContext => new PlantFormRepository(dataContext));
            AddToCreationMethods<IPlantPartRepository>(dataContext => new PlantPartRepository(dataContext));
            AddToCreationMethods<IProductClassificationRepository>(dataContext => new ProductClassificationRepository(dataContext));
            AddToCreationMethods<IProductCompanyRepository>(dataContext => new ProductCompanyRepository(dataContext));
            AddToCreationMethods<IProductCompositionRepository>(dataContext => new ProductCompositionRepository(dataContext));
            AddToCreationMethods<IProductDescriptionRepository>(dataContext => new ProductDescriptionRepository(dataContext));
            AddToCreationMethods<IProductDosageRepository>(dataContext => new ProductDosageRepository(dataContext));
            AddToCreationMethods<IProductNameRepository>(dataContext => new ProductNameRepository(dataContext));
            AddToCreationMethods<IProductRepository>(dataContext => new ProductRepository(dataContext));
            AddToCreationMethods<IRouteOfAdministrationRepository>(dataContext => new RouteOfAdministrationRepository(dataContext));
            AddToCreationMethods<ISubstanceCategoryRepository>(dataContext => new SubstanceCategoryRepository(dataContext));
            AddToCreationMethods<ISubstanceMedicinalRepository>(dataContext => new SubstanceMedicinalRepository(dataContext));
            AddToCreationMethods<ISubstanceRepository>(dataContext => new SubstanceRepository(dataContext));
            AddToCreationMethods<IUnitOfMeasureRepository>(dataContext => new UnitOfMeasureRepository(dataContext));
        }
    }
}