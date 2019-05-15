using Contracts.DAL.App.Repositories;
using ee.itcollege.mpalmeos.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        ICompanyRepository Companies { get; }
        ICompanyRoleRepository CompanyRoles { get; }
        ICRoleRepository CRoles { get; }
        IDescriptionRepository Descriptions { get; }
        IDosageRepository Dosages { get; }
        IProductClassificationRepository ProductClassifications { get; }
        IProductCompanyRepository ProductCompanies { get; }
        IProductDescriptionRepository ProductDescriptions { get; }
        IProductDetailsRepository ProductDetails { get; }
        IProductDosageRepository ProductDosages { get; }
        IProductNameRepository ProductNames { get; }
        IProductOverviewRepository ProductOverviews { get; }
        IProductRepository Products { get; }
        IRouteOfAdministrationRepository RouteOfAdministrations { get; }
    }
}