using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CRoleRepository : BaseRepository<DAL.App.DTO.CRole, Domain.CRole, AppDbContext>, ICRoleRepository
    {
        public CRoleRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new CRoleMapper())
        {
        }
    }
}