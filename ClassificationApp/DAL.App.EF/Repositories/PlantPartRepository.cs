using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PlantPartRepository : BaseRepository<PlantPart>, IPlantPartRepository
    {
        public PlantPartRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}