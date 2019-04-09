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
    public class HerbController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public HerbController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Herb
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Herb>>> GetHerbs()
        {
            var res = await _uow.Herbs.AllAsync();
            return Ok(res);
        }

        // GET: api/Herb/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Herb>> GetHerb(int id)
        {
            var herb = await _uow.Herbs.FindAsync(id);

            if (herb == null)
            {
                return NotFound();
            }

            return herb;
        }

        // PUT: api/Herb/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutHerb(int id, Herb herb)
        {
            if (id != herb.Id)
            {
                return BadRequest();
            }

            _uow.Herbs.Update(herb);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Herb
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Herb>> PostHerb(Herb herb)
        {
            await _uow.Herbs.AddAsync(herb);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetHerb", new { id = herb.Id }, herb);
        }

        // DELETE: api/Herb/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Herb>> DeleteHerb(int id)
        {
            var herb = await _uow.Herbs.FindAsync(id);
            if (herb == null)
            {
                return NotFound();
            }

            _uow.Herbs.Remove(herb);
            await _uow.SaveChangesAsync();

            return herb;
        }
    }
}
