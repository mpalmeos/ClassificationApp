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

        public ICompanyRepository Companies => 
            _repositoryProvider.GetRepository<ICompanyRepository>();
        
        public ICompanyRoleRepository CompanyRoles => 
            _repositoryProvider.GetRepository<ICompanyRoleRepository>();

        public ICRoleRepository CRoles =>
            _repositoryProvider.GetRepository<ICRoleRepository>();

        public IDescriptionRepository Descriptions =>
            _repositoryProvider.GetRepository<IDescriptionRepository>();

        public IDosageRepository Dosages =>
            _repositoryProvider.GetRepository<IDosageRepository>();
        
        public IProductClassificationRepository ProductClassifications =>
            _repositoryProvider.GetRepository<IProductClassificationRepository>();

        public IProductCompanyRepository ProductCompanies =>
            _repositoryProvider.GetRepository<IProductCompanyRepository>();

        public IProductDescriptionRepository ProductDescriptions =>
            _repositoryProvider.GetRepository<IProductDescriptionRepository>();
        
        public IProductDetailsRepository ProductDetails =>
            _repositoryProvider.GetRepository<IProductDetailsRepository>();

        public IProductDosageRepository ProductDosages =>
            _repositoryProvider.GetRepository<IProductDosageRepository>();

        public IProductNameRepository ProductNames =>
            _repositoryProvider.GetRepository<IProductNameRepository>();
        
        public IProductOverviewRepository ProductOverviews =>
            _repositoryProvider.GetRepository<IProductOverviewRepository>();

        public IProductRepository Products =>
            _repositoryProvider.GetRepository<IProductRepository>();

        public IRouteOfAdministrationRepository RouteOfAdministrations =>
            _repositoryProvider.GetRepository<IRouteOfAdministrationRepository>();

    }
}