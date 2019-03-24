using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        ICompanyRepository Companies { get; }
        ICompanyRoleRepository CompanyRoles { get; }
        ICompositionHerbRepository CompositionHerbs { get; }
        ICompositionRepository Compositions { get; }
        ICompositionSubstanceRepository CompositionSubstances { get; }
        ICRoleRepository CRoles { get; }
        IDescriptionRepository Descriptions { get; }
        IDosageRepository Dosages { get; }
        IHerbFormRepository HerbForms { get; }
        IHerbMedicinalRepository HerbMedicinals { get; }
        IHerbPartRepository HerbParts { get; }
        IHerbRepository Herbs { get; }
        IMedicinalDoseRepository MedicinalDoses { get; }
        IPlantFormRepository PlantForms { get; }
        IPlantPartRepository PlantParts { get; }
        IProductClassificationRepository ProductClassifications { get; }
        IProductCompanyRepository ProductCompanies { get; }
        IProductCompositionRepository ProductCompositions { get; }
        IProductDescriptionRepository ProductDescriptions { get; }
        IProductDosageRepository ProductDosages { get; }
        IProductNameRepository ProductNames { get; }
        IProductRepository Products { get; }
        IRouteOfAdministrationRepository RouteOfAdministrations { get; }
        ISubstanceCategoryRepository SubstanceCategories { get; }
        ISubstanceMedicinalRepository SubstanceMedicinals { get; }
        ISubstanceRepository Substances { get; }
        IUnitOfMeasureRepository UnitOfMeasures { get; }
    }
}