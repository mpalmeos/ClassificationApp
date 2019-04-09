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
    public class CompanyRoleRepository : BaseRepository<CompanyRole>, ICompanyRoleRepository
    {
        public CompanyRoleRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<List<CompanyRoleDTO>> GetAllWithConnections()
        {
            return await RepositoryDbSet
                .Select(cr => new CompanyRoleDTO()
                {
                    Id = cr.Id,
                    CompanyName = cr.Company.CompanyName,
                    CompanyAddress = cr.Company.CompanyAddress,
                    RoleValue = cr.CRole.RoleValue
                })
                .ToListAsync();
        }
    }
}