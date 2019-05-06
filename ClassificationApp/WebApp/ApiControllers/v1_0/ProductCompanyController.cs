using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using v1_0_DTO = PublicApi.v1.DTO;
using v1_0_Mapper = PublicApi.v1.Mappers;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        public async Task<ActionResult<IEnumerable<v1_0_DTO.ProductCompany>>> GetProductCompanies()
        {
            return (await _bll.ProductCompanies.AllAsync())
                .Select(e => v1_0_Mapper.ProductCompanyMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/ProductCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.ProductCompany>> GetProductCompany(int id)
        {
            var productCompany = 
                v1_0_Mapper.ProductCompanyMapper.MapFromBLL(await _bll.ProductCompanies.FindAsync(id));

            if (productCompany == null)
            {
                return NotFound();
            }

            return productCompany;
        }

        // PUT: api/ProductCompany/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductCompany(int id, v1_0_DTO.ProductCompany productCompany)
        {
            if (id != productCompany.Id)
            {
                return BadRequest();
            }

            _bll.ProductCompanies.Update(v1_0_Mapper.ProductCompanyMapper.MapFromExternal(productCompany));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/ProductCompany
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductCompany>> PostProductCompany(v1_0_DTO.ProductCompany productCompany)
        {
            productCompany = v1_0_Mapper.ProductCompanyMapper.MapFromBLL(
                _bll.ProductCompanies.Add(v1_0_Mapper.ProductCompanyMapper.MapFromExternal(productCompany)));
            await _bll.SaveChangesAsync();

            productCompany = v1_0_Mapper.ProductCompanyMapper.MapFromBLL(
                _bll.ProductCompanies.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.ProductCompanyMapper.MapFromExternal(productCompany)));

            return CreatedAtAction("GetProductCompany", new { id = productCompany.Id }, productCompany);
        }

        // DELETE: api/ProductCompany/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductCompany>> DeleteProductCompany(int id)
        {
            _bll.ProductCompanies.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
