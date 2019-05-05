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
    public class SubstanceMedicinalController : ControllerBase
    {
        private readonly IAppBll _bll;

        public SubstanceMedicinalController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/SubstanceMedicinal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubstanceMedicinal>>> GetSubstanceMedicinals()
        {
            return await _bll.SubstanceMedicinals.AllAsync();
        }

        // GET: api/SubstanceMedicinal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubstanceMedicinal>> GetSubstanceMedicinal(int id)
        {
            var substanceMedicinal = await _bll.SubstanceMedicinals.FindAsync(id);

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

            _bll.SubstanceMedicinals.Update(substanceMedicinal);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/SubstanceMedicinal
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<SubstanceMedicinal>> PostSubstanceMedicinal(SubstanceMedicinal substanceMedicinal)
        {
            await _bll.SubstanceMedicinals.AddAsync(substanceMedicinal);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSubstanceMedicinal", new { id = substanceMedicinal.Id }, substanceMedicinal);
        }

        // DELETE: api/SubstanceMedicinal/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<SubstanceMedicinal>> DeleteSubstanceMedicinal(int id)
        {
            var substanceMedicinal = await _bll.SubstanceMedicinals.FindAsync(id);
            if (substanceMedicinal == null)
            {
                return NotFound();
            }

            _bll.SubstanceMedicinals.Remove(substanceMedicinal);
            await _bll.SaveChangesAsync();

            return substanceMedicinal;
        }
    }
}
