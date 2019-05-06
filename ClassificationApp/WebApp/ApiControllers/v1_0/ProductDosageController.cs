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
    public class ProductDosageController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductDosageController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/ProductDosage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.ProductDosage>>> GetProductDosages()
        {
            return (await _bll.ProductDosages.AllAsync())
                .Select(e => v1_0_Mapper.ProductDosageMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/ProductDosage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.ProductDosage>> GetProductDosage(int id)
        {
            var productDosage = 
                v1_0_Mapper.ProductDosageMapper.MapFromBLL(await _bll.ProductDosages.FindAsync(id));

            if (productDosage == null)
            {
                return NotFound();
            }

            return productDosage;
        }

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

        // POST: api/ProductDosage
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductDosage>> PostProductDosage(v1_0_DTO.ProductDosage productDosage)
        {
            productDosage = v1_0_Mapper.ProductDosageMapper.MapFromBLL(
                _bll.ProductDosages.Add(v1_0_Mapper.ProductDosageMapper.MapFromExternal(productDosage)));
            await _bll.SaveChangesAsync();

            productDosage = v1_0_Mapper.ProductDosageMapper.MapFromBLL(
                _bll.ProductDosages.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.ProductDosageMapper.MapFromExternal(productDosage)));

            return CreatedAtAction("GetProductDosage", new { id = productDosage.Id }, productDosage);
        }

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
