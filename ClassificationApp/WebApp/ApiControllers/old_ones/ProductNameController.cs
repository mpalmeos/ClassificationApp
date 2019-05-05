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
    public class ProductNameController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductNameController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/ProductName
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductName>>> GetProductNames()
        {
            return await _bll.ProductNames.AllAsync();
        }

        // GET: api/ProductName/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductName>> GetProductName(int id)
        {
            var productName = await _bll.ProductNames.FindAsync(id);

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

            _bll.ProductNames.Update(productName);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductName
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductName>> PostProductName(ProductName productName)
        {
            await _bll.ProductNames.AddAsync(productName);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProductName", new { id = productName.Id }, productName);
        }

        // DELETE: api/ProductName/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductName>> DeleteProductName(int id)
        {
            var productName = await _bll.ProductNames.FindAsync(id);
            if (productName == null)
            {
                return NotFound();
            }

            _bll.ProductNames.Remove(productName);
            await _bll.SaveChangesAsync();

            return productName;
        }
    }
}
