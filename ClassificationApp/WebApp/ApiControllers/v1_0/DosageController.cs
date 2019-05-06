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
    public class DosageController : ControllerBase
    {
        private readonly IAppBll _bll;

        public DosageController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/Dosage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<v1_0_DTO.Dosage>>> GetDosages()
        {
            return (await _bll.Dosages.AllAsync())
                .Select(e => v1_0_Mapper.DosageMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Dosage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<v1_0_DTO.Dosage>> GetDosage(int id)
        {
            var dosage = 
                v1_0_Mapper.DosageMapper.MapFromBLL(await _bll.Dosages.FindAsync(id));

            if (dosage == null)
            {
                return NotFound();
            }

            return dosage;
        }

        // PUT: api/Dosage/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutDosage(int id, v1_0_DTO.Dosage dosage)
        {
            if (id != dosage.Id)
            {
                return BadRequest();
            }

            _bll.Dosages.Update(v1_0_Mapper.DosageMapper.MapFromExternal(dosage));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Dosage
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.Dosage>> PostDosage(v1_0_DTO.Dosage dosage)
        {
            dosage = v1_0_Mapper.DosageMapper.MapFromBLL(
                _bll.Dosages.Add(v1_0_Mapper.DosageMapper.MapFromExternal(dosage)));
            await _bll.SaveChangesAsync();

            dosage = v1_0_Mapper.DosageMapper.MapFromBLL(
                _bll.Dosages.GetUpdatesAfterUOWSaveChanges(
                    v1_0_Mapper.DosageMapper.MapFromExternal(dosage)));;

            return CreatedAtAction("GetDosage", new { id = dosage.Id }, dosage);
        }

        // DELETE: api/Dosage/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<v1_0_DTO.Dosage>> DeleteDosage(int id)
        {
            _bll.Dosages.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
