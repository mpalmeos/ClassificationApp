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
    public class CRoleController : ControllerBase
    {
        private readonly IAppBll _bll;

        public CRoleController(IAppBll bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all Roles from database.
        /// </summary>
        /// <returns>Array of Roles.</returns>
        // GET: api/CRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.CRole>>> GetCRoles()
        {
            return (await _bll.CRoles.AllAsync())
                .Select(e => v1_0_Mapper.CRoleMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get specific Role from database by ID.
        /// </summary>
        /// <param name="id">ID of Role to be retrieved.</param>
        /// <returns>Specific Role by ID.</returns>
        // GET: api/CRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.CRole>> GetCRole(int id)
        {
            var cRole = v1_0_Mapper.CRoleMapper.MapFromBLL(await _bll.CRoles.FindAsync(id));

            if (cRole == null)
            {
                return NotFound();
            }

            return cRole;
        }

        /// <summary>
        /// Modify specific Role in database-
        /// </summary>
        /// <param name="id">ID of Role to be modified.</param>
        /// <param name="cRole">Modified Role.</param>
        /// <returns>Does not return anything.</returns>
        // PUT: api/CRole/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCRole(int id, v1_0_DTO.CRole cRole)
        {
            if (id != cRole.Id)
            {
                return BadRequest();
            }

            _bll.CRoles.Update(v1_0_Mapper.CRoleMapper.MapFromExternal(cRole));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Addition of new Role to database.
        /// </summary>
        /// <param name="cRole">New Role to be added.</param>
        /// <returns>New Role and ID.</returns>
        // POST: api/CRole
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.CRole>> PostCRole(v1_0_DTO.CRole cRole)
        {
            cRole = v1_0_Mapper.CRoleMapper.MapFromBLL(
                await _bll.CRoles.AddAsync(v1_0_Mapper.CRoleMapper.MapFromExternal(cRole)));
            await _bll.SaveChangesAsync();

            cRole = v1_0_Mapper.CRoleMapper.MapFromBLL(
                _bll.CRoles.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.CRoleMapper.MapFromExternal(cRole)));

            return CreatedAtAction("GetCRole", new {version = HttpContext.GetRequestedApiVersion().ToString(), id = cRole.Id}, cRole);
        }

        /// <summary>
        /// Delete specific Role from database.
        /// </summary>
        /// <param name="id">ID of Role to be deleted.</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/CRole/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.CRole>> DeleteCRole(int id)
        {
            _bll.CRoles.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}