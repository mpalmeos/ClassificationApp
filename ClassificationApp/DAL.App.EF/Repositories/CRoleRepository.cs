using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CRoleRepository : BaseRepository<CRole, AppDbContext>, ICRoleRepository
    {
        public CRoleRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}