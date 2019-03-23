using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork, IAppUnitOfWork
    {
        public AppUnitOfWork(DbContext unitOfWorkDbContext) : base(unitOfWorkDbContext)
        {
        }

        public ICategoryRepository Category { get; }
        public ICompanyRepository Company { get; }
        public ICompanyRoleRepository CompanyRole { get; }
        public ICompositionHerbRepository CompositionHerb { get; }
        public ICompositionRepository Composition { get; }
        public ICompositionSubstanceRepository CompositionSubstance { get; }
        public ICRoleRepository CRole { get; }
        public IDescriptionRepository Description { get; }
        public IDosageRepository Dosage { get; }
        public IHerbFormRepository HerbForm { get; }
        public IHerbMedicinalRepository HerbMedicinal { get; }
        public IHerbPartRepository HerbPart { get; }
        public IHerbRepository Herb { get; }
        public IMedicinalDoseRepository MedicinalDose { get; }
        public IPlantFormRepository PlantForm { get; }
        public IPlantPartRepository PlantPart { get; }
        public IProductClassificationRepository ProductClassification { get; }
        public IProductCompanyRepository ProductCompany { get; }
        public IProductCompositionRepository ProductComposition { get; }
        public IProductDescriptionRepository ProductDescription { get; }
        public IProductDosageRepository ProductDosage { get; }
        public IProductNameRepository ProductName { get; }
        public IProductRepository Product { get; }
        public IRouteOfAdministrationRepository RouteOfAdministration { get; }
        public ISubstanceCategoryRepository SubstanceCategory { get; }
        public ISubstanceMedicinalRepository SubstanceMedicinal { get; }
        public ISubstanceRepository Substance { get; }
        public IUnitOfMeasureRepository UnitOfMeasure { get; }
    }
}