using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using ee.itcollege.mpalmeos.Contracts.DAL.Base.Repository;
using DAL.App.DTO;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface ICompanyRoleService : 
        IBaseEntityService<BLLAppDTO.CompanyRole>, ICompanyRoleRepository<BLLAppDTO.CompanyRole>
    {
        
    }
}