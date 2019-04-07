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
    public class ProductNameController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public ProductNameController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ProductName
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductName>>> GetProductNames()
        {
            var res = await _uow.ProductNames.AllAsync();
            return Ok(res);
        }

        // GET: api/ProductName/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductName>> GetProductName(int id)
        {
            var productName = await _uow.ProductNames.FindAsync(id);

            if (productName == null)
            {
                return NotFound();
            }

            return productName;
        }

        // PUT: api/ProductName/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductName(int id, ProductName productName)
        {
            if (id != productName.Id)
            {
                return BadRequest();
            }

            _uow.ProductNames.Update(productName);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductName
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductName>> PostProductName(ProductName productName)
        {
            await _uow.ProductNames.AddAsync(productName);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetProductName", new { id = productName.Id }, productName);
        }

        // DELETE: api/ProductName/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductName>> DeleteProductName(int id)
        {
            var productName = await _uow.ProductNames.FindAsync(id);
            if (productName == null)
            {
                return NotFound();
            }

            _uow.ProductNames.Remove(productName);
            await _uow.SaveChangesAsync();

            return productName;
        }
    }
}
