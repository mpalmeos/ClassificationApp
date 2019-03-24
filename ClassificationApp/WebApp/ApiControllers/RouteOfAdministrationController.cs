using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteOfAdministrationController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public RouteOfAdministrationController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/RouteOfAdministration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteOfAdministration>>> GetRouteOfAdministrations()
        {
            var res = await _uow.RouteOfAdministrations.AllAsync();
            return Ok(res);
        }

        // GET: api/RouteOfAdministration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteOfAdministration>> GetRouteOfAdministration(int id)
        {
            var routeOfAdministration = await _uow.RouteOfAdministrations.FindAsync(id);

            if (routeOfAdministration == null)
            {
                return NotFound();
            }

            return routeOfAdministration;
        }

        // PUT: api/RouteOfAdministration/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteOfAdministration(int id, RouteOfAdministration routeOfAdministration)
        {
            if (id != routeOfAdministration.Id)
            {
                return BadRequest();
            }

            _uow.RouteOfAdministrations.Update(routeOfAdministration);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/RouteOfAdministration
        [HttpPost]
        public async Task<ActionResult<RouteOfAdministration>> PostRouteOfAdministration(RouteOfAdministration routeOfAdministration)
        {
            await _uow.RouteOfAdministrations.AddAsync(routeOfAdministration);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetRouteOfAdministration", new { id = routeOfAdministration.Id }, routeOfAdministration);
        }

        // DELETE: api/RouteOfAdministration/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RouteOfAdministration>> DeleteRouteOfAdministration(int id)
        {
            var routeOfAdministration = await _uow.RouteOfAdministrations.FindAsync(id);
            if (routeOfAdministration == null)
            {
                return NotFound();
            }

            _uow.RouteOfAdministrations.Remove(routeOfAdministration);
            await _uow.SaveChangesAsync();

            return routeOfAdministration;
        }
    }
}
