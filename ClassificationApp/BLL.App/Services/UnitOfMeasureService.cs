using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class UnitOfMeasureService : BaseEntityService<UnitOfMeasure, IAppUnitOfWork>, IUnitOfMeasureService
    {
        public UnitOfMeasureService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}