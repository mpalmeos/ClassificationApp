using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductRepository : 
        BaseRepository<DAL.App.DTO.Product, Domain.Product, AppDbContext>, IProductRepository
    {
        public ProductRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new ProductMapper())
        {
        }
        
        public async Task<List<DAL.App.DTO.Product>> AllBasicProducts()
        {
            return await RepositoryDbSet
                .Include(c => c.ProductClassification)
                .Include(r => r.ProductName)
                .Include(a => a.RouteOfAdministration)
                .Select(e => ProductMapper.MapFromDomain(e)).ToListAsync();
        }
    }
}