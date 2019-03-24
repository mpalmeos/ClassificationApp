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
    public class HerbMedicinalController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public HerbMedicinalController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/HerbMedicinal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerbMedicinal>>> GetHerbMedicinals()
        {
            var res = await _uow.HerbMedicinals.AllAsync();
            return Ok(res);
        }

        // GET: api/HerbMedicinal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HerbMedicinal>> GetHerbMedicinal(int id)
        {
            var herbMedicinal = await _uow.HerbMedicinals.FindAsync(id);

            if (herbMedicinal == null)
            {
                return NotFound();
            }

            return herbMedicinal;
        }

        // PUT: api/HerbMedicinal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHerbMedicinal(int id, HerbMedicinal herbMedicinal)
        {
            if (id != herbMedicinal.Id)
            {
                return BadRequest();
            }

            _uow.HerbMedicinals.Update(herbMedicinal);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/HerbMedicinal
        [HttpPost]
        public async Task<ActionResult<HerbMedicinal>> PostHerbMedicinal(HerbMedicinal herbMedicinal)
        {
            await _uow.HerbMedicinals.AddAsync(herbMedicinal);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetHerbMedicinal", new { id = herbMedicinal.Id }, herbMedicinal);
        }

        // DELETE: api/HerbMedicinal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HerbMedicinal>> DeleteHerbMedicinal(int id)
        {
            var herbMedicinal = await _uow.HerbMedicinals.FindAsync(id);
            if (herbMedicinal == null)
            {
                return NotFound();
            }

            _uow.HerbMedicinals.Remove(herbMedicinal);
            await _uow.SaveChangesAsync();

            return herbMedicinal;
        }
    }
}
