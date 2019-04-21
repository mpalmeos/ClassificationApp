using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SubstanceMedicinalService : BaseEntityService<SubstanceMedicinal, IAppUnitOfWork>, ISubstanceMedicinalService
    {
        public SubstanceMedicinalService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}