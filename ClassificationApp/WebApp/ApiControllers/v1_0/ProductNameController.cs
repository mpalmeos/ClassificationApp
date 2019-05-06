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
    public class ProductNameController : ControllerBase
    {
        private readonly IAppBll _bll;

        public ProductNameController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/ProductName
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.ProductName>>> GetProductNames()
        {
            return (await _bll.ProductNames.AllAsync())
                .Select(e => v1_0_Mapper.ProductNameMapper.MapFromBLL(e)).ToList();
        }

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

        // POST: api/ProductName
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.ProductName>> PostProductName(v1_0_DTO.ProductName productName)
        {
            productName = v1_0_Mapper.ProductNameMapper.MapFromBLL(
                _bll.ProductNames.Add(v1_0_Mapper.ProductNameMapper.MapFromExternal(productName)));
            await _bll.SaveChangesAsync();

            productName = v1_0_Mapper.ProductNameMapper.MapFromBLL(
                _bll.ProductNames.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.ProductNameMapper.MapFromExternal(productName)));

            return CreatedAtAction("GetProductName", new { id = productName.Id }, productName);
        }

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
