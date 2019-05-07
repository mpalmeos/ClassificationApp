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
    public class ProductClassificationController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductClassificationController(IAppBll bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get array of ProductClassifications.
        /// </summary>
        /// <returns>Array of ProductClassification.</returns>
        // GET: api/ProductClassification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.ProductClassification>>> GetProductClassifications()
        {
            return (await _bll.ProductClassifications.AllAsync())
                .Select(e => v1_0_Mapper.ProductClassificationMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get ProductClassification by ID.
        /// </summary>
        /// <param name="id">ID of ProductClassification to retrieve.</param>
        /// <returns>Specific ProductClassification by ID.</returns>
        // GET: api/ProductClassification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.ProductClassification>> GetProductClassification(int id)
        {
            var productClassification = 
                v1_0_Mapper.ProductClassificationMapper.MapFromBLL(await _bll.ProductClassifications.FindAsync(id));

            if (productClassification == null)
            {
                return NotFound();
            }

            return productClassification;
        }

        /// <summary>
        /// Modify existing ProductClassification.
        /// </summary>
        /// <param name="id">ID of ProductClassification to be modified.</param>
        /// <param name="productClassification">ProductClassification to be modified.</param>
        /// <returns>Does not return anything.</returns>
        // PUT: api/ProductClassification/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductClassification(int id, v1_0_DTO.ProductClassification productClassification)
        {
            if (id != productClassification.Id)
            {
                return BadRequest();
            }

            _bll.ProductClassifications
                .Update(v1_0_Mapper.ProductClassificationMapper
                    .MapFromExternal(productClassification));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Add new ProductClassification to database.
        /// </summary>
        /// <param name="productClassification">ProductClassification to be added.</param>
        /// <returns>New ProductClassification and ID.</returns>
        // POST: api/ProductClassification
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductClassification>> PostProductClassification(v1_0_DTO.ProductClassification productClassification)
        {
            productClassification = v1_0_Mapper.ProductClassificationMapper.MapFromBLL(
                _bll.ProductClassifications
                    .Add(v1_0_Mapper.ProductClassificationMapper.MapFromExternal(productClassification)));
            await _bll.SaveChangesAsync();

            productClassification = v1_0_Mapper.ProductClassificationMapper.MapFromBLL(
                _bll.ProductClassifications.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.ProductClassificationMapper.MapFromExternal(productClassification)));

            return CreatedAtAction("GetProductClassification", new { id = productClassification.Id }, productClassification);
        }

        /// <summary>
        /// Delete specific ProductClassification from database (hard delete).
        /// </summary>
        /// <param name="id">ID of ProductClassification to be deleted.</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/ProductClassification/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductClassification>> DeleteProductClassification(int id)
        {
            _bll.ProductClassifications.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
