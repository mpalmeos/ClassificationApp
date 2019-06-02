using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.DTO;
using Domain;
using Product = BLL.App.DTO.Product;

namespace BLL.App.Services
{
    public class ProductService : 
        BaseEntityService<BLL.App.DTO.Product, DAL.App.DTO.Product, IAppUnitOfWork>, IProductService
    {
        public ProductService(IAppUnitOfWork uow) : base(uow, new ProductMapper())
        {
            ServiceRepository = Uow.Products;
        }

        public async Task<Product> FindAllPerEntity(int id)
        {
            return ProductMapper.MapFromDAL(await Uow.Products.FindAllPerEntity(id));
        }
    }
}