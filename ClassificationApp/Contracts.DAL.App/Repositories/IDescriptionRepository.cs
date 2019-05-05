using Contracts.DAL.Base.Repository;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IDescriptionRepository : IDescriptionRepository<DALAppDTO.Description>
    {
        
    }
    
    public interface IDescriptionRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        
    }
}