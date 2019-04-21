using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SubstanceService : BaseEntityService<Substance, IAppUnitOfWork>, ISubstanceService
    {
        public SubstanceService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}