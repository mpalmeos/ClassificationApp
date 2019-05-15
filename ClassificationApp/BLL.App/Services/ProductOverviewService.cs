using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Mappers;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class ProductOverviewService :
        BaseEntityService<BLL.App.DTO.Customs.ProductOverview, DAL.App.DTO.Customs.ProductOverview, IAppUnitOfWork>, IProductOverviewService
    {
        public ProductOverviewService(IAppUnitOfWork uow) : base(uow, new ProductOverviewMapper())
        {
            ServiceRepository = Uow.ProductOverviews;
        }
    }
}