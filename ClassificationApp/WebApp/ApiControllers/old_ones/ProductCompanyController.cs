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
    public class ProductCompanyController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductCompanyController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/ProductCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCompany>>> GetProductCompanies()
        {
            return await _bll.ProductCompanies.AllAsync();
        }

        // GET: api/ProductCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCompany>> GetProductCompany(int id)
        {
            var productCompany = await _bll.ProductCompanies.FindAsync(id);

            if (productCompany == null)
            {
                return NotFound();
            }

            return productCompany;
        }

        // PUT: api/ProductCompany/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductCompany(int id, ProductCompany productCompany)
        {
            if (id != productCompany.Id)
            {
                return BadRequest();
            }

            _bll.ProductCompanies.Update(productCompany);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductCompany
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductCompany>> PostProductCompany(ProductCompany productCompany)
        {
            await _bll.ProductCompanies.AddAsync(productCompany);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProductCompany", new { id = productCompany.Id }, productCompany);
        }

        // DELETE: api/ProductCompany/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductCompany>> DeleteProductCompany(int id)
        {
            var productCompany = await _bll.ProductCompanies.FindAsync(id);
            if (productCompany == null)
            {
                return NotFound();
            }

            _bll.ProductCompanies.Remove(productCompany);
            await _bll.SaveChangesAsync();

            return productCompany;
        }
    }
}
