using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SubstanceCategoryRepository : BaseRepository<SubstanceCategory>, ISubstanceCategoryRepository
    {
        public SubstanceCategoryRepository(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<List<SubstanceCategoryDTO>> GetAllWithConnections()
        {
            return await RepositoryDbSet
                .Select(sc => new SubstanceCategoryDTO()
                {
                    Id = sc.Id,
                    SubstanceName = sc.Substance.SubstanceName,
                    CategoryValue = sc.Category.CategoryValue
                })
                .ToListAsync();
        }
    }
}