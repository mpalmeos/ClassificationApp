using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Helpers;
using Contracts.DAL.App;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBll
    {
        protected readonly IAppUnitOfWork AppUnitOfWork;
        
        public AppBLL(IAppUnitOfWork appUnitOfWork, IBaseServiceProvider serviceProvider) : base(appUnitOfWork, serviceProvider)
        {
            AppUnitOfWork = appUnitOfWork;
        }
        
        public ICategoryService Categories => 
            ServiceProvider.GetService<ICategoryService>();
        
        public ICompanyService Companies => 
            ServiceProvider.GetService<ICompanyService>();
        
        public ICompanyRoleService CompanyRoles => 
            ServiceProvider.GetService<ICompanyRoleService>();
        
        public ICompositionHerbService CompositionHerbs => 
            ServiceProvider.GetService<ICompositionHerbService>();
        
        public ICompositionService Compositions => 
            ServiceProvider.GetService<ICompositionService>();

        public ICompositionSubstanceService CompositionSubstances =>
            ServiceProvider.GetService<ICompositionSubstanceService>();

        public ICRoleService CRoles =>
            ServiceProvider.GetService<ICRoleService>();

        public IDescriptionService Descriptions =>
            ServiceProvider.GetService<IDescriptionService>();

        public IDosageService Dosages =>
            ServiceProvider.GetService<IDosageService>();

        public IHerbFormService HerbForms =>
            ServiceProvider.GetService<IHerbFormService>();

        public IHerbMedicinalService HerbMedicinals =>
            ServiceProvider.GetService<IHerbMedicinalService>();

        public IHerbPartService HerbParts =>
            ServiceProvider.GetService<IHerbPartService>();

        public IHerbService Herbs =>
            ServiceProvider.GetService<IHerbService>();

        public IMedicinalDoseService MedicinalDoses =>
            ServiceProvider.GetService<IMedicinalDoseService>();

        public IPlantFormService PlantForms =>
            ServiceProvider.GetService<IPlantFormService>();

        public IPlantPartService PlantParts =>
            ServiceProvider.GetService<IPlantPartService>();

        public IProductClassificationService ProductClassifications =>
            ServiceProvider.GetService<IProductClassificationService>();

        public IProductCompanyService ProductCompanies =>
            ServiceProvider.GetService<IProductCompanyService>();

        public IProductCompositionService ProductCompositions =>
            ServiceProvider.GetService<IProductCompositionService>();

        public IProductDescriptionService ProductDescriptions =>
            ServiceProvider.GetService<IProductDescriptionService>();

        public IProductDosageService ProductDosages =>
            ServiceProvider.GetService<IProductDosageService>();

        public IProductNameService ProductNames =>
            ServiceProvider.GetService<IProductNameService>();

        public IProductService Products =>
            ServiceProvider.GetService<IProductService>();

        public IRouteOfAdministrationService RouteOfAdministrations =>
            ServiceProvider.GetService<IRouteOfAdministrationService>();

        public ISubstanceCategoryService SubstanceCategories =>
            ServiceProvider.GetService<ISubstanceCategoryService>();

        public ISubstanceMedicinalService SubstanceMedicinals =>
            ServiceProvider.GetService<ISubstanceMedicinalService>();

        public ISubstanceService Substances =>
            ServiceProvider.GetService<ISubstanceService>();

        public IUnitOfMeasureService UnitOfMeasures =>
            ServiceProvider.GetService<IUnitOfMeasureService>();
    }
}