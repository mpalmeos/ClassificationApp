using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.DTO;
using Domain;

namespace BLL.App.Services
{
    public class SubstanceCategoryService : BaseEntityService<SubstanceCategory, IAppUnitOfWork>, ISubstanceCategoryService
    {
        public SubstanceCategoryService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<SubstanceCategoryDTO>> GetAllWithConnections()
        {
            return await Uow.SubstanceCategories.GetAllWithConnections();
        }
    }
}