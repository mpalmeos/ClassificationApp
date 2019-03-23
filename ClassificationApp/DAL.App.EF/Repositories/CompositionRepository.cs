using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompositionRepository : BaseRepository<Composition>, ICompositionRepository
    {
        public CompositionRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}