using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HerbMedicinalRepository : BaseRepository<HerbMedicinal, AppDbContext>, IHerbMedicinalRepository
    {
        public HerbMedicinalRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}