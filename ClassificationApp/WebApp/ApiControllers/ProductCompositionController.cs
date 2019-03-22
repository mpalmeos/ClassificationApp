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
    public class ProductCompositionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductCompositionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductComposition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductComposition>>> GetProductCompositions()
        {
            return await _context.ProductCompositions.ToListAsync();
        }

        // GET: api/ProductComposition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductComposition>> GetProductComposition(int id)
        {
            var productComposition = await _context.ProductCompositions.FindAsync(id);

            if (productComposition == null)
            {
                return NotFound();
            }

            return productComposition;
        }

        // PUT: api/ProductComposition/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductComposition(int id, ProductComposition productComposition)
        {
            if (id != productComposition.Id)
            {
                return BadRequest();
            }

            _context.Entry(productComposition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCompositionExists(id))
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

        // POST: api/ProductComposition
        [HttpPost]
        public async Task<ActionResult<ProductComposition>> PostProductComposition(ProductComposition productComposition)
        {
            _context.ProductCompositions.Add(productComposition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductComposition", new { id = productComposition.Id }, productComposition);
        }

        // DELETE: api/ProductComposition/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductComposition>> DeleteProductComposition(int id)
        {
            var productComposition = await _context.ProductCompositions.FindAsync(id);
            if (productComposition == null)
            {
                return NotFound();
            }

            _context.ProductCompositions.Remove(productComposition);
            await _context.SaveChangesAsync();

            return productComposition;
        }

        private bool ProductCompositionExists(int id)
        {
            return _context.ProductCompositions.Any(e => e.Id == id);
        }
    }
}
