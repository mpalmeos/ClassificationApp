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
    public class ProductNameController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductNameController(IAppBll bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get array of ProductNames.
        /// </summary>
        /// <returns>Array of ProductNames.</returns>
        // GET: api/ProductName
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.ProductName>>> GetProductNames()
        {
            return (await _bll.ProductNames.AllAsync())
                .Select(e => v1_0_Mapper.ProductNameMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get specific ProductName by ID.
        /// </summary>
        /// <param name="id">ID of ProductName to be retrieved.</param>
        /// <returns>Specific ProductName by ID.</returns>
        // GET: api/ProductName/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.ProductName>> GetProductName(int id)
        {
            var productName = 
                v1_0_Mapper.ProductNameMapper.MapFromBLL(await _bll.ProductNames.FindAsync(id));

            if (productName == null)
            {
                return NotFound();
            }

            return productName;
        }

        /// <summary>
        /// Modify existing ProductName.
        /// </summary>
        /// <param name="id">ID of ProductName to modify.</param>
        /// <param name="productName">ProductName to modify.</param>
        /// <returns>Does not return anything.</returns>
        // PUT: api/ProductName/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductName(int id, v1_0_DTO.ProductName productName)
        {
            if (id != productName.Id)
            {
                return BadRequest();
            }

            _bll.ProductNames.Update(v1_0_Mapper.ProductNameMapper.MapFromExternal(productName));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Add new ProductName to database.
        /// </summary>
        /// <param name="productName">ProductName to be added.</param>
        /// <returns>New ProductName and ID.</returns>
        // POST: api/ProductName
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductName>> PostProductName(v1_0_DTO.ProductName productName)
        {
            productName = v1_0_Mapper.ProductNameMapper.MapFromBLL(
                await _bll.ProductNames.AddAsync(v1_0_Mapper.ProductNameMapper.MapFromExternal(productName)));
            
            await _bll.SaveChangesAsync();

            productName = v1_0_Mapper.ProductNameMapper.MapFromBLL(
                _bll.ProductNames.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.ProductNameMapper.MapFromExternal(productName)));
            
            return CreatedAtAction(nameof(GetProductName), new { 
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = productName.Id }, 
                productName);
        }

        /// <summary>
        /// Delete specific ProductName from database (hard delete).
        /// </summary>
        /// <param name="id">ID of ProductName to be deleted.</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/ProductName/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductName>> DeleteProductName(int id)
        {
            _bll.ProductNames.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
