using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;

namespace BLL.App.Services
{
    public class CompositionHerbService : BaseEntityService<CompositionHerb, IAppUnitOfWork>, ICompositionHerbService
    {
        public CompositionHerbService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}