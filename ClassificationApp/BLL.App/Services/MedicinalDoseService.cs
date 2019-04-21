using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class MedicinalDoseService : BaseEntityService<MedicinalDose, IAppUnitOfWork>, IMedicinalDoseService
    {
        public MedicinalDoseService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}