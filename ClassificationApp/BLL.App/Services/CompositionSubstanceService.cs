using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;

namespace BLL.App.Services
{
    public class CompositionSubstanceService : BaseEntityService<CompositionSubstance, IAppUnitOfWork>, ICompositionSubstanceService
    {
        public CompositionSubstanceService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}