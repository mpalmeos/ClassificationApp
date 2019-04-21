using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repository;
using Domain;

namespace Contracts.BLL.App.Services
{
    public interface IProductCompositionService : IBaseEntityService<ProductComposition>, IProductCompositionRepository
    {
        
    }
}