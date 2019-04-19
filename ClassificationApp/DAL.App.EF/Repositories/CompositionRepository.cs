using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompositionRepository : BaseRepository<Composition, AppDbContext>, ICompositionRepository
    {
        public CompositionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}