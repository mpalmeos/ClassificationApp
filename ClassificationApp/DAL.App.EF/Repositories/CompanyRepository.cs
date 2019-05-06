using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompanyRepository : 
        BaseRepository<DAL.App.DTO.Company, Domain.Company, AppDbContext>, 
        ICompanyRepository
    {
        public CompanyRepository(AppDbContext repositoryDbContext) : 
            base(repositoryDbContext, new CompanyMapper())
        {
        }
        
        
    }
}