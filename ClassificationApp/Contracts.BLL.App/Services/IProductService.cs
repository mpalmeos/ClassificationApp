using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repository;
using DAL.App.DTO;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IProductService : IBaseEntityService<BLLAppDTO.Product>, IProductRepository<BLLAppDTO.Product>
    {
        
    }
}