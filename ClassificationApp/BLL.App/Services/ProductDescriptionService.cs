using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;
using ProductDescription = BLL.App.DTO.ProductDescription;

namespace BLL.App.Services
{
    public class ProductDescriptionService : 
        BaseEntityService<BLL.App.DTO.ProductDescription, DAL.App.DTO.ProductDescription, IAppUnitOfWork>, IProductDescriptionService
    {
        public ProductDescriptionService(IAppUnitOfWork uow) : base(uow, new ProductDescriptionMapper())
        {
            ServiceRepository = Uow.ProductDescriptions;
        }

        public async Task<ProductDescription> FindAllPerEntity(int id)
        {
            return ProductDescriptionMapper.MapFromDAL(await Uow.ProductDescriptions.FindAllPerEntity(id));
        }
    }
}