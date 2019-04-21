using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;

namespace BLL.App.Services
{
    public class CompositionService : BaseEntityService<Composition, IAppUnitOfWork>, ICompositionService
    {
        public CompositionService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}