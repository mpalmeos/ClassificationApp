using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using v1_0_DTO = PublicApi.v1.DTO;
using v1_0_Mapper = PublicApi.v1.Mappers;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IAppBll _bll;

        public CompanyController(IAppBll bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all Company objects.
        /// </summary>
        /// <returns>Array of all Companies.</returns>
        /// <response code="200">The array of Companies was successfully delivered.</response>
        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.Company>>> GetCompanies()
        {
            return (await _bll.Companies.AllAsync())
                .Select(e => v1_0_Mapper.CompanyMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get Company object by CompanyID.
        /// </summary>
        /// <param name="id">CompanyID of the Company object to be retrieved.</param>
        /// <returns>One Company object</returns>
        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.Company>> GetCompany(int id)
        {
            var company = 
                v1_0_Mapper.CompanyMapper.MapFromBLL(await _bll.Companies.FindAsync(id));

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        /// <summary>
        /// Updates single Company object.
        /// </summary>
        /// <param name="id">CompanyID of the Company object to be updated.</param>
        /// <param name="company">Company object to be modified.</param>
        /// <returns>Does not return anything.</returns>
        // PUT: api/Company/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCompany(int id, v1_0_DTO.Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _bll.Companies.Update(v1_0_Mapper.CompanyMapper.MapFromExternal(company));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Adding new Company object to database.
        /// </summary>
        /// <param name="company">Company object to be added to the database</param>
        /// <returns>The new Company object and ID.</returns>
        // POST: api/Company
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.Company>> PostCompany(v1_0_DTO.Company company)
        {
            company = v1_0_Mapper.CompanyMapper.MapFromBLL(
                _bll.Companies.Add(v1_0_Mapper.CompanyMapper.MapFromExternal(company)));
            await _bll.SaveChangesAsync();

            company = v1_0_Mapper.CompanyMapper.MapFromBLL(
                _bll.Companies.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.CompanyMapper.MapFromExternal(company)));

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        /// <summary>
        /// Deletes Company object from database (hard delete).
        /// </summary>
        /// <param name="id">CompanyID of the Company item to be deleted.</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.Company>> DeleteCompany(int id)
        {
            _bll.Companies.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
