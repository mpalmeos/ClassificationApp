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
    public class CompositionHerbController : ControllerBase
    {
        private readonly IAppBll _bll;

        public CompositionHerbController(IAppBll bll)
        {
            _bll = bll;
        }


        // GET: api/CompositionHerb
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositionHerb>>> GetCompositionHerbs()
        {
            return await _bll.CompositionHerbs.AllAsync();
        }

        // GET: api/CompositionHerb/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompositionHerb>> GetCompositionHerb(int id)
        {
            var compositionHerb = await _bll.CompositionHerbs.FindAsync(id);

            if (compositionHerb == null)
            {
                return NotFound();
            }

            return compositionHerb;
        }

        // PUT: api/CompositionHerb/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCompositionHerb(int id, CompositionHerb compositionHerb)
        {
            if (id != compositionHerb.Id)
            {
                return BadRequest();
            }

            _bll.CompositionHerbs.Update(compositionHerb);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/CompositionHerb
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompositionHerb>> PostCompositionHerb(CompositionHerb compositionHerb)
        {
            await _bll.CompositionHerbs.AddAsync(compositionHerb);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetCompositionHerb", new { id = compositionHerb.Id }, compositionHerb);
        }

        // DELETE: api/CompositionHerb/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompositionHerb>> DeleteCompositionHerb(int id)
        {
            var compositionHerb = await _bll.CompositionHerbs.FindAsync(id);
            if (compositionHerb == null)
            {
                return NotFound();
            }

            _bll.CompositionHerbs.Remove(compositionHerb);
            await _bll.SaveChangesAsync();

            return compositionHerb;
        }
    }
}
