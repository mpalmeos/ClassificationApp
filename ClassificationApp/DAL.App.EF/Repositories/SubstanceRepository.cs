using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SubstanceRepository : BaseRepository<Substance,AppDbContext>, ISubstanceRepository
    {
        public SubstanceRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}