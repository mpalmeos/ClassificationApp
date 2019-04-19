using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductDescriptionRepository : BaseRepository<ProductDescription, AppDbContext>, IProductDescriptionRepository
    {
        public ProductDescriptionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}