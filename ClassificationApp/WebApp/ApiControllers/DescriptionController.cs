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
    public class DescriptionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DescriptionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Description
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Description>>> GetDescriptions()
        {
            return await _context.Descriptions.ToListAsync();
        }

        // GET: api/Description/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Description>> GetDescription(int id)
        {
            var description = await _context.Descriptions.FindAsync(id);

            if (description == null)
            {
                return NotFound();
            }

            return description;
        }

        // PUT: api/Description/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescription(int id, Description description)
        {
            if (id != description.Id)
            {
                return BadRequest();
            }

            _context.Entry(description).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptionExists(id))
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

        // POST: api/Description
        [HttpPost]
        public async Task<ActionResult<Description>> PostDescription(Description description)
        {
            _context.Descriptions.Add(description);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDescription", new { id = description.Id }, description);
        }

        // DELETE: api/Description/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Description>> DeleteDescription(int id)
        {
            var description = await _context.Descriptions.FindAsync(id);
            if (description == null)
            {
                return NotFound();
            }

            _context.Descriptions.Remove(description);
            await _context.SaveChangesAsync();

            return description;
        }

        private bool DescriptionExists(int id)
        {
            return _context.Descriptions.Any(e => e.Id == id);
        }
    }
}
