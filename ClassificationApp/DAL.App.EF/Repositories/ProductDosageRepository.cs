using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductDosageRepository : BaseRepository<ProductDosage, AppDbContext>, IProductDosageRepository
    {
        public ProductDosageRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}