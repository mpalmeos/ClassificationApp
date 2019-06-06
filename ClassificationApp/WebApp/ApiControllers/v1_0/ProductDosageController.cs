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
    public class ProductDosageController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductDosageController(IAppBll bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get array of ProductDosages.
        /// </summary>
        /// <returns>Array of ProductDosages.</returns>
        // GET: api/ProductDosage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.ProductDosage>>> GetProductDosages()
        {
            return (await _bll.ProductDosages.AllAsync())
                .Select(e => v1_0_Mapper.ProductDosageMapper.MapFromBLL(e)).ToList();
        }
        
        /// <summary>
        /// Get specific ProductDosage by ID.
        /// </summary>
        /// <param name="id">ID of ProductDosage to be retrieved.</param>
        /// <returns>Specific ProductDosage by ID.</returns>
        // GET: api/ProductDosage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.ProductDosage>> GetProductDosage(int id)
        {
            var productDosage = 
                v1_0_Mapper.ProductDosageMapper.MapFromBLL(await _bll.ProductDosages.FindAllPerEntity(id));

            if (productDosage == null)
            {
                return NotFound();
            }

            return productDosage;
        }

        /// <summary>
        /// Modify existing ProductDosage.
        /// </summary>
        /// <param name="id">ID of ProductDosage to be modified.</param>
        /// <param name="productDosage">ProductDosage to be modified.</param>
        /// <returns>Does not return anything.</returns>
        // PUT: api/ProductDosage/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductDosage(int id, v1_0_DTO.ProductDosage productDosage)
        {
            if (id != productDosage.Id)
            {
                return BadRequest();
            }

            _bll.ProductDosages.Update(v1_0_Mapper.ProductDosageMapper.MapFromExternal(productDosage));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Add ned ProductDosage to database.
        /// </summary>
        /// <param name="productDosage">ProductDosage to be added.</param>
        /// <returns>New productDosage and ID.</returns>
        // POST: api/ProductDosage
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductDosage>> PostProductDosage(v1_0_DTO.ProductDosage productDosage)
        {
            productDosage = v1_0_Mapper.ProductDosageMapper.MapFromBLL(
                await _bll.ProductDosages.AddAsync(v1_0_Mapper.ProductDosageMapper.MapFromExternal(productDosage)));
            await _bll.SaveChangesAsync();

            productDosage = v1_0_Mapper.ProductDosageMapper.MapFromBLL(
                _bll.ProductDosages.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.ProductDosageMapper.MapFromExternal(productDosage)));

            return CreatedAtAction("GetProductDosage", new {version = HttpContext.GetRequestedApiVersion().ToString(), id = productDosage.Id }, productDosage);
        }

        /// <summary>
        /// Delete specific ProductDosage from database (hard delete).
        /// </summary>
        /// <param name="id">ID of ProductDosage to be deleted.</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/ProductDosage/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductDosage>> DeleteProductDosage(int id)
        {
            _bll.ProductDosages.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
