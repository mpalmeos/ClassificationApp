using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICompanyRepository Company { get; }
        ICompanyRoleRepository CompanyRole { get; }
        ICompositionHerbRepository CompositionHerb { get; }
        ICompositionRepository Composition { get; }
        ICompositionSubstanceRepository CompositionSubstance { get; }
        ICRoleRepository CRole { get; }
        IDescriptionRepository Description { get; }
        IDosageRepository Dosage { get; }
        IHerbFormRepository HerbForm { get; }
        IHerbMedicinalRepository HerbMedicinal { get; }
        IHerbPartRepository HerbPart { get; }
        IHerbRepository Herb { get; }
        IMedicinalDoseRepository MedicinalDose { get; }
        IPlantFormRepository PlantForm { get; }
        IPlantPartRepository PlantPart { get; }
        IProductClassificationRepository ProductClassification { get; }
        IProductCompanyRepository ProductCompany { get; }
        IProductCompositionRepository ProductComposition { get; }
        IProductDescriptionRepository ProductDescription { get; }
        IProductDosageRepository ProductDosage { get; }
        IProductNameRepository ProductName { get; }
        IProductRepository Product { get; }
        IRouteOfAdministrationRepository RouteOfAdministration { get; }
        ISubstanceCategoryRepository SubstanceCategory { get; }
        ISubstanceMedicinalRepository SubstanceMedicinal { get; }
        ISubstanceRepository Substance { get; }
        IUnitOfMeasureRepository UnitOfMeasure { get; }
    }
}