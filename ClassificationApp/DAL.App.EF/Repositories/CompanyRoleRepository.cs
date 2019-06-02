using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.mpalmeos.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using CompanyRole = DAL.App.DTO.CompanyRole;

namespace DAL.App.EF.Repositories
{
    public class CompanyRoleRepository : BaseRepository<CompanyRole, Domain.CompanyRole, AppDbContext>, ICompanyRoleRepository
    {
        public CompanyRoleRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new CompanyRoleMapper())
        {
        }

        public override async Task<List<CompanyRole>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(c => c.Company)
                .Include(r => r.CRole)
                .Select(e => CompanyRoleMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<CompanyRole> FindAllPerEntity(int id)
        {
            var companyRole = await RepositoryDbSet
                .Include(c => c.Company)
                .Include(r => r.CRole)
                .FirstOrDefaultAsync(m => m.Id == id);

            return CompanyRoleMapper.MapFromDomain(companyRole);
        }
    }
}