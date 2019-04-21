using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBll : IBaseBll
    {
        ICategoryService Categories { get; }
        ICompanyService Companies { get; }
        ICompanyRoleService CompanyRoles { get; }
        ICompositionHerbService CompositionHerbs { get; }
        ICompositionService Compositions { get; }
        ICompositionSubstanceService CompositionSubstances { get; }
        ICRoleService CRoles { get; }
        IDescriptionService Descriptions { get; }
        IDosageService Dosages { get; }
        IHerbFormService HerbForms { get; }
        IHerbMedicinalService HerbMedicinals { get; }
        IHerbPartService HerbParts { get; }
        IHerbService Herbs { get; }
        IMedicinalDoseService MedicinalDoses { get; }
        IPlantFormService PlantForms { get; }
        IPlantPartService PlantParts { get; }
        IProductClassificationService ProductClassifications { get; }
        IProductCompanyService ProductCompanies { get; }
        IProductCompositionService ProductCompositions { get; }
        IProductDescriptionService ProductDescriptions { get; }
        IProductDosageService ProductDosages { get; }
        IProductNameService ProductNames { get; }
        IProductService Products { get; }
        IRouteOfAdministrationService RouteOfAdministrations { get; }
        ISubstanceCategoryService SubstanceCategories { get; }
        ISubstanceMedicinalService SubstanceMedicinals { get; }
        ISubstanceService Substances { get; }
        IUnitOfMeasureService UnitOfMeasures { get; }
    }
}