using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductNameRepository : BaseRepository<ProductName, AppDbContext>, IProductNameRepository
    {
        public ProductNameRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}