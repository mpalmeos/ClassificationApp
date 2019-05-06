using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class DosageService : 
        BaseEntityService<BLL.App.DTO.Dosage, DAL.App.DTO.Dosage, IAppUnitOfWork>, IDosageService
    {
        public DosageService(IAppUnitOfWork uow) : base(uow, new DosageMapper())
        {
            ServiceRepository = Uow.Dosages;
        }
    }
}