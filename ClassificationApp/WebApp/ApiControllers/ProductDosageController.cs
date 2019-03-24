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
    public class ProductDosageController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public ProductDosageController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ProductDosage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDosage>>> GetProductDosages()
        {
            var res = await _uow.ProductDosages.AllAsync();
            return Ok(res);
        }

        // GET: api/ProductDosage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDosage>> GetProductDosage(int id)
        {
            var productDosage = await _uow.ProductDosages.FindAsync(id);

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

            _uow.ProductDosages.Update(productDosage);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductDosage
        [HttpPost]
        public async Task<ActionResult<ProductDosage>> PostProductDosage(ProductDosage productDosage)
        {
            await _uow.ProductDosages.AddAsync(productDosage);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetProductDosage", new { id = productDosage.Id }, productDosage);
        }

        // DELETE: api/ProductDosage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDosage>> DeleteProductDosage(int id)
        {
            var productDosage = await _uow.ProductDosages.FindAsync(id);
            if (productDosage == null)
            {
                return NotFound();
            }

            _uow.ProductDosages.Remove(productDosage);
            await _uow.SaveChangesAsync();

            return productDosage;
        }
    }
}
