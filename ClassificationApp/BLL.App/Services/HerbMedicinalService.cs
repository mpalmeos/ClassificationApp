using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class HerbMedicinalService : BaseEntityService<HerbMedicinal, IAppUnitOfWork>, IHerbMedicinalService
    {
        public HerbMedicinalService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}