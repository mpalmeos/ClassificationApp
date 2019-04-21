using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
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
    public class SubstanceController : ControllerBase
    {
        private readonly IAppBll _bll;

        public SubstanceController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/Substance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Substance>>> GetSubstances()
        {
            return await _bll.Substances.AllAsync();
        }

        // GET: api/Substance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Substance>> GetSubstance(int id)
        {
            var substance = await _bll.Substances.FindAsync(id);

            if (substance == null)
            {
                return NotFound();
            }

            return substance;
        }

        // PUT: api/Substance/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutSubstance(int id, Substance substance)
        {
            if (id != substance.Id)
            {
                return BadRequest();
            }

            _bll.Substances.Update(substance);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Substance
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Substance>> PostSubstance(Substance substance)
        {
            await _bll.Substances.AddAsync(substance);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSubstance", new { id = substance.Id }, substance);
        }

        // DELETE: api/Substance/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Substance>> DeleteSubstance(int id)
        {
            var substance = await _bll.Substances.FindAsync(id);
            if (substance == null)
            {
                return NotFound();
            }

            _bll.Substances.Remove(substance);
            await _bll.SaveChangesAsync();

            return substance;
        }
    }
}
