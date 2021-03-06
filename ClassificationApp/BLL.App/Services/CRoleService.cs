using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;

namespace BLL.App.Services
{
    public class CRoleService : 
        BaseEntityService<BLL.App.DTO.CRole, DAL.App.DTO.CRole, IAppUnitOfWork>, ICRoleService
    {
        public CRoleService(IAppUnitOfWork uow) : base(uow, new CRoleMapper())
        {
            ServiceRepository = Uow.CRoles;
        }
    }
}