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
    public class SubstanceController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public SubstanceController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Substance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Substance>>> GetSubstances()
        {
            var res = await _uow.Substances.AllAsync();
            return Ok(res);
        }

        // GET: api/Substance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Substance>> GetSubstance(int id)
        {
            var substance = await _uow.Substances.FindAsync(id);

            if (substance == null)
            {
                return NotFound();
            }

            return substance;
        }

        // PUT: api/Substance/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubstance(int id, Substance substance)
        {
            if (id != substance.Id)
            {
                return BadRequest();
            }

            _uow.Substances.Update(substance);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Substance
        [HttpPost]
        public async Task<ActionResult<Substance>> PostSubstance(Substance substance)
        {
            await _uow.Substances.AddAsync(substance);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSubstance", new { id = substance.Id }, substance);
        }

        // DELETE: api/Substance/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Substance>> DeleteSubstance(int id)
        {
            var substance = await _uow.Substances.FindAsync(id);
            if (substance == null)
            {
                return NotFound();
            }

            _uow.Substances.Remove(substance);
            await _uow.SaveChangesAsync();

            return substance;
        }
    }
}
