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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDescriptionController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public ProductDescriptionController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ProductDescription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDescription>>> GetProductDescriptions()
        {
            var res = await _uow.ProductDescriptions.AllAsync();
            return Ok(res);
        }

        // GET: api/ProductDescription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDescription>> GetProductDescription(int id)
        {
            var productDescription = await _uow.ProductDescriptions.FindAsync(id);

            if (productDescription == null)
            {
                return NotFound();
            }

            return productDescription;
        }

        // PUT: api/ProductDescription/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductDescription(int id, ProductDescription productDescription)
        {
            if (id != productDescription.Id)
            {
                return BadRequest();
            }

            _uow.ProductDescriptions.Update(productDescription);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductDescription
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductDescription>> PostProductDescription(ProductDescription productDescription)
        {
            await _uow.ProductDescriptions.AddAsync(productDescription);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetProductDescription", new { id = productDescription.Id }, productDescription);
        }

        // DELETE: api/ProductDescription/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductDescription>> DeleteProductDescription(int id)
        {
            var productDescription = await _uow.ProductDescriptions.FindAsync(id);
            if (productDescription == null)
            {
                return NotFound();
            }

            _uow.ProductDescriptions.Remove(productDescription);
            await _uow.SaveChangesAsync();

            return productDescription;
        }
    }
}
