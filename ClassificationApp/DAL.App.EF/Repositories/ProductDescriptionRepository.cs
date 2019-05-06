using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductDescriptionRepository : 
        BaseRepository<DAL.App.DTO.ProductDescription, Domain.ProductDescription, AppDbContext>, IProductDescriptionRepository
    {
        public ProductDescriptionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new ProductDescriptionMapper())
        {
        }
        
        public async Task<List<DAL.App.DTO.ProductDescription>> AllProductsWithDescriptions(int id)
        {
            return await RepositoryDbSet
                .Include(c => c.Product)
                .Include(r => r.Description)
                .Select(e => ProductDescriptionMapper.MapFromDomain(e)).ToListAsync();
        }
    }
}