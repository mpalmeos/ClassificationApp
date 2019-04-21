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
    public class CompositionSubstanceController : ControllerBase
    {
        private readonly IAppBll _bll;

        public CompositionSubstanceController(IAppBll bll)
        {
            _bll = bll;
        }


        // GET: api/CompositionSubstance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositionSubstance>>> GetCompositionSubstances()
        {
            return await _bll.CompositionSubstances.AllAsync();
        }

        // GET: api/CompositionSubstance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompositionSubstance>> GetCompositionSubstance(int id)
        {
            var compositionSubstance = await _bll.CompositionSubstances.FindAsync(id);

            if (compositionSubstance == null)
            {
                return NotFound();
            }

            return compositionSubstance;
        }

        // PUT: api/CompositionSubstance/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCompositionSubstance(int id, CompositionSubstance compositionSubstance)
        {
            if (id != compositionSubstance.Id)
            {
                return BadRequest();
            }

            _bll.CompositionSubstances.Update(compositionSubstance);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/CompositionSubstance
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompositionSubstance>> PostCompositionSubstance(CompositionSubstance compositionSubstance)
        {
            await _bll.CompositionSubstances.AddAsync(compositionSubstance);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetCompositionSubstance", new { id = compositionSubstance.Id }, compositionSubstance);
        }

        // DELETE: api/CompositionSubstance/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompositionSubstance>> DeleteCompositionSubstance(int id)
        {
            var compositionSubstance = await _bll.CompositionSubstances.FindAsync(id);
            if (compositionSubstance == null)
            {
                return NotFound();
            }

            _bll.CompositionSubstances.Remove(compositionSubstance);
            await _bll.SaveChangesAsync();

            return compositionSubstance;
        }
    }
}
