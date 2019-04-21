using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class PlantFormService : BaseEntityService<PlantForm, IAppUnitOfWork>, IPlantFormService
    {
        public PlantFormService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}