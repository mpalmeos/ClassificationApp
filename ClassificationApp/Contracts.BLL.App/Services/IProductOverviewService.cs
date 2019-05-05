using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IProductOverviewService : 
        IBaseEntityService<BLLAppDTO.Customs.ProductOverview>, IProductOverviewRepository<BLLAppDTO.Customs.ProductOverview>
    {
        
    }
}