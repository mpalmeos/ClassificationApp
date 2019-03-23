using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductClassificationRepository : BaseRepository<ProductClassification>, IProductClassificationRepository
    {
        public ProductClassificationRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}