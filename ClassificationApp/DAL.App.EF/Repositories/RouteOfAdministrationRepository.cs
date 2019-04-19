using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RouteOfAdministrationRepository : BaseRepository<RouteOfAdministration, AppDbContext>, IRouteOfAdministrationRepository
    {
        public RouteOfAdministrationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}