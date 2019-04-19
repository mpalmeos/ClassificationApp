using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompositionSubstanceRepository : BaseRepository<CompositionSubstance, AppDbContext>, ICompositionSubstanceRepository
    {
        public CompositionSubstanceRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}