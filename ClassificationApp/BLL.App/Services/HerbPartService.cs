using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class HerbPartService : BaseEntityService<HerbPart, IAppUnitOfWork>, IHerbPartService
    {
        public HerbPartService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}