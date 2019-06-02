using System.Threading.Tasks;
using BLL.App.DTO.Customs;
using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Mappers;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class ProductDetailsService :
        BaseEntityService<BLL.App.DTO.Customs.ProductDetails, DAL.App.DTO.Customs.ProductDetails, IAppUnitOfWork>, IProductDetailsService
    {
        public ProductDetailsService(IAppUnitOfWork uow) : base(uow, new ProductDetailsMapper())
        {
            ServiceRepository = Uow.ProductDetails;
        }

        public Task<ProductDetails> FindAllPerEntity(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}