using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repository;
using DAL.App.DTO;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ISubstanceCategoryRepository : IRepository<SubstanceCategory>
    {
        Task<List<SubstanceCategoryDTO>> GetAllWithConnections();
    }
}