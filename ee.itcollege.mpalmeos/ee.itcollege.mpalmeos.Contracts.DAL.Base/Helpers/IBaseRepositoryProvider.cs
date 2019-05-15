using ee.itcollege.mpalmeos.Contracts.DAL.Base.Repository;

namespace ee.itcollege.mpalmeos.Contracts.DAL.Base.Helpers
{
    public interface IBaseRepositoryProvider
    {
        TRepository GetRepository<TRepository>();

        IBaseRepository<TDALEntity> GetEntityRepository<TDALEntity, TDomainEntity>()
            where TDALEntity : class, new()
            where TDomainEntity : class, IDomainEntity, new();
    }
}