using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductCompanyRepository : BaseRepository<ProductCompany>, IProductCompanyRepository
    {
        public ProductCompanyRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}