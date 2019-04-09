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
    public class SubstanceMedicinalController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public SubstanceMedicinalController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/SubstanceMedicinal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubstanceMedicinal>>> GetSubstanceMedicinals()
        {
            var res = await _uow.SubstanceMedicinals.AllAsync();
            return Ok(res);
        }

        // GET: api/SubstanceMedicinal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubstanceMedicinal>> GetSubstanceMedicinal(int id)
        {
            var substanceMedicinal = await _uow.SubstanceMedicinals.FindAsync(id);

            if (substanceMedicinal == null)
            {
                return NotFound();
            }

            return substanceMedicinal;
        }

        // PUT: api/SubstanceMedicinal/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutSubstanceMedicinal(int id, SubstanceMedicinal substanceMedicinal)
        {
            if (id != substanceMedicinal.Id)
            {
                return BadRequest();
            }

            _uow.SubstanceMedicinals.Update(substanceMedicinal);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/SubstanceMedicinal
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<SubstanceMedicinal>> PostSubstanceMedicinal(SubstanceMedicinal substanceMedicinal)
        {
            await _uow.SubstanceMedicinals.AddAsync(substanceMedicinal);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSubstanceMedicinal", new { id = substanceMedicinal.Id }, substanceMedicinal);
        }

        // DELETE: api/SubstanceMedicinal/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<SubstanceMedicinal>> DeleteSubstanceMedicinal(int id)
        {
            var substanceMedicinal = await _uow.SubstanceMedicinals.FindAsync(id);
            if (substanceMedicinal == null)
            {
                return NotFound();
            }

            _uow.SubstanceMedicinals.Remove(substanceMedicinal);
            await _uow.SaveChangesAsync();

            return substanceMedicinal;
        }
    }
}
