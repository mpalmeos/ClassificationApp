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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DosageController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public DosageController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Dosage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dosage>>> GetDosages()
        {
            var res = await _uow.Dosages.AllAsync();
            return Ok(res);
        }

        // GET: api/Dosage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dosage>> GetDosage(int id)
        {
            var dosage = await _uow.Dosages.FindAsync(id);

            if (dosage == null)
            {
                return NotFound();
            }

            return dosage;
        }

        // PUT: api/Dosage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDosage(int id, Dosage dosage)
        {
            if (id != dosage.Id)
            {
                return BadRequest();
            }

            _uow.Dosages.Update(dosage);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Dosage
        [HttpPost]
        public async Task<ActionResult<Dosage>> PostDosage(Dosage dosage)
        {
            await _uow.Dosages.AddAsync(dosage);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetDosage", new { id = dosage.Id }, dosage);
        }

        // DELETE: api/Dosage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dosage>> DeleteDosage(int id)
        {
            var dosage = await _uow.Dosages.FindAsync(id);
            if (dosage == null)
            {
                return NotFound();
            }

            _uow.Dosages.Remove(dosage);
            await _uow.SaveChangesAsync();

            return dosage;
        }
    }
}
