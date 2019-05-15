using System;
using System.Threading.Tasks;
using ee.itcollege.mpalmeos.Contracts.BLL.Base;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Helpers;
using ee.itcollege.mpalmeos.Contracts.DAL.Base;

namespace ee.itcollege.mpalmeos.BLL.Base
{
    public class BaseBLL<TUnitOfWork> : IBaseBll
        where TUnitOfWork: IBaseUnitOfWork
    {
        public virtual Guid InstanceId { get; } = Guid.NewGuid();


        protected readonly TUnitOfWork UnitOfWork;
        protected readonly IBaseServiceProvider ServiceProvider;

        public BaseBLL(TUnitOfWork unitOfWork, IBaseServiceProvider serviceProvider)
        {
            UnitOfWork = unitOfWork;
            ServiceProvider = serviceProvider;
        }

        /*
        public virtual IBaseEntityService<TEntity> BaseEntityService<TEntity>() where TEntity : class, IBaseEntity, new()
        {
            return ServiceProvider.GetEntityService<TEntity>();
        }
        */
        
        public virtual async Task<int> SaveChangesAsync()
        {
            return await UnitOfWork.SaveChangesAsync();   
        }
        
        public int SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }
        
    }

}