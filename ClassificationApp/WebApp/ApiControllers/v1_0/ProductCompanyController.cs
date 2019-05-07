using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
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

        /// <summary>
        /// Get array of ProductCompanies.
        /// </summary>
        /// <returns>Array of ProductCompanies.</returns>
        // GET: api/ProductCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.ProductCompany>>> GetProductCompanies()
        {
            return (await _bll.ProductCompanies.AllAsync())
                .Select(e => v1_0_Mapper.ProductCompanyMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get specific ProductCompany by ID.
        /// </summary>
        /// <param name="id">ID for ProductCompany to be retrieved.</param>
        /// <returns>ProductCompany by ID.</returns>
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

        /// <summary>
        /// Modify existing ProductCompany.
        /// </summary>
        /// <param name="id">ID of ProductCompany to be modified.</param>
        /// <param name="productCompany">ProductCompany to be modified.</param>
        /// <returns>Does not return anything.</returns>
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

        /// <summary>
        /// Add new ProductCompany to database.
        /// </summary>
        /// <param name="productCompany">ProductCompany to be added.</param>
        /// <returns>New ProductCompany and ID.</returns>
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

        /// <summary>
        /// Delete specific ProductCompany from database (hard delete).
        /// </summary>
        /// <param name="id">ID of ProductCompany to be deleted.</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/ProductCompany/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductCompany>> DeleteProductCompany(int id)
        {
            _bll.ProductCompanies.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
