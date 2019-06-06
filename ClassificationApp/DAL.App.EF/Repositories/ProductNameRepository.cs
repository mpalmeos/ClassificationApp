using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.mpalmeos.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductNameRepository : 
        BaseRepository<DAL.App.DTO.ProductName, Domain.ProductName, AppDbContext>, IProductNameRepository
    {
        public ProductNameRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new ProductNameMapper())
        {
        }
        
        public async Task<List<DAL.App.DTO.ProductName>> AllProductsWithNames(int id)
        {
            return await RepositoryDbSet
                .Include(c => c.Products)
                .Include(r => r.ProductNameValue)
                .Select(e => ProductNameMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<DAL.App.DTO.ProductName> FindNameByName(string name)
        {
            var productName = await RepositoryDbSet
                .Include(r => r.ProductNameValue)
                .FirstOrDefaultAsync(m => name.Trim().Equals(m.ProductNameValue));

            return ProductNameMapper.MapFromDomain(productName);
        }
    }
}