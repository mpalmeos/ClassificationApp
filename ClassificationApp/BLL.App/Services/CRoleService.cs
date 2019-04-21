using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;

namespace BLL.App.Services
{
    public class CRoleService : BaseEntityService<CRole, IAppUnitOfWork>, ICRoleService
    {
        public CRoleService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}