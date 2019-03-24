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

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositionController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public CompositionController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Composition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Composition>>> GetCompositions()
        {
            var res = await _uow.Compositions.AllAsync();
            return Ok(res);
        }

        // GET: api/Composition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Composition>> GetComposition(int id)
        {
            var composition = await _uow.Compositions.FindAsync(id);

            if (composition == null)
            {
                return NotFound();
            }

            return composition;
        }

        // PUT: api/Composition/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComposition(int id, Composition composition)
        {
            if (id != composition.Id)
            {
                return BadRequest();
            }

            _uow.Compositions.Update(composition);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Composition
        [HttpPost]
        public async Task<ActionResult<Composition>> PostComposition(Composition composition)
        {
            await _uow.Compositions.AddAsync(composition);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetComposition", new { id = composition.Id }, composition);
        }

        // DELETE: api/Composition/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Composition>> DeleteComposition(int id)
        {
            var composition = await _uow.Compositions.FindAsync(id);
            if (composition == null)
            {
                return NotFound();
            }

            _uow.Compositions.Remove(composition);
            await _uow.SaveChangesAsync();

            return composition;
        }
    }
}
