using ee.itcollege.mpalmeos.BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Helpers;
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

        public ICompanyService Companies => 
            ServiceProvider.GetService<ICompanyService>();
        
        public ICompanyRoleService CompanyRoles => 
            ServiceProvider.GetService<ICompanyRoleService>();

        public ICRoleService CRoles =>
            ServiceProvider.GetService<ICRoleService>();

        public IDescriptionService Descriptions =>
            ServiceProvider.GetService<IDescriptionService>();

        public IDosageService Dosages =>
            ServiceProvider.GetService<IDosageService>();

        public IProductClassificationService ProductClassifications =>
            ServiceProvider.GetService<IProductClassificationService>();

        public IProductCompanyService ProductCompanies =>
            ServiceProvider.GetService<IProductCompanyService>();

        public IProductDescriptionService ProductDescriptions =>
            ServiceProvider.GetService<IProductDescriptionService>();

        public IProductDetailsService ProductDetails =>
            ServiceProvider.GetService<IProductDetailsService>();

        public IProductDosageService ProductDosages =>
            ServiceProvider.GetService<IProductDosageService>();

        public IProductNameService ProductNames =>
            ServiceProvider.GetService<IProductNameService>();

        public IProductOverviewService ProductOverviews =>
            ServiceProvider.GetService<IProductOverviewService>();

        public IProductService Products =>
            ServiceProvider.GetService<IProductService>();

        public IRouteOfAdministrationService RouteOfAdministrations =>
            ServiceProvider.GetService<IRouteOfAdministrationService>();
    }
}