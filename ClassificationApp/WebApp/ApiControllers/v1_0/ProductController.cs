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
    public class ProductController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductController(IAppBll bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get array of all Products.
        /// </summary>
        /// <returns>Array of Products.</returns>
        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.Product>>> GetProducts()
        {
            return (await _bll.Products.AllAsync())
                .Select(e => v1_0_Mapper.ProductMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get specific Product by ID.
        /// </summary>
        /// <param name="id">ID of Product to be retrieved.</param>
        /// <returns>Specific Product by ID.</returns>
        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.Product>> GetProduct(int id)
        {
            var product = 
                v1_0_Mapper.ProductMapper.MapFromBLL(await _bll.Products.FindAsync(id));

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Modify specific Product by ID.
        /// </summary>
        /// <param name="id">ID of Product to be modified.</param>
        /// <param name="product">Product to be modified.</param>
        /// <returns>Does not return anything.</returns>
        // PUT: api/Product/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProduct(int id, v1_0_DTO.Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _bll.Products.Update(v1_0_Mapper.ProductMapper.MapFromExternal(product));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Add new Product to database.
        /// </summary>
        /// <param name="product">Product to be added to the database.</param>
        /// <returns>New product and ID.</returns>
        // POST: api/Product
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.Product>> PostProduct(v1_0_DTO.Product product)
        {
            product = v1_0_Mapper.ProductMapper.MapFromBLL(
                _bll.Products.Add(v1_0_Mapper.ProductMapper.MapFromExternal(product)));
            await _bll.SaveChangesAsync();

            product = v1_0_Mapper.ProductMapper.MapFromBLL(
                _bll.Products.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.ProductMapper.MapFromExternal(product)));

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        /// <summary>
        /// Delete specific Product from database (hard delete).
        /// </summary>
        /// <param name="id">ID of Product to be deleted.</param>
        /// <returns>Does not return anything.</returns>
        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.Product>> DeleteProduct(int id)
        {
            _bll.Products.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
