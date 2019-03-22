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
    public class ProductDosageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductDosageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductDosage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDosage>>> GetProductDosages()
        {
            return await _context.ProductDosages.ToListAsync();
        }

        // GET: api/ProductDosage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDosage>> GetProductDosage(int id)
        {
            var productDosage = await _context.ProductDosages.FindAsync(id);

            if (productDosage == null)
            {
                return NotFound();
            }

            return productDosage;
        }

        // PUT: api/ProductDosage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDosage(int id, ProductDosage productDosage)
        {
            if (id != productDosage.Id)
            {
                return BadRequest();
            }

            _context.Entry(productDosage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDosageExists(id))
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

        // POST: api/ProductDosage
        [HttpPost]
        public async Task<ActionResult<ProductDosage>> PostProductDosage(ProductDosage productDosage)
        {
            _context.ProductDosages.Add(productDosage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDosage", new { id = productDosage.Id }, productDosage);
        }

        // DELETE: api/ProductDosage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDosage>> DeleteProductDosage(int id)
        {
            var productDosage = await _context.ProductDosages.FindAsync(id);
            if (productDosage == null)
            {
                return NotFound();
            }

            _context.ProductDosages.Remove(productDosage);
            await _context.SaveChangesAsync();

            return productDosage;
        }

        private bool ProductDosageExists(int id)
        {
            return _context.ProductDosages.Any(e => e.Id == id);
        }
    }
}
