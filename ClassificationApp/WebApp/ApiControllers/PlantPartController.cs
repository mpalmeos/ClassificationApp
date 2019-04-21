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
    public class PlantPartController : ControllerBase
    {
        private readonly IAppBll _bll;

        public PlantPartController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/PlantPart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantPart>>> GetPlantParts()
        {
            return await _bll.PlantParts.AllAsync();
        }

        // GET: api/PlantPart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantPart>> GetPlantPart(int id)
        {
            var plantPart = await _bll.PlantParts.FindAsync(id);

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

            _bll.PlantParts.Update(plantPart);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/PlantPart
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PlantPart>> PostPlantPart(PlantPart plantPart)
        {
            await _bll.PlantParts.AddAsync(plantPart);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPlantPart", new { id = plantPart.Id }, plantPart);
        }

        // DELETE: api/PlantPart/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PlantPart>> DeletePlantPart(int id)
        {
            var plantPart = await _bll.PlantParts.FindAsync(id);
            if (plantPart == null)
            {
                return NotFound();
            }

            _bll.PlantParts.Remove(plantPart);
            await _bll.SaveChangesAsync();

            return plantPart;
        }
    }
}
