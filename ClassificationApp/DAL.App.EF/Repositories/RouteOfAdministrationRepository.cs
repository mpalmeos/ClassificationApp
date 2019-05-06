using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RouteOfAdministrationRepository : 
        BaseRepository<DAL.App.DTO.RouteOfAdministration, Domain.RouteOfAdministration, AppDbContext>, 
        IRouteOfAdministrationRepository
    {
        public RouteOfAdministrationRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new RouteOfAdministrationMapper())
        {
        }
    }
}