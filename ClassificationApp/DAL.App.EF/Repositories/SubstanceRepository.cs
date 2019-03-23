using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SubstanceRepository : BaseRepository<Substance>, ISubstanceRepository
    {
        public SubstanceRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}