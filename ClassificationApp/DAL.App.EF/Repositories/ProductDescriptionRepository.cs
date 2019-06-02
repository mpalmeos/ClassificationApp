using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.mpalmeos.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using ProductDescription = DAL.App.DTO.ProductDescription;

namespace DAL.App.EF.Repositories
{
    public class ProductDescriptionRepository : 
        BaseRepository<DAL.App.DTO.ProductDescription, Domain.ProductDescription, AppDbContext>, IProductDescriptionRepository
    {
        public ProductDescriptionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new ProductDescriptionMapper())
        {
        }

        public override async Task<List<ProductDescription>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(c => c.Product)
                .Include(r => r.Description)
                .Select(e => ProductDescriptionMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<ProductDescription> FindAllPerEntity(int id)
        {
            var productDescription = await RepositoryDbSet
                .Include(c => c.Product)
                .Include(r => r.Description)
                .FirstOrDefaultAsync(m => m.Id == id);

            return ProductDescriptionMapper.MapFromDomain(productDescription);
        }
        
    }
}