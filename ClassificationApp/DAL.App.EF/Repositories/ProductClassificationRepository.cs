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
    public class ProductClassificationRepository : 
        BaseRepository<DAL.App.DTO.ProductClassification, Domain.ProductClassification, AppDbContext>, 
        IProductClassificationRepository
    {
        public ProductClassificationRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new ProductClassificationMapper())
        {
        }
        
        public async Task<List<DAL.App.DTO.ProductClassification>> AllProductsWithClassification(int id)
        {
            return await RepositoryDbSet
                .Include(c => c.Products)
                .Include(r => r.ProductClassificationValue)
                .Select(e => ProductClassificationMapper.MapFromDomain(e)).ToListAsync();
        }
    }
}