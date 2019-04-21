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
    public class HerbPartController : ControllerBase
    {
        private readonly IAppBll _bll;

        public HerbPartController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/HerbPart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerbPart>>> GetHerbParts()
        {
            return await _bll.HerbParts.AllAsync();
        }

        // GET: api/HerbPart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HerbPart>> GetHerbPart(int id)
        {
            var herbPart = await _bll.HerbParts.FindAsync(id);

            if (herbPart == null)
            {
                return NotFound();
            }

            return herbPart;
        }

        // PUT: api/HerbPart/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutHerbPart(int id, HerbPart herbPart)
        {
            if (id != herbPart.Id)
            {
                return BadRequest();
            }

            _bll.HerbParts.Update(herbPart);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/HerbPart
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<HerbPart>> PostHerbPart(HerbPart herbPart)
        {
            await _bll.HerbParts.AddAsync(herbPart);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetHerbPart", new { id = herbPart.Id }, herbPart);
        }

        // DELETE: api/HerbPart/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<HerbPart>> DeleteHerbPart(int id)
        {
            var herbPart = await _bll.HerbParts.FindAsync(id);
            if (herbPart == null)
            {
                return NotFound();
            }

            _bll.HerbParts.Remove(herbPart);
            await _bll.SaveChangesAsync();

            return herbPart;
        }
    }
}
