using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DescriptionRepository : BaseRepository<Description>, IDescriptionRepository
    {
        public DescriptionRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}