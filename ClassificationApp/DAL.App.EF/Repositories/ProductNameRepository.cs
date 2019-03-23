using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductNameRepository : BaseRepository<ProductName>, IProductNameRepository
    {
        public ProductNameRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}