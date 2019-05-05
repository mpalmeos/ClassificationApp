using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBll : IBaseBll
    {
        ICompanyService Companies { get; }
        ICompanyRoleService CompanyRoles { get; }
        ICRoleService CRoles { get; }
        IDescriptionService Descriptions { get; }
        IDosageService Dosages { get; }
        IProductClassificationService ProductClassifications { get; }
        IProductCompanyService ProductCompanies { get; }
        IProductDescriptionService ProductDescriptions { get; }
        IProductDetailsService ProductDetails { get; }
        IProductDosageService ProductDosages { get; }
        IProductNameService ProductNames { get; }
        IProductOverviewService ProductOverviews { get; }
        IProductService Products { get; }
        IRouteOfAdministrationService RouteOfAdministrations { get; }
    }
}