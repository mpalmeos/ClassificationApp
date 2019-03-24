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
    public class CompositionSubstanceController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public CompositionSubstanceController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/CompositionSubstance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositionSubstance>>> GetCompositionSubstances()
        {
            var res = await _uow.CompositionSubstances.AllAsync();
            return Ok(res);
        }

        // GET: api/CompositionSubstance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompositionSubstance>> GetCompositionSubstance(int id)
        {
            var compositionSubstance = await _uow.CompositionSubstances.FindAsync(id);

            if (compositionSubstance == null)
            {
                return NotFound();
            }

            return compositionSubstance;
        }

        // PUT: api/CompositionSubstance/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompositionSubstance(int id, CompositionSubstance compositionSubstance)
        {
            if (id != compositionSubstance.Id)
            {
                return BadRequest();
            }

            _uow.CompositionSubstances.Update(compositionSubstance);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/CompositionSubstance
        [HttpPost]
        public async Task<ActionResult<CompositionSubstance>> PostCompositionSubstance(CompositionSubstance compositionSubstance)
        {
            await _uow.CompositionSubstances.AddAsync(compositionSubstance);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetCompositionSubstance", new { id = compositionSubstance.Id }, compositionSubstance);
        }

        // DELETE: api/CompositionSubstance/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompositionSubstance>> DeleteCompositionSubstance(int id)
        {
            var compositionSubstance = await _uow.CompositionSubstances.FindAsync(id);
            if (compositionSubstance == null)
            {
                return NotFound();
            }

            _uow.CompositionSubstances.Remove(compositionSubstance);
            await _uow.SaveChangesAsync();

            return compositionSubstance;
        }
    }
}
