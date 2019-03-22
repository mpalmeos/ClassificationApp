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
    public class ProductNameController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductNameController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductName
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductName>>> GetProductNames()
        {
            return await _context.ProductNames.ToListAsync();
        }

        // GET: api/ProductName/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductName>> GetProductName(int id)
        {
            var productName = await _context.ProductNames.FindAsync(id);

            if (productName == null)
            {
                return NotFound();
            }

            return productName;
        }

        // PUT: api/ProductName/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductName(int id, ProductName productName)
        {
            if (id != productName.Id)
            {
                return BadRequest();
            }

            _context.Entry(productName).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductNameExists(id))
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

        // POST: api/ProductName
        [HttpPost]
        public async Task<ActionResult<ProductName>> PostProductName(ProductName productName)
        {
            _context.ProductNames.Add(productName);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductName", new { id = productName.Id }, productName);
        }

        // DELETE: api/ProductName/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductName>> DeleteProductName(int id)
        {
            var productName = await _context.ProductNames.FindAsync(id);
            if (productName == null)
            {
                return NotFound();
            }

            _context.ProductNames.Remove(productName);
            await _context.SaveChangesAsync();

            return productName;
        }

        private bool ProductNameExists(int id)
        {
            return _context.ProductNames.Any(e => e.Id == id);
        }
    }
}
