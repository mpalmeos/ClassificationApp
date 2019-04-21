using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class RouteOfAdministrationService : BaseEntityService<RouteOfAdministration, IAppUnitOfWork>, IRouteOfAdministrationService
    {
        public RouteOfAdministrationService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}