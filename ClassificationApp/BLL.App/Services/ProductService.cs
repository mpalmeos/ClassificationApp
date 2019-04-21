using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.DTO;
using Domain;

namespace BLL.App.Services
{
    public class ProductService : BaseEntityService<Product, IAppUnitOfWork>, IProductService
    {
        public ProductService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public Task<List<ProductDTO>> GetAllWithConnections()
        {
            throw new System.NotImplementedException();
        }
    }
}