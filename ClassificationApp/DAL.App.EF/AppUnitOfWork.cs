using System;
using System.Collections.Generic;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork, IAppUnitOfWork
    {
        private Dictionary<Type, object> _repositoryCache = new Dictionary<Type, object>();
        
        public AppUnitOfWork(AppDbContext unitOfWorkDbContext) : base(unitOfWorkDbContext)
        {
        }
        
        private TRepo GetOrCreateRepository<TRepo>(Func<AppDbContext, TRepo> repoCreationMethod)
        {
            if (_repositoryCache.ContainsKey(typeof(TRepo)))
            {
                return (TRepo) _repositoryCache[typeof(TRepo)];
            }

            var repoObj = repoCreationMethod((AppDbContext) UnitOfWorkDbContext);
            _repositoryCache.Add(typeof(TRepo), repoObj);
            return repoObj;
        }

        public ICategoryRepository Categories =>
            GetOrCreateRepository<ICategoryRepository>(dbContext => new CategoryRepository(dbContext));

        public ICompanyRepository Companies =>
            GetOrCreateRepository<ICompanyRepository>(ctx => new CompanyRepository(ctx));

        public ICompanyRoleRepository CompanyRoles =>
            GetOrCreateRepository<ICompanyRoleRepository>(ctx => new CompanyRoleRepository(ctx));

        public ICompositionHerbRepository CompositionHerbs =>
            GetOrCreateRepository<ICompositionHerbRepository>(ctx => new CompositionHerbRepository(ctx));

        public ICompositionRepository Compositions =>
            GetOrCreateRepository<ICompositionRepository>(ctx => new CompositionRepository(ctx));

        public ICompositionSubstanceRepository CompositionSubstances =>
            GetOrCreateRepository<ICompositionSubstanceRepository>(ctx => new CompositionSubstanceRepository(ctx));

        public ICRoleRepository CRoles =>
            GetOrCreateRepository<ICRoleRepository>(ctx => new CRoleRepository(ctx));

        public IDescriptionRepository Descriptions =>
            GetOrCreateRepository<IDescriptionRepository>(ctx => new DescriptionRepository(ctx));

        public IDosageRepository Dosages =>
            GetOrCreateRepository<IDosageRepository>(ctx => new DosageRepository(ctx));

        public IHerbFormRepository HerbForms =>
            GetOrCreateRepository<IHerbFormRepository>(ctx => new HerbFormRepository(ctx));

        public IHerbMedicinalRepository HerbMedicinals =>
            GetOrCreateRepository<IHerbMedicinalRepository>(ctx => new HerbMedicinalRepository(ctx));

        public IHerbPartRepository HerbParts =>
            GetOrCreateRepository<IHerbPartRepository>(ctx => new HerbPartRepository(ctx));

        public IHerbRepository Herbs =>
            GetOrCreateRepository<IHerbRepository>(ctx => new HerbRepository(ctx));

        public IMedicinalDoseRepository MedicinalDoses =>
            GetOrCreateRepository<IMedicinalDoseRepository>(ctx => new MedicinalDoseRepository(ctx));

        public IPlantFormRepository PlantForms =>
            GetOrCreateRepository<IPlantFormRepository>(ctx => new PlantFormRepository(ctx));

        public IPlantPartRepository PlantParts =>
            GetOrCreateRepository<IPlantPartRepository>(ctx => new PlantPartRepository(ctx));

        public IProductClassificationRepository ProductClassifications =>
            GetOrCreateRepository<IProductClassificationRepository>(ctx => new ProductClassificationRepository(ctx));

        public IProductCompanyRepository ProductCompanies =>
            GetOrCreateRepository<IProductCompanyRepository>(ctx => new ProductCompanyRepository(ctx));

        public IProductCompositionRepository ProductCompositions =>
            GetOrCreateRepository<IProductCompositionRepository>(ctx => new ProductCompositionRepository(ctx));

        public IProductDescriptionRepository ProductDescriptions =>
            GetOrCreateRepository<IProductDescriptionRepository>(ctx => new ProductDescriptionRepository(ctx));

        public IProductDosageRepository ProductDosages =>
            GetOrCreateRepository<IProductDosageRepository>(ctx => new ProductDosageRepository(ctx));

        public IProductNameRepository ProductNames =>
            GetOrCreateRepository<IProductNameRepository>(ctx => new ProductNameRepository(ctx));

        public IProductRepository Products =>
            GetOrCreateRepository<IProductRepository>(ctx => new ProductRepository(ctx));

        public IRouteOfAdministrationRepository RouteOfAdministrations =>
            GetOrCreateRepository<IRouteOfAdministrationRepository>(ctx => new RouteOfAdministrationRepository(ctx));

        public ISubstanceCategoryRepository SubstanceCategories =>
            GetOrCreateRepository<ISubstanceCategoryRepository>(ctx => new SubstanceCategoryRepository(ctx));

        public ISubstanceMedicinalRepository SubstanceMedicinals =>
            GetOrCreateRepository<ISubstanceMedicinalRepository>(ctx => new SubstanceMedicinalRepository(ctx));

        public ISubstanceRepository Substances =>
            GetOrCreateRepository<ISubstanceRepository>(ctx => new SubstanceRepository(ctx));

        public IUnitOfMeasureRepository UnitOfMeasures =>
            GetOrCreateRepository<IUnitOfMeasureRepository>(ctx => new UnitOfMeasureRepository(ctx));
    }
}