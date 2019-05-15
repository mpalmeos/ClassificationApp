using System;
using System.Threading.Tasks;
using ee.itcollege.mpalmeos.Contracts.Base;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Services;
using ee.itcollege.mpalmeos.Contracts.DAL.Base;

namespace ee.itcollege.mpalmeos.Contracts.BLL.Base
{
    public interface IBaseBll : ITrackableInstance
    {   
        /*
        IBaseEntityService<TEntity> BaseEntityService<TEntity>() 
            where TEntity : class, IDomainEntity, new();
        */
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}