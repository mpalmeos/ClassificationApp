using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SubstanceMedicinalRepository : BaseRepository<SubstanceMedicinal, AppDbContext>, ISubstanceMedicinalRepository
    {
        public SubstanceMedicinalRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}