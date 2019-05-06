using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompanyRoleRepository : BaseRepository<DAL.App.DTO.CompanyRole, Domain.CompanyRole, AppDbContext>, ICompanyRoleRepository
    {
        public CompanyRoleRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new CompanyRoleMapper())
        {
        }

        public async Task<List<DAL.App.DTO.CompanyRole>> AllCompaniesWithRoles(int id)
        {
            return await RepositoryDbSet
                .Include(c => c.Company)
                .Include(r => r.CRole)
                .Select(e => CompanyRoleMapper.MapFromDomain(e)).ToListAsync();
        }
    }
}