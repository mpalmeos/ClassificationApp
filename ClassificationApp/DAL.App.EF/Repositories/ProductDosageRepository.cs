using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.mpalmeos.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using ProductDosage = DAL.App.DTO.ProductDosage;

namespace DAL.App.EF.Repositories
{
    public class ProductDosageRepository : 
        BaseRepository<DAL.App.DTO.ProductDosage, Domain.ProductDosage, AppDbContext>, IProductDosageRepository
    {
        public ProductDosageRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new ProductDosageMapper())
        {
        }

        public override async Task<List<ProductDosage>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(c => c.Dosage)
                .Include(r => r.Product)
                .Select(e => ProductDosageMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<ProductDosage> FindAllPerEntity(int id)
        {
            var productDosage = await RepositoryDbSet
                .Include(c => c.Dosage)
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            return ProductDosageMapper.MapFromDomain(productDosage);
        }
        
    }
}