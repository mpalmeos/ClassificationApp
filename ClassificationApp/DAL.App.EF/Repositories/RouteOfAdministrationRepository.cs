using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RouteOfAdministrationRepository : BaseRepository<RouteOfAdministration>, IRouteOfAdministrationRepository
    {
        public RouteOfAdministrationRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}