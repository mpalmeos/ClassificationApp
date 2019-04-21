using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;

namespace BLL.App.Services
{
    public class HerbService : BaseEntityService<Herb, IAppUnitOfWork>, IHerbService
    {
        public HerbService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}