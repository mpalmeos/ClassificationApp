using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category, AppDbContext>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}