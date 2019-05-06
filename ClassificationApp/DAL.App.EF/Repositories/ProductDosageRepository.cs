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
    public class ProductDosageRepository : 
        BaseRepository<DAL.App.DTO.ProductDosage, Domain.ProductDosage, AppDbContext>, IProductDosageRepository
    {
        public ProductDosageRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new ProductDosageMapper())
        {
        }
        
        public async Task<List<DAL.App.DTO.ProductDosage>> AllProductsWithDosages(int id)
        {
            return await RepositoryDbSet
                .Include(c => c.Dosage)
                .Include(r => r.Product)
                .Select(e => ProductDosageMapper.MapFromDomain(e)).ToListAsync();
        }
    }
}