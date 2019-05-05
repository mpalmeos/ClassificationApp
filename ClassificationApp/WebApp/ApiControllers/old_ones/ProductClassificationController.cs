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
    public class ProductClassificationController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductClassificationController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/ProductClassification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductClassification>>> GetProductClassifications()
        {
            return await _bll.ProductClassifications.AllAsync();
        }

        // GET: api/ProductClassification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductClassification>> GetProductClassification(int id)
        {
            var productClassification = await _bll.ProductClassifications.FindAsync(id);

            if (productClassification == null)
            {
                return NotFound();
            }

            return productClassification;
        }

        // PUT: api/ProductClassification/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductClassification(int id, ProductClassification productClassification)
        {
            if (id != productClassification.Id)
            {
                return BadRequest();
            }

            _bll.ProductClassifications.Update(productClassification);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductClassification
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductClassification>> PostProductClassification(ProductClassification productClassification)
        {
            await _bll.ProductClassifications.AddAsync(productClassification);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProductClassification", new { id = productClassification.Id }, productClassification);
        }

        // DELETE: api/ProductClassification/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductClassification>> DeleteProductClassification(int id)
        {
            var productClassification = await _bll.ProductClassifications.FindAsync(id);
            if (productClassification == null)
            {
                return NotFound();
            }

            _bll.ProductClassifications.Remove(productClassification);
            await _bll.SaveChangesAsync();

            return productClassification;
        }
    }
}
