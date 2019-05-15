using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.mpalmeos.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DescriptionRepository : BaseRepository<DAL.App.DTO.Description, Domain.Description, AppDbContext>, IDescriptionRepository
    {
        public DescriptionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new DescriptionMapper())
        {
        }
    }
}