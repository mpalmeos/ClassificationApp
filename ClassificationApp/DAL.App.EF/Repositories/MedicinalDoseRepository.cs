using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MedicinalDoseRepository : BaseRepository<MedicinalDose>, IMedicinalDoseRepository
    {
        public MedicinalDoseRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}