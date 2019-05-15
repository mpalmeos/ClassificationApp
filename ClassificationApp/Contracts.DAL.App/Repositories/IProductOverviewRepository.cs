using ee.itcollege.mpalmeos.Contracts.DAL.Base.Repository;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IProductOverviewRepository : IProductOverviewRepository<DALAppDTO.Customs.ProductOverview>
    {
        
    }

    public interface IProductOverviewRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        
    }
}