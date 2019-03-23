using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PlantFormRepository : BaseRepository<PlantForm>, IPlantFormRepository
    {
        public PlantFormRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}