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
    public class ProductCompanyRepository : 
        BaseRepository<DAL.App.DTO.ProductCompany, Domain.ProductCompany, AppDbContext>, IProductCompanyRepository
    {
        public ProductCompanyRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new ProductCompanyMapper())
        {
        }
        
        public async Task<List<DAL.App.DTO.ProductCompany>> AllProductsWithCompanies(int id)
        {
            return await RepositoryDbSet
                .Include(c => c.Company)
                .Include(r => r.Product)
                .Select(e => ProductCompanyMapper.MapFromDomain(e)).ToListAsync();
        }
    }
}