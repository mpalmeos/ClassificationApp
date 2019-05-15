using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class RouteOfAdministrationService : 
        BaseEntityService<BLL.App.DTO.RouteOfAdministration, DAL.App.DTO.RouteOfAdministration, IAppUnitOfWork>, IRouteOfAdministrationService
    {
        public RouteOfAdministrationService(IAppUnitOfWork uow) : base(uow, new RouteOfAdministrationMapper())
        {
            ServiceRepository = Uow.RouteOfAdministrations;
        }
    }
}