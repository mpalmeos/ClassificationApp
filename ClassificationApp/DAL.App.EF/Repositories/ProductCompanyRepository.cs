using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.mpalmeos.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using ProductCompany = DAL.App.DTO.ProductCompany;

namespace DAL.App.EF.Repositories
{
    public class ProductCompanyRepository : 
        BaseRepository<DAL.App.DTO.ProductCompany, Domain.ProductCompany, AppDbContext>, IProductCompanyRepository
    {
        public ProductCompanyRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new ProductCompanyMapper())
        {
        }

        public override async Task<List<ProductCompany>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(c => c.Company)
                .Include(r => r.Product)
                    .ThenInclude(p => p.RouteOfAdministration)
                .Include(r => r.Product)
                    .ThenInclude(n => n.ProductName)
                .Include(r => r.Product)
                    .ThenInclude(c => c.ProductClassification)
                .Select(e => ProductCompanyMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<DAL.App.DTO.ProductCompany> FindAllPerEntity(int id)
        {
            var productCompany = await RepositoryDbSet
                .Include(c => c.Company)
                .Include(r => r.Product)
                    .ThenInclude(p => p.RouteOfAdministration)
                .Include(r => r.Product)
                    .ThenInclude(n => n.ProductName)
                .Include(r => r.Product)
                    .ThenInclude(c => c.ProductClassification)
                .FirstOrDefaultAsync(m => m.Id == id);

            return ProductCompanyMapper.MapFromDomain(productCompany);
        }
    }
}