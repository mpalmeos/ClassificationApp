using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductCompanyRepository : BaseRepository<ProductCompany, AppDbContext>, IProductCompanyRepository
    {
        public ProductCompanyRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}