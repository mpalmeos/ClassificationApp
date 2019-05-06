using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DosageRepository : BaseRepository<DAL.App.DTO.Dosage, Domain.Dosage, AppDbContext>, IDosageRepository
    {
        public DosageRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new DosageMapper())
        {
        }
    }
}