using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductDosageRepository : BaseRepository<ProductDosage>, IProductDosageRepository
    {
        public ProductDosageRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}