using System;
using Contracts.Base;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repository;

namespace Contracts.BLL.Base.Services
{
    public interface IBaseService : ITrackableInstance
    {
    }

    public interface IBaseEntityService<TBLLEntity> : IBaseService, IBaseRepository<TBLLEntity> 
        where TBLLEntity : class, new()
    {
        
    }
}