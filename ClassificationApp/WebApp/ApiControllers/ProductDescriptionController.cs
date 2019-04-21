using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
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
        private readonly IAppBll _bll;

        public ProductDescriptionController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/ProductDescription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDescription>>> GetProductDescriptions()
        {
            return await _bll.ProductDescriptions.AllAsync();
        }

        // GET: api/ProductDescription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDescription>> GetProductDescription(int id)
        {
            var productDescription = await _bll.ProductDescriptions.FindAsync(id);

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

            _bll.ProductDescriptions.Update(productDescription);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductDescription
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductDescription>> PostProductDescription(ProductDescription productDescription)
        {
            await _bll.ProductDescriptions.AddAsync(productDescription);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProductDescription", new { id = productDescription.Id }, productDescription);
        }

        // DELETE: api/ProductDescription/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductDescription>> DeleteProductDescription(int id)
        {
            var productDescription = await _bll.ProductDescriptions.FindAsync(id);
            if (productDescription == null)
            {
                return NotFound();
            }

            _bll.ProductDescriptions.Remove(productDescription);
            await _bll.SaveChangesAsync();

            return productDescription;
        }
    }
}
