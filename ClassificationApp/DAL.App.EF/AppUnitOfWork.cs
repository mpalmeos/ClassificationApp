using System;
using System.Collections.Generic;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Helpers;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext dbContext, IBaseRepositoryProvider repositoryProvider) : base(dbContext, repositoryProvider)
        {
        }
        
        public ICategoryRepository Categories => 
            _repositoryProvider.GetRepository<ICategoryRepository>();
        
        public ICompanyRepository Companies => 
            _repositoryProvider.GetRepository<ICompanyRepository>();
        
        public ICompanyRoleRepository CompanyRoles => 
            _repositoryProvider.GetRepository<ICompanyRoleRepository>();
        
        public ICompositionHerbRepository CompositionHerbs => 
            _repositoryProvider.GetRepository<ICompositionHerbRepository>();
        
        public ICompositionRepository Compositions => 
            _repositoryProvider.GetRepository<ICompositionRepository>();

        public ICompositionSubstanceRepository CompositionSubstances =>
            _repositoryProvider.GetRepository<ICompositionSubstanceRepository>();

        public ICRoleRepository CRoles =>
            _repositoryProvider.GetRepository<ICRoleRepository>();

        public IDescriptionRepository Descriptions =>
            _repositoryProvider.GetRepository<IDescriptionRepository>();

        public IDosageRepository Dosages =>
            _repositoryProvider.GetRepository<IDosageRepository>();

        public IHerbFormRepository HerbForms =>
            _repositoryProvider.GetRepository<IHerbFormRepository>();

        public IHerbMedicinalRepository HerbMedicinals =>
            _repositoryProvider.GetRepository<IHerbMedicinalRepository>();

        public IHerbPartRepository HerbParts =>
            _repositoryProvider.GetRepository<IHerbPartRepository>();

        public IHerbRepository Herbs =>
            _repositoryProvider.GetRepository<IHerbRepository>();

        public IMedicinalDoseRepository MedicinalDoses =>
            _repositoryProvider.GetRepository<IMedicinalDoseRepository>();

        public IPlantFormRepository PlantForms =>
            _repositoryProvider.GetRepository<IPlantFormRepository>();

        public IPlantPartRepository PlantParts =>
            _repositoryProvider.GetRepository<IPlantPartRepository>();

        public IProductClassificationRepository ProductClassifications =>
            _repositoryProvider.GetRepository<IProductClassificationRepository>();

        public IProductCompanyRepository ProductCompanies =>
            _repositoryProvider.GetRepository<IProductCompanyRepository>();

        public IProductCompositionRepository ProductCompositions =>
            _repositoryProvider.GetRepository<IProductCompositionRepository>();

        public IProductDescriptionRepository ProductDescriptions =>
            _repositoryProvider.GetRepository<IProductDescriptionRepository>();

        public IProductDosageRepository ProductDosages =>
            _repositoryProvider.GetRepository<IProductDosageRepository>();

        public IProductNameRepository ProductNames =>
            _repositoryProvider.GetRepository<IProductNameRepository>();

        public IProductRepository Products =>
            _repositoryProvider.GetRepository<IProductRepository>();

        public IRouteOfAdministrationRepository RouteOfAdministrations =>
            _repositoryProvider.GetRepository<IRouteOfAdministrationRepository>();

        public ISubstanceCategoryRepository SubstanceCategories =>
            _repositoryProvider.GetRepository<ISubstanceCategoryRepository>();

        public ISubstanceMedicinalRepository SubstanceMedicinals =>
            _repositoryProvider.GetRepository<ISubstanceMedicinalRepository>();

        public ISubstanceRepository Substances =>
            _repositoryProvider.GetRepository<ISubstanceRepository>();

        public IUnitOfMeasureRepository UnitOfMeasures =>
            _repositoryProvider.GetRepository<IUnitOfMeasureRepository>();
    }
}