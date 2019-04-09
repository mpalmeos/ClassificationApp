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
    public class PlantPartController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public PlantPartController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/PlantPart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantPart>>> GetPlantParts()
        {
            var res = await _uow.PlantParts.AllAsync();
            return Ok(res);
        }

        // GET: api/PlantPart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantPart>> GetPlantPart(int id)
        {
            var plantPart = await _uow.PlantParts.FindAsync(id);

            if (plantPart == null)
            {
                return NotFound();
            }

            return plantPart;
        }

        // PUT: api/PlantPart/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutPlantPart(int id, PlantPart plantPart)
        {
            if (id != plantPart.Id)
            {
                return BadRequest();
            }

            _uow.PlantParts.Update(plantPart);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/PlantPart
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PlantPart>> PostPlantPart(PlantPart plantPart)
        {
            await _uow.PlantParts.AddAsync(plantPart);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPlantPart", new { id = plantPart.Id }, plantPart);
        }

        // DELETE: api/PlantPart/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PlantPart>> DeletePlantPart(int id)
        {
            var plantPart = await _uow.PlantParts.FindAsync(id);
            if (plantPart == null)
            {
                return NotFound();
            }

            _uow.PlantParts.Remove(plantPart);
            await _uow.SaveChangesAsync();

            return plantPart;
        }
    }
}
