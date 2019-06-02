using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using Domain;

namespace BLL.App.Services
{
    public class CompanyRoleService : 
        BaseEntityService<BLL.App.DTO.CompanyRole, DAL.App.DTO.CompanyRole,IAppUnitOfWork>, ICompanyRoleService
    {
        public CompanyRoleService(IAppUnitOfWork uow) : base(uow, new CompanyRoleMapper())
        {
            ServiceRepository = Uow.CompanyRoles;
        }
        
        public async Task<BLL.App.DTO.CompanyRole> FindAllPerEntity(int id)
        {
            return CompanyRoleMapper.MapFromDAL(await Uow.CompanyRoles.FindAllPerEntity(id));
        }
    }
}