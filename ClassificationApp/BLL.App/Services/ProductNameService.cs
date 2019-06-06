using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;
using ProductName = BLL.App.DTO.ProductName;

namespace BLL.App.Services
{
    public class ProductNameService : 
        BaseEntityService<BLL.App.DTO.ProductName, DAL.App.DTO.ProductName, IAppUnitOfWork>, IProductNameService
    {
        public ProductNameService(IAppUnitOfWork uow) : base(uow, new ProductNameMapper())
        {
            ServiceRepository = Uow.ProductNames;
        }

        public async Task<ProductName> FindNameByName(string name)
        {
            return ProductNameMapper.MapFromDAL(await Uow.ProductNames.FindNameByName(name));
        }
    }
}