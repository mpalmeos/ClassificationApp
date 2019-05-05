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
    public class UnitOfMeasureController : ControllerBase
    {
        private readonly IAppBll _bll;

        public UnitOfMeasureController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/UnitOfMeasure
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasure>>> GetUnitOfMeasures()
        {
            return await _bll.UnitOfMeasures.AllAsync();
        }

        // GET: api/UnitOfMeasure/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfMeasure>> GetUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _bll.UnitOfMeasures.FindAsync(id);

            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            return unitOfMeasure;
        }

        // PUT: api/UnitOfMeasure/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutUnitOfMeasure(int id, UnitOfMeasure unitOfMeasure)
        {
            if (id != unitOfMeasure.Id)
            {
                return BadRequest();
            }

            _bll.UnitOfMeasures.Update(unitOfMeasure);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/UnitOfMeasure
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UnitOfMeasure>> PostUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            await _bll.UnitOfMeasures.AddAsync(unitOfMeasure);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUnitOfMeasure", new { id = unitOfMeasure.Id }, unitOfMeasure);
        }

        // DELETE: api/UnitOfMeasure/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UnitOfMeasure>> DeleteUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _bll.UnitOfMeasures.FindAsync(id);
            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            _bll.UnitOfMeasures.Remove(unitOfMeasure);
            await _bll.SaveChangesAsync();

            return unitOfMeasure;
        }
    }
}
