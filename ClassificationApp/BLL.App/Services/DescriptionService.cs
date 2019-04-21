using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class DescriptionService : BaseEntityService<Description, IAppUnitOfWork>, IDescriptionService
    {
        public DescriptionService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}