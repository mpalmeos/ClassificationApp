using System;
using Contracts.Base;
using Contracts.DAL.Base.Repository;

namespace Contracts.BLL.Base.Services
{
    public interface IBaseService : ITrackableInstance
    {
    }

    public interface IBaseEntityService<TEntity> : IBaseService, IRepository<TEntity> 
        where TEntity : class, new()
    {
        
    }
}