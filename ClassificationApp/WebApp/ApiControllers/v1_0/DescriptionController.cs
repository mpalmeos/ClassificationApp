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
    public class DescriptionController : ControllerBase
    {
        private readonly IAppBll _bll;

        public DescriptionController(IAppBll bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all Descriptions.
        /// </summary>
        /// <returns>Array of all descriptions.</returns>
        // GET: api/Description
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.Description>>> GetDescriptions()
        {
            return (await _bll.Descriptions.AllAsync())
                .Select(e => v1_0_Mapper.DescriptionMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get Description by Id.
        /// </summary>
        /// <param name="id">DescriptionID to retrieve.</param>
        /// <returns>Specific Description by ID.</returns>
        // GET: api/Description/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.Description>> GetDescription(int id)
        {
            var description = 
                v1_0_Mapper.DescriptionMapper.MapFromBLL(await _bll.Descriptions.FindAsync(id));

            if (description == null)
            {
                return NotFound();
            }

            return description;
        }

        /// <summary>
        /// Modify Description in database.
        /// </summary>
        /// <param name="id">ID of description to modify.</param>
        /// <param name="description">Modified description object.</param>
        /// <returns>Does not return anything.</returns>
        // PUT: api/Description/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutDescription(int id, v1_0_DTO.Description description)
        {
            if (id != description.Id)
            {
                return BadRequest();
            }

            _bll.Descriptions.Update(v1_0_Mapper.DescriptionMapper.MapFromExternal(description));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Add new description to database.
        /// </summary>
        /// <param name="description">Description object to be added.</param>
        /// <returns>Added Description with ID.</returns>
        // POST: api/Description
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.Description>> PostDescription(v1_0_DTO.Description description)
        {
            description = v1_0_Mapper.DescriptionMapper.MapFromBLL(
                _bll.Descriptions.Add(v1_0_Mapper.DescriptionMapper.MapFromExternal(description)));
            await _bll.SaveChangesAsync();

            description = v1_0_Mapper.DescriptionMapper.MapFromBLL(
                _bll.Descriptions.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.DescriptionMapper.MapFromExternal(description)));

            return CreatedAtAction("GetDescription", new { id = description.Id }, description);
        }

        /// <summary>
        /// Delete Description from database.
        /// </summary>
        /// <param name="id">ID of description to be deleted (hard delete).</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/Description/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.Description>> DeleteDescription(int id)
        {
            _bll.Descriptions.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
