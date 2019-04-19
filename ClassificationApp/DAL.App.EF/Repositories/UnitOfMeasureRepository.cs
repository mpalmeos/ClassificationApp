using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UnitOfMeasureRepository : BaseRepository<UnitOfMeasure,AppDbContext>, IUnitOfMeasureRepository
    {
        public UnitOfMeasureRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}