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
    public class SubstanceCategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubstanceCategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SubstanceCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubstanceCategory>>> GetSubstanceCategories()
        {
            return await _context.SubstanceCategories.ToListAsync();
        }

        // GET: api/SubstanceCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubstanceCategory>> GetSubstanceCategory(int id)
        {
            var substanceCategory = await _context.SubstanceCategories.FindAsync(id);

            if (substanceCategory == null)
            {
                return NotFound();
            }

            return substanceCategory;
        }

        // PUT: api/SubstanceCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubstanceCategory(int id, SubstanceCategory substanceCategory)
        {
            if (id != substanceCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(substanceCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubstanceCategoryExists(id))
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

        // POST: api/SubstanceCategory
        [HttpPost]
        public async Task<ActionResult<SubstanceCategory>> PostSubstanceCategory(SubstanceCategory substanceCategory)
        {
            _context.SubstanceCategories.Add(substanceCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubstanceCategory", new { id = substanceCategory.Id }, substanceCategory);
        }

        // DELETE: api/SubstanceCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubstanceCategory>> DeleteSubstanceCategory(int id)
        {
            var substanceCategory = await _context.SubstanceCategories.FindAsync(id);
            if (substanceCategory == null)
            {
                return NotFound();
            }

            _context.SubstanceCategories.Remove(substanceCategory);
            await _context.SaveChangesAsync();

            return substanceCategory;
        }

        private bool SubstanceCategoryExists(int id)
        {
            return _context.SubstanceCategories.Any(e => e.Id == id);
        }
    }
}
