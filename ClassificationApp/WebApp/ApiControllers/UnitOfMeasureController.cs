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
    public class UnitOfMeasureController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public UnitOfMeasureController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/UnitOfMeasure
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasure>>> GetUnitOfMeasures()
        {
            var res = await _uow.UnitOfMeasures.AllAsync();
            return Ok(res);
        }

        // GET: api/UnitOfMeasure/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfMeasure>> GetUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _uow.UnitOfMeasures.FindAsync(id);

            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            return unitOfMeasure;
        }

        // PUT: api/UnitOfMeasure/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitOfMeasure(int id, UnitOfMeasure unitOfMeasure)
        {
            if (id != unitOfMeasure.Id)
            {
                return BadRequest();
            }

            _uow.UnitOfMeasures.Update(unitOfMeasure);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/UnitOfMeasure
        [HttpPost]
        public async Task<ActionResult<UnitOfMeasure>> PostUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            await _uow.UnitOfMeasures.AddAsync(unitOfMeasure);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetUnitOfMeasure", new { id = unitOfMeasure.Id }, unitOfMeasure);
        }

        // DELETE: api/UnitOfMeasure/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnitOfMeasure>> DeleteUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _uow.UnitOfMeasures.FindAsync(id);
            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            _uow.UnitOfMeasures.Remove(unitOfMeasure);
            await _uow.SaveChangesAsync();

            return unitOfMeasure;
        }
    }
}
