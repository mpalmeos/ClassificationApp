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
    public class PlantFormController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public PlantFormController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/PlantForm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantForm>>> GetPlantForms()
        {
            var res = await _uow.PlantForms.AllAsync();
            return Ok(res);
        }

        // GET: api/PlantForm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantForm>> GetPlantForm(int id)
        {
            var plantForm = await _uow.PlantForms.FindAsync(id);

            if (plantForm == null)
            {
                return NotFound();
            }

            return plantForm;
        }

        // PUT: api/PlantForm/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantForm(int id, PlantForm plantForm)
        {
            if (id != plantForm.Id)
            {
                return BadRequest();
            }

            _uow.PlantForms.Update(plantForm);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/PlantForm
        [HttpPost]
        public async Task<ActionResult<PlantForm>> PostPlantForm(PlantForm plantForm)
        {
            await _uow.PlantForms.AddAsync(plantForm);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPlantForm", new { id = plantForm.Id }, plantForm);
        }

        // DELETE: api/PlantForm/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantForm>> DeletePlantForm(int id)
        {
            var plantForm = await _uow.PlantForms.FindAsync(id);
            if (plantForm == null)
            {
                return NotFound();
            }

            _uow.PlantForms.Remove(plantForm);
            await _uow.SaveChangesAsync();

            return plantForm;
        }
    }
}
