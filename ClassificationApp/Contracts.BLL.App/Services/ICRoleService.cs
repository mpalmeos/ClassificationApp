using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repository;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface ICRoleService : IBaseEntityService<BLLAppDTO.CRole>, ICRoleRepository<BLLAppDTO.CRole>
    {
        
    }
}