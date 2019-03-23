using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompanyRoleRepository : BaseRepository<CompanyRole>, ICompanyRoleRepository
    {
        public CompanyRoleRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}