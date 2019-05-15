using ee.itcollege.mpalmeos.Contracts.BLL.Base.Services;
using ee.itcollege.mpalmeos.Contracts.DAL.Base;

namespace ee.itcollege.mpalmeos.Contracts.BLL.Base.Helpers
{
    public interface IBaseServiceProvider
    {
        TService GetService<TService>();
        /*
        IBaseEntityService<TEntity> GetEntityService<TEntity>() where TEntity : class, IDomainEntity, new();
        */
    }
}