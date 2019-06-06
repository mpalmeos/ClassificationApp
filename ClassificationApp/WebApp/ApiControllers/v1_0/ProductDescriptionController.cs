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
    public class ProductDescriptionController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductDescriptionController(IAppBll bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get array of ProductDescriptions.
        /// </summary>
        /// <returns>Array of ProductDescriptions.</returns>
        // GET: api/ProductDescription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.ProductDescription>>> GetProductDescriptions()
        {
            return (await _bll.ProductDescriptions.AllAsync())
                .Select(e => v1_0_Mapper.ProductDescriptionMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get specific ProductDescription by ID.
        /// </summary>
        /// <param name="id">ID of ProductDescription to be retrieved.</param>
        /// <returns>Specific ProductDescription by ID.</returns>
        // GET: api/ProductDescription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.ProductDescription>> GetProductDescription(int id)
        {
            var productDescription = 
                v1_0_Mapper.ProductDescriptionMapper.MapFromBLL(await _bll.ProductDescriptions.FindAllPerEntity(id));

            if (productDescription == null)
            {
                return NotFound();
            }

            return productDescription;
        }

        /// <summary>
        /// Modify existing ProductDescription.
        /// </summary>
        /// <param name="id">ID of ProductDescription to be modified.</param>
        /// <param name="productDescription">ProductDescription to be modified.</param>
        /// <returns>Does not return anything.</returns>
        // PUT: api/ProductDescription/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProductDescription(int id, v1_0_DTO.ProductDescription productDescription)
        {
            if (id != productDescription.Id)
            {
                return BadRequest();
            }

            _bll.ProductDescriptions.Update(v1_0_Mapper.ProductDescriptionMapper.MapFromExternal(productDescription));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Add new ProductDescription to database.
        /// </summary>
        /// <param name="productDescription">ProductDescription to be added to the database.</param>
        /// <returns>New ProductDescription and ID.</returns>
        // POST: api/ProductDescription
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductDescription>> PostProductDescription(v1_0_DTO.ProductDescription productDescription)
        {
            productDescription = v1_0_Mapper.ProductDescriptionMapper.MapFromBLL(
                await _bll.ProductDescriptions.AddAsync(v1_0_Mapper.ProductDescriptionMapper.MapFromExternal(productDescription)));
            await _bll.SaveChangesAsync();

            productDescription = v1_0_Mapper.ProductDescriptionMapper.MapFromBLL(
                _bll.ProductDescriptions.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.ProductDescriptionMapper.MapFromExternal(productDescription)));

            return CreatedAtAction("GetProductDescription", new {version = HttpContext.GetRequestedApiVersion().ToString(), id = productDescription.Id }, productDescription);
        }

        /// <summary>
        /// Delete specific ProductDescription from database (hard delete).
        /// </summary>
        /// <param name="id">ID of ProductDescription to be deleted.</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/ProductDescription/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductDescription>> DeleteProductDescription(int id)
        {
            _bll.ProductDescriptions.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
