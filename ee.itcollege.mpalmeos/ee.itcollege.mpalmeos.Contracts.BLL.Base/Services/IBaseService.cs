using System;
using ee.itcollege.mpalmeos.Contracts.Base;
using ee.itcollege.mpalmeos.Contracts.DAL.Base;
using ee.itcollege.mpalmeos.Contracts.DAL.Base.Repository;

namespace ee.itcollege.mpalmeos.Contracts.BLL.Base.Services
{
    public interface IBaseService : ITrackableInstance
    {
    }

    public interface IBaseEntityService<TBLLEntity> : IBaseService, IBaseRepository<TBLLEntity> 
        where TBLLEntity : class, new()
    {
        
    }
}