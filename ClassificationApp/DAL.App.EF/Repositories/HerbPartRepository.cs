using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HerbPartRepository : BaseRepository<HerbPart, AppDbContext>, IHerbPartRepository
    {
        public HerbPartRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}