using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<RouteOfAdministration>>> GetRouteOfAdministrations()
        {
            return await _bll.RouteOfAdministrations.AllAsync();
        }

        // GET: api/RouteOfAdministration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteOfAdministration>> GetRouteOfAdministration(int id)
        {
            var routeOfAdministration = await _bll.RouteOfAdministrations.FindAsync(id);

            if (routeOfAdministration == null)
            {
                return NotFound();
            }

            return routeOfAdministration;
        }

        // PUT: api/RouteOfAdministration/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutRouteOfAdministration(int id, RouteOfAdministration routeOfAdministration)
        {
            if (id != routeOfAdministration.Id)
            {
                return BadRequest();
            }

            _bll.RouteOfAdministrations.Update(routeOfAdministration);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/RouteOfAdministration
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<RouteOfAdministration>> PostRouteOfAdministration(RouteOfAdministration routeOfAdministration)
        {
            await _bll.RouteOfAdministrations.AddAsync(routeOfAdministration);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetRouteOfAdministration", new { id = routeOfAdministration.Id }, routeOfAdministration);
        }

        // DELETE: api/RouteOfAdministration/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<RouteOfAdministration>> DeleteRouteOfAdministration(int id)
        {
            var routeOfAdministration = await _bll.RouteOfAdministrations.FindAsync(id);
            if (routeOfAdministration == null)
            {
                return NotFound();
            }

            _bll.RouteOfAdministrations.Remove(routeOfAdministration);
            await _bll.SaveChangesAsync();

            return routeOfAdministration;
        }
    }
}
