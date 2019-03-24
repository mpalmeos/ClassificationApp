using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductDescriptionRepository : BaseRepository<ProductDescription>, IProductDescriptionRepository
    {
        public ProductDescriptionRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}