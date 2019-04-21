using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class PlantPartService : BaseEntityService<PlantPart, IAppUnitOfWork>, IPlantPartService
    {
        public PlantPartService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}