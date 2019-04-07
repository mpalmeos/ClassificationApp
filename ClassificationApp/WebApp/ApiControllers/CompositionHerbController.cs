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
    public class CompositionHerbController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public CompositionHerbController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/CompositionHerb
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositionHerb>>> GetCompositionHerbs()
        {
            var res = await _uow.CompositionHerbs.AllAsync();
            return Ok(res);
        }

        // GET: api/CompositionHerb/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompositionHerb>> GetCompositionHerb(int id)
        {
            var compositionHerb = await _uow.CompositionHerbs.FindAsync(id);

            if (compositionHerb == null)
            {
                return NotFound();
            }

            return compositionHerb;
        }

        // PUT: api/CompositionHerb/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCompositionHerb(int id, CompositionHerb compositionHerb)
        {
            if (id != compositionHerb.Id)
            {
                return BadRequest();
            }

            _uow.CompositionHerbs.Update(compositionHerb);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/CompositionHerb
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompositionHerb>> PostCompositionHerb(CompositionHerb compositionHerb)
        {
            await _uow.CompositionHerbs.AddAsync(compositionHerb);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetCompositionHerb", new { id = compositionHerb.Id }, compositionHerb);
        }

        // DELETE: api/CompositionHerb/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompositionHerb>> DeleteCompositionHerb(int id)
        {
            var compositionHerb = await _uow.CompositionHerbs.FindAsync(id);
            if (compositionHerb == null)
            {
                return NotFound();
            }

            _uow.CompositionHerbs.Remove(compositionHerb);
            await _uow.SaveChangesAsync();

            return compositionHerb;
        }
    }
}
