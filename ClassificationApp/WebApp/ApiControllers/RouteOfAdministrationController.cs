using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly AppDbContext _context;

        public RouteOfAdministrationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RouteOfAdministration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteOfAdministration>>> GetRouteOfAdministrations()
        {
            return await _context.RouteOfAdministrations.ToListAsync();
        }

        // GET: api/RouteOfAdministration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteOfAdministration>> GetRouteOfAdministration(int id)
        {
            var routeOfAdministration = await _context.RouteOfAdministrations.FindAsync(id);

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

            _context.Entry(routeOfAdministration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteOfAdministrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RouteOfAdministration
        [HttpPost]
        public async Task<ActionResult<RouteOfAdministration>> PostRouteOfAdministration(RouteOfAdministration routeOfAdministration)
        {
            _context.RouteOfAdministrations.Add(routeOfAdministration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRouteOfAdministration", new { id = routeOfAdministration.Id }, routeOfAdministration);
        }

        // DELETE: api/RouteOfAdministration/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RouteOfAdministration>> DeleteRouteOfAdministration(int id)
        {
            var routeOfAdministration = await _context.RouteOfAdministrations.FindAsync(id);
            if (routeOfAdministration == null)
            {
                return NotFound();
            }

            _context.RouteOfAdministrations.Remove(routeOfAdministration);
            await _context.SaveChangesAsync();

            return routeOfAdministration;
        }

        private bool RouteOfAdministrationExists(int id)
        {
            return _context.RouteOfAdministrations.Any(e => e.Id == id);
        }
    }
}
