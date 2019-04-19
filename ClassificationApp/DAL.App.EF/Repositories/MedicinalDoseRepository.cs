using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MedicinalDoseRepository : BaseRepository<MedicinalDose, AppDbContext>, IMedicinalDoseRepository
    {
        public MedicinalDoseRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}