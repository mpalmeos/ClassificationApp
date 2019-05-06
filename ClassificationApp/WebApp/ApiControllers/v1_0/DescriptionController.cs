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

        // GET: api/Description
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.Description>>> GetDescriptions()
        {
            return (await _bll.Descriptions.AllAsync())
                .Select(e => v1_0_Mapper.DescriptionMapper.MapFromBLL(e)).ToList();
        }

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
