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
    public class ProductClassificationController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public ProductClassificationController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ProductClassification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductClassification>>> GetProductClassifications()
        {
            var res = await _uow.ProductClassifications.AllAsync();
            return Ok(res);
        }

        // GET: api/ProductClassification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductClassification>> GetProductClassification(int id)
        {
            var productClassification = await _uow.ProductClassifications.FindAsync(id);

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

            _uow.ProductClassifications.Update(productClassification);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductClassification
        [HttpPost]
        public async Task<ActionResult<ProductClassification>> PostProductClassification(ProductClassification productClassification)
        {
            await _uow.ProductClassifications.AddAsync(productClassification);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetProductClassification", new { id = productClassification.Id }, productClassification);
        }

        // DELETE: api/ProductClassification/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductClassification>> DeleteProductClassification(int id)
        {
            var productClassification = await _uow.ProductClassifications.FindAsync(id);
            if (productClassification == null)
            {
                return NotFound();
            }

            _uow.ProductClassifications.Remove(productClassification);
            await _uow.SaveChangesAsync();

            return productClassification;
        }
    }
}
