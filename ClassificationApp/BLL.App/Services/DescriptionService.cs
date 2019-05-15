using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class DescriptionService : 
        BaseEntityService<BLL.App.DTO.Description, DAL.App.DTO.Description, IAppUnitOfWork>, IDescriptionService
    {
        public DescriptionService(IAppUnitOfWork uow) : base(uow, new DescriptionMapper())
        {
            ServiceRepository = Uow.Descriptions;
        }
    }
}