using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DosageRepository : BaseRepository<Dosage, AppDbContext>, IDosageRepository
    {
        public DosageRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}