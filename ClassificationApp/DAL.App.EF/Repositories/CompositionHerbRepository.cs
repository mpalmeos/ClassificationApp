using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompositionHerbRepository : BaseRepository<CompositionHerb,AppDbContext>, ICompositionHerbRepository
    {
        public CompositionHerbRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}