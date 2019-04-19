using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompanyRepository : BaseRepository<Company, AppDbContext>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}