using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;
using ProductDosage = BLL.App.DTO.ProductDosage;

namespace BLL.App.Services
{
    public class ProductDosageService : 
        BaseEntityService<BLL.App.DTO.ProductDosage, DAL.App.DTO.ProductDosage, IAppUnitOfWork>, IProductDosageService
    {
        public ProductDosageService(IAppUnitOfWork uow) : base(uow, new ProductDosageMapper())
        {
            ServiceRepository = Uow.ProductDosages;
        }

        public async Task<ProductDosage> FindAllPerEntity(int id)
        {
            return ProductDosageMapper.MapFromDAL(await Uow.ProductDosages.FindAllPerEntity(id));
        }
    }
}