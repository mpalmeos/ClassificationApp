using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.mpalmeos.BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ProductCompanyService : 
        BaseEntityService<BLL.App.DTO.ProductCompany, DAL.App.DTO.ProductCompany, IAppUnitOfWork>, IProductCompanyService
    {
        public ProductCompanyService(IAppUnitOfWork uow) : base(uow, new ProductCompanyMapper())
        {
            ServiceRepository = Uow.ProductCompanies;
        }

        public async Task<BLL.App.DTO.ProductCompany> FindAllPerEntity(int id)
        {
            return ProductCompanyMapper.MapFromDAL(await Uow.ProductCompanies.FindAllPerEntity(id));
        }
    }
}