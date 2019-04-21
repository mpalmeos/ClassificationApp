using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repository;
using DAL.App.DTO;
using Domain;

namespace Contracts.BLL.App.Services
{
    public interface ICompanyRoleService : IBaseEntityService<CompanyRole>, ICompanyRoleRepository
    {
        
    }
}