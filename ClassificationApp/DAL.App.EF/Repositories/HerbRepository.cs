using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HerbRepository : BaseRepository<Herb, AppDbContext>, IHerbRepository
    {
        public HerbRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}