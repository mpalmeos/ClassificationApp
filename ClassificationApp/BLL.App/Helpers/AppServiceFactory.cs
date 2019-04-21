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
            AddToCreationMethods<ICategoryService>(uow => new CategoryService(uow));
            AddToCreationMethods<ICompanyRoleService>(uow => new CompanyRoleService(uow));
            AddToCreationMethods<ICompanyService>(uow => new CompanyService(uow));
            AddToCreationMethods<ICompositionHerbService>(uow => new CompositionHerbService(uow));
            AddToCreationMethods<ICompositionService>(uow => new CompositionService(uow));
            AddToCreationMethods<ICompositionSubstanceService>(uow => new CompositionSubstanceService(uow));
            AddToCreationMethods<ICRoleService>(uow => new CRoleService(uow));
            AddToCreationMethods<IDescriptionService>(uow => new DescriptionService(uow));
            AddToCreationMethods<IDosageService>(uow => new DosageService(uow));
            AddToCreationMethods<IHerbFormService>(uow => new HerbFormService(uow));
            AddToCreationMethods<IHerbMedicinalService>(uow => new HerbMedicinalService(uow));
            AddToCreationMethods<IHerbPartService>(uow => new HerbPartService(uow));
            AddToCreationMethods<IHerbService>(uow => new HerbService(uow));
            AddToCreationMethods<IMedicinalDoseService>(uow => new MedicinalDoseService(uow));
            AddToCreationMethods<IPlantFormService>(uow => new PlantFormService(uow));
            AddToCreationMethods<IPlantPartService>(uow => new PlantPartService(uow));
            AddToCreationMethods<IProductClassificationService>(uow => new ProductClassificationService(uow));
            AddToCreationMethods<IProductCompanyService>(uow => new ProductCompanyService(uow));
            AddToCreationMethods<IProductCompositionService>(uow => new ProductCompositionService(uow));
            AddToCreationMethods<IProductDescriptionService>(uow => new ProductDescriptionService(uow));
            AddToCreationMethods<IProductDosageService>(uow => new ProductDosageService(uow));
            AddToCreationMethods<IProductNameService>(uow => new ProductNameService(uow));
            AddToCreationMethods<IProductService>(uow => new ProductService(uow));
            AddToCreationMethods<IRouteOfAdministrationService>(uow => new RouteOfAdministrationService(uow));
            AddToCreationMethods<ISubstanceCategoryService>(uow => new SubstanceCategoryService(uow));
            AddToCreationMethods<ISubstanceMedicinalService>(uow => new SubstanceMedicinalService(uow));
            AddToCreationMethods<ISubstanceService>(uow => new SubstanceService(uow));
            AddToCreationMethods<IUnitOfMeasureService>(uow => new UnitOfMeasureService(uow));
            
        }
    }
}