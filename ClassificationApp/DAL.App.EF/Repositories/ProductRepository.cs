using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<List<ProductDTO>> GetAllWithConnections()
        {
            return await RepositoryDbSet
                .Select(p => new ProductDTO()
                {
                    Id = p.Id,
                    ProductName = p.ProductName.ProductNameValue,
                    ProductClassification = p.ProductClassification.ProductClassificationValue,
                    RouteOfAdministration = p.RouteOfAdministration.RouteOfAdministrationValue
                })
                .ToListAsync();
        }
    }
}