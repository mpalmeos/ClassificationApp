using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HerbPartRepository : BaseRepository<HerbPart>, IHerbPartRepository
    {
        public HerbPartRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}