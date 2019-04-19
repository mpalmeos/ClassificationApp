using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductClassificationRepository : BaseRepository<ProductClassification, AppDbContext>, IProductClassificationRepository
    {
        public ProductClassificationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}