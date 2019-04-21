using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class CategoryService : BaseEntityService<Category, IAppUnitOfWork>, ICategoryService
    {
        public CategoryService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}