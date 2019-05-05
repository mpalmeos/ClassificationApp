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
    public class CompositionController : ControllerBase
    {
        private readonly IAppBll _bll;

        public CompositionController(IAppBll bll)
        {
            _bll = bll;
        }


        // GET: api/Composition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Composition>>> GetCompositions()
        {
            return await _bll.Compositions.AllAsync();
        }

        // GET: api/Composition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Composition>> GetComposition(int id)
        {
            var composition = await _bll.Compositions.FindAsync(id);

            if (composition == null)
            {
                return NotFound();
            }

            return composition;
        }

        // PUT: api/Composition/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutComposition(int id, Composition composition)
        {
            if (id != composition.Id)
            {
                return BadRequest();
            }

            _bll.Compositions.Update(composition);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Composition
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Composition>> PostComposition(Composition composition)
        {
            await _bll.Compositions.AddAsync(composition);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetComposition", new { id = composition.Id }, composition);
        }

        // DELETE: api/Composition/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Composition>> DeleteComposition(int id)
        {
            var composition = await _bll.Compositions.FindAsync(id);
            if (composition == null)
            {
                return NotFound();
            }

            _bll.Compositions.Remove(composition);
            await _bll.SaveChangesAsync();

            return composition;
        }
    }
}
