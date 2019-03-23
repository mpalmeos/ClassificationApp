using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompositionSubstanceRepository : BaseRepository<CompositionSubstance>, ICompositionSubstanceRepository
    {
        public CompositionSubstanceRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}