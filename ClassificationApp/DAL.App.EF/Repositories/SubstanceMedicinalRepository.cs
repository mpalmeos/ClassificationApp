using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SubstanceMedicinalRepository : BaseRepository<SubstanceMedicinal>, ISubstanceMedicinalRepository
    {
        public SubstanceMedicinalRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}