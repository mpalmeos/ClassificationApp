using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerbMedicinalController : ControllerBase
    {
        private readonly IAppBll _bll;

        public HerbMedicinalController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/HerbMedicinal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerbMedicinal>>> GetHerbMedicinals()
        {
            return await _bll.HerbMedicinals.AllAsync();
        }

        // GET: api/HerbMedicinal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HerbMedicinal>> GetHerbMedicinal(int id)
        {
            var herbMedicinal = await _bll.HerbMedicinals.FindAsync(id);

            if (herbMedicinal == null)
            {
                return NotFound();
            }

            return herbMedicinal;
        }

        // PUT: api/HerbMedicinal/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutHerbMedicinal(int id, HerbMedicinal herbMedicinal)
        {
            if (id != herbMedicinal.Id)
            {
                return BadRequest();
            }

            _bll.HerbMedicinals.Update(herbMedicinal);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/HerbMedicinal
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<HerbMedicinal>> PostHerbMedicinal(HerbMedicinal herbMedicinal)
        {
            await _bll.HerbMedicinals.AddAsync(herbMedicinal);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetHerbMedicinal", new { id = herbMedicinal.Id }, herbMedicinal);
        }

        // DELETE: api/HerbMedicinal/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<HerbMedicinal>> DeleteHerbMedicinal(int id)
        {
            var herbMedicinal = await _bll.HerbMedicinals.FindAsync(id);
            if (herbMedicinal == null)
            {
                return NotFound();
            }

            _bll.HerbMedicinals.Remove(herbMedicinal);
            await _bll.SaveChangesAsync();

            return herbMedicinal;
        }
    }
}
