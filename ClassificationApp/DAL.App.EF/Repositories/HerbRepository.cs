using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HerbRepository : BaseRepository<Herb>, IHerbRepository
    {
        public HerbRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}