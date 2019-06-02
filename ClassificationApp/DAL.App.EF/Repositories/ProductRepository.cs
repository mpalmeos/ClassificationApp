using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.mpalmeos.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Product = DAL.App.DTO.Product;
using ProductClassification = DAL.App.DTO.ProductClassification;

namespace DAL.App.EF.Repositories
{
    public class ProductRepository : 
        BaseRepository<DAL.App.DTO.Product, Domain.Product, AppDbContext>, IProductRepository
    {
        public ProductRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new ProductMapper())
        {
        }

        public override async Task<List<Product>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(r => r.RouteOfAdministration)
                .Include(c => c.ProductClassification)
                .Include(n => n.ProductName)
                .Select(e => ProductMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<Product> FindAllPerEntity(int id)
        {
            var product = await RepositoryDbSet
                .Include(r => r.RouteOfAdministration)
                .Include(c => c.ProductClassification)
                .Include(n => n.ProductName)
                .FirstOrDefaultAsync(m => m.Id == id);

            return ProductMapper.MapFromDomain(product);
        }
    }
}