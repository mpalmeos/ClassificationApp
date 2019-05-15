using ee.itcollege.mpalmeos.Contracts.DAL.Base.Repository;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IRouteOfAdministrationRepository : IRouteOfAdministrationRepository<DALAppDTO.RouteOfAdministration>
    {
        
    }

    public interface IRouteOfAdministrationRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        
    }
}