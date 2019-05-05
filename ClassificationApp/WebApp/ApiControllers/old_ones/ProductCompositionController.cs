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
    public class ProductCompositionController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductCompositionController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/ProductComposition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductComposition>>> GetProductCompositions()
        {
            return await _bll.ProductCompositions.AllAsync();
        }

        // GET: api/ProductComposition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductComposition>> GetProductComposition(int id)
        {
            var productComposition = await _bll.ProductCompositions.FindAsync(id);

            if (productComposition == null)
            {
                return NotFound();
            }

            return productComposition;
        }

        // PUT: api/ProductComposition/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductComposition(int id, ProductComposition productComposition)
        {
            if (id != productComposition.Id)
            {
                return BadRequest();
            }

            _bll.ProductCompositions.Update(productComposition);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductComposition
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductComposition>> PostProductComposition(ProductComposition productComposition)
        {
            await _bll.ProductCompositions.AddAsync(productComposition);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProductComposition", new { id = productComposition.Id }, productComposition);
        }

        // DELETE: api/ProductComposition/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductComposition>> DeleteProductComposition(int id)
        {
            var productComposition = await _bll.ProductCompositions.FindAsync(id);
            if (productComposition == null)
            {
                return NotFound();
            }

            _bll.ProductCompositions.Remove(productComposition);
            await _bll.SaveChangesAsync();

            return productComposition;
        }
    }
}
