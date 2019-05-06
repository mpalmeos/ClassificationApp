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
    public class RouteOfAdministrationController : ControllerBase
    {
        private readonly IAppBll _bll;

        public RouteOfAdministrationController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/RouteOfAdministration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.RouteOfAdministration>>> GetRouteOfAdministrations()
        {
            return (await _bll.RouteOfAdministrations.AllAsync())
                .Select(e => v1_0_Mapper.RouteOfAdministrationMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/RouteOfAdministration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.RouteOfAdministration>> GetRouteOfAdministration(int id)
        {
            var routeOfAdministration = 
                v1_0_Mapper.RouteOfAdministrationMapper.MapFromBLL(await _bll.RouteOfAdministrations.FindAsync(id));

            if (routeOfAdministration == null)
            {
                return NotFound();
            }

            return routeOfAdministration;
        }

        // PUT: api/RouteOfAdministration/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutRouteOfAdministration(int id, v1_0_DTO.RouteOfAdministration routeOfAdministration)
        {
            if (id != routeOfAdministration.Id)
            {
                return BadRequest();
            }

            _bll.RouteOfAdministrations.Update(v1_0_Mapper.RouteOfAdministrationMapper.MapFromExternal(routeOfAdministration));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/RouteOfAdministration
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.RouteOfAdministration>> PostRouteOfAdministration(v1_0_DTO.RouteOfAdministration routeOfAdministration)
        {
            routeOfAdministration = v1_0_Mapper.RouteOfAdministrationMapper.MapFromBLL(
                _bll.RouteOfAdministrations.Add(v1_0_Mapper.RouteOfAdministrationMapper.MapFromExternal(routeOfAdministration)));
            await _bll.SaveChangesAsync();

            routeOfAdministration = v1_0_Mapper.RouteOfAdministrationMapper.MapFromBLL(
                _bll.RouteOfAdministrations.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.RouteOfAdministrationMapper.MapFromExternal(routeOfAdministration)));

            return CreatedAtAction("GetRouteOfAdministration", new { id = routeOfAdministration.Id }, routeOfAdministration);
        }

        // DELETE: api/RouteOfAdministration/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.RouteOfAdministration>> DeleteRouteOfAdministration(int id)
        {
            _bll.RouteOfAdministrations.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
