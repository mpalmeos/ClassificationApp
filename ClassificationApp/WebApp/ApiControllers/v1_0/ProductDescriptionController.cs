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

        // GET: api/ProductDescription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.ProductDescription>>> GetProductDescriptions()
        {
            return (await _bll.ProductDescriptions.AllAsync())
                .Select(e => v1_0_Mapper.ProductDescriptionMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/ProductDescription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.ProductDescription>> GetProductDescription(int id)
        {
            var productDescription = 
                v1_0_Mapper.ProductDescriptionMapper.MapFromBLL(await _bll.ProductDescriptions.FindAsync(id));

            if (productDescription == null)
            {
                return NotFound();
            }

            return productDescription;
        }

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

        // POST: api/ProductDescription
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductDescription>> PostProductDescription(v1_0_DTO.ProductDescription productDescription)
        {
            productDescription = v1_0_Mapper.ProductDescriptionMapper.MapFromBLL(
                _bll.ProductDescriptions.Add(v1_0_Mapper.ProductDescriptionMapper.MapFromExternal(productDescription)));
            await _bll.SaveChangesAsync();

            productDescription = v1_0_Mapper.ProductDescriptionMapper.MapFromBLL(
                _bll.ProductDescriptions.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.ProductDescriptionMapper.MapFromExternal(productDescription)));

            return CreatedAtAction("GetProductDescription", new { id = productDescription.Id }, productDescription);
        }

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
