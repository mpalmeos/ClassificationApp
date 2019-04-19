using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HerbFormRepository : BaseRepository<HerbForm, AppDbContext>, IHerbFormRepository
    {
        public HerbFormRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}