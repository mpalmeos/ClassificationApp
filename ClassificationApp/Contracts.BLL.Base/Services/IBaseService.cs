using System;
using Contracts.Base;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repository;

namespace Contracts.BLL.Base.Services
{
    public interface IBaseService : ITrackableInstance
    {
    }

    public interface IBaseEntityService<TEntity> : IBaseService, IBaseRepository<TEntity> 
        where TEntity : class, IBaseEntity, new()
    {
        
    }
}