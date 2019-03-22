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
    public class ProductCompanyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductCompanyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCompany>>> GetProductCompanies()
        {
            return await _context.ProductCompanies.ToListAsync();
        }

        // GET: api/ProductCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCompany>> GetProductCompany(int id)
        {
            var productCompany = await _context.ProductCompanies.FindAsync(id);

            if (productCompany == null)
            {
                return NotFound();
            }

            return productCompany;
        }

        // PUT: api/ProductCompany/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCompany(int id, ProductCompany productCompany)
        {
            if (id != productCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(productCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCompanyExists(id))
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

        // POST: api/ProductCompany
        [HttpPost]
        public async Task<ActionResult<ProductCompany>> PostProductCompany(ProductCompany productCompany)
        {
            _context.ProductCompanies.Add(productCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCompany", new { id = productCompany.Id }, productCompany);
        }

        // DELETE: api/ProductCompany/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCompany>> DeleteProductCompany(int id)
        {
            var productCompany = await _context.ProductCompanies.FindAsync(id);
            if (productCompany == null)
            {
                return NotFound();
            }

            _context.ProductCompanies.Remove(productCompany);
            await _context.SaveChangesAsync();

            return productCompany;
        }

        private bool ProductCompanyExists(int id)
        {
            return _context.ProductCompanies.Any(e => e.Id == id);
        }
    }
}
