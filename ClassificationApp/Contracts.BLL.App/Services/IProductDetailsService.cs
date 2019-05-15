using ee.itcollege.mpalmeos.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IProductDetailsService : 
        IBaseEntityService<BLLAppDTO.Customs.ProductDetails>, ICompanyRoleRepository<BLLAppDTO.Customs.ProductDetails>
    {
        
    }
}