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
    public class ProductClassificationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductClassificationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductClassification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductClassification>>> GetProductClassifications()
        {
            return await _context.ProductClassifications.ToListAsync();
        }

        // GET: api/ProductClassification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductClassification>> GetProductClassification(int id)
        {
            var productClassification = await _context.ProductClassifications.FindAsync(id);

            if (productClassification == null)
            {
                return NotFound();
            }

            return productClassification;
        }

        // PUT: api/ProductClassification/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductClassification(int id, ProductClassification productClassification)
        {
            if (id != productClassification.Id)
            {
                return BadRequest();
            }

            _context.Entry(productClassification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductClassificationExists(id))
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

        // POST: api/ProductClassification
        [HttpPost]
        public async Task<ActionResult<ProductClassification>> PostProductClassification(ProductClassification productClassification)
        {
            _context.ProductClassifications.Add(productClassification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductClassification", new { id = productClassification.Id }, productClassification);
        }

        // DELETE: api/ProductClassification/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductClassification>> DeleteProductClassification(int id)
        {
            var productClassification = await _context.ProductClassifications.FindAsync(id);
            if (productClassification == null)
            {
                return NotFound();
            }

            _context.ProductClassifications.Remove(productClassification);
            await _context.SaveChangesAsync();

            return productClassification;
        }

        private bool ProductClassificationExists(int id)
        {
            return _context.ProductClassifications.Any(e => e.Id == id);
        }
    }
}
