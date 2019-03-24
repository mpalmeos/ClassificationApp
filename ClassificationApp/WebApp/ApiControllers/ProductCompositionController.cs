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
    public class ProductCompositionController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public ProductCompositionController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ProductComposition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductComposition>>> GetProductCompositions()
        {
            var res = await _uow.ProductCompositions.AllAsync();
            return Ok(res);
        }

        // GET: api/ProductComposition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductComposition>> GetProductComposition(int id)
        {
            var productComposition = await _uow.ProductCompositions.FindAsync(id);

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

            _uow.ProductCompositions.Update(productComposition);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductComposition
        [HttpPost]
        public async Task<ActionResult<ProductComposition>> PostProductComposition(ProductComposition productComposition)
        {
            await _uow.ProductCompositions.AddAsync(productComposition);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetProductComposition", new { id = productComposition.Id }, productComposition);
        }

        // DELETE: api/ProductComposition/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductComposition>> DeleteProductComposition(int id)
        {
            var productComposition = await _uow.ProductCompositions.FindAsync(id);
            if (productComposition == null)
            {
                return NotFound();
            }

            _uow.ProductCompositions.Remove(productComposition);
            await _uow.SaveChangesAsync();

            return productComposition;
        }
    }
}
