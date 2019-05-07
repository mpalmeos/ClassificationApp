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
    public class CompanyRoleController : ControllerBase
    {
        private readonly IAppBll _bll;

        public CompanyRoleController(IAppBll bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all CompanyRoles
        /// </summary>
        /// <returns>Array of CompanyRoles.</returns>
        // GET: api/CompanyRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.CompanyRole>>> GetCompanyRoles()
        {
            return (await _bll.CompanyRoles.AllAsync())
                .Select(e => v1_0_Mapper.CompanyRoleMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get CompanyRole by ID.
        /// </summary>
        /// <param name="id">ID of CompanyRole to be retreived.</param>
        /// <returns>Specific CompanyRole by ID</returns>
        // GET: api/CompanyRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.CompanyRole>> GetCompanyRole(int id)
        {
            var companyRole = 
                v1_0_Mapper.CompanyRoleMapper.MapFromBLL(await _bll.CompanyRoles.FindAsync(id));

            if (companyRole == null)
            {
                return NotFound();
            }

            return companyRole;
        }

        /// <summary>
        /// Modify existing CompanyRole.
        /// </summary>
        /// <param name="id">ID of CompanyRole to be modified.</param>
        /// <param name="companyRole">Modified CompanyRole object.</param>
        /// <returns>Does not return anything.</returns>
        // PUT: api/CompanyRole/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCompanyRole(int id, v1_0_DTO.CompanyRole companyRole)
        {
            if (id != companyRole.Id)
            {
                return BadRequest();
            }

            _bll.CompanyRoles.Update(v1_0_Mapper.CompanyRoleMapper.MapFromExternal(companyRole));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Add new CompanyRole to database.
        /// </summary>
        /// <param name="companyRole">CompanyRole object to be added to database.</param>
        /// <returns>New CompanyRole object and ID.</returns>
        // POST: api/CompanyRole
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.CompanyRole>> PostCompanyRole(v1_0_DTO.CompanyRole companyRole)
        {
            companyRole = v1_0_Mapper.CompanyRoleMapper.MapFromBLL(
                _bll.CompanyRoles.Add(v1_0_Mapper.CompanyRoleMapper.MapFromExternal(companyRole)));
            await _bll.SaveChangesAsync();

            companyRole = v1_0_Mapper.CompanyRoleMapper.MapFromBLL(
                _bll.CompanyRoles.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.CompanyRoleMapper.MapFromExternal(companyRole)));

            return CreatedAtAction("GetCompanyRole", new { id = companyRole.Id }, companyRole);
        }

        /// <summary>
        /// Deletes CompanyRole by ID.
        /// </summary>
        /// <param name="id">ID of CompanyRole to be deleted.</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/CompanyRole/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.CompanyRole>> DeleteCompanyRole(int id)
        {
            _bll.CompanyRoles.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
