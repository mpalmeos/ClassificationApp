using ee.itcollege.mpalmeos.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using ee.itcollege.mpalmeos.Contracts.DAL.Base.Repository;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IProductDosageService : IBaseEntityService<BLLAppDTO.ProductDosage>, IProductDosageRepository<BLLAppDTO.ProductDosage>
    {
        
    }
}