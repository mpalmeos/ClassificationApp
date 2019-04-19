using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PlantFormRepository : BaseRepository<PlantForm, AppDbContext>, IPlantFormRepository
    {
        public PlantFormRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}