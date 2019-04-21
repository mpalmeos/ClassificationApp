using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class DosageService : BaseEntityService<Dosage, IAppUnitOfWork>, IDosageService
    {
        public DosageService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}