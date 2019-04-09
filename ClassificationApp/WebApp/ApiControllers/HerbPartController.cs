using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IAppUnitOfWork _uow;

        public HerbPartController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/HerbPart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerbPart>>> GetHerbParts()
        {
            var res = await _uow.HerbParts.AllAsync();
            return Ok(res);
        }

        // GET: api/HerbPart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HerbPart>> GetHerbPart(int id)
        {
            var herbPart = await _uow.HerbParts.FindAsync(id);

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

            _uow.HerbParts.Update(herbPart);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/HerbPart
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<HerbPart>> PostHerbPart(HerbPart herbPart)
        {
            await _uow.HerbParts.AddAsync(herbPart);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetHerbPart", new { id = herbPart.Id }, herbPart);
        }

        // DELETE: api/HerbPart/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<HerbPart>> DeleteHerbPart(int id)
        {
            var herbPart = await _uow.HerbParts.FindAsync(id);
            if (herbPart == null)
            {
                return NotFound();
            }

            _uow.HerbParts.Remove(herbPart);
            await _uow.SaveChangesAsync();

            return herbPart;
        }
    }
}
