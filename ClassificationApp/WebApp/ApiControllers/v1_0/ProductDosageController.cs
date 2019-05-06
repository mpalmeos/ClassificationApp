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
    public class ProductDosageController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductDosageController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/ProductDosage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDosage>>> GetProductDosages()
        {
            return await _bll.ProductDosages.AllAsync();
        }

        // GET: api/ProductDosage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDosage>> GetProductDosage(int id)
        {
            var productDosage = await _bll.ProductDosages.FindAsync(id);

            if (productDosage == null)
            {
                return NotFound();
            }

            return productDosage;
        }

        // PUT: api/ProductDosage/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductDosage(int id, ProductDosage productDosage)
        {
            if (id != productDosage.Id)
            {
                return BadRequest();
            }

            _bll.ProductDosages.Update(productDosage);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductDosage
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductDosage>> PostProductDosage(ProductDosage productDosage)
        {
            await _bll.ProductDosages.AddAsync(productDosage);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProductDosage", new { id = productDosage.Id }, productDosage);
        }

        // DELETE: api/ProductDosage/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductDosage>> DeleteProductDosage(int id)
        {
            var productDosage = await _bll.ProductDosages.FindAsync(id);
            if (productDosage == null)
            {
                return NotFound();
            }

            _bll.ProductDosages.Remove(productDosage);
            await _bll.SaveChangesAsync();

            return productDosage;
        }
    }
}
