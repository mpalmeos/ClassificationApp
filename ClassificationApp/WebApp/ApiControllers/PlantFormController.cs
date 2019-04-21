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
    public class PlantFormController : ControllerBase
    {
        private readonly IAppBll _bll;

        public PlantFormController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/PlantForm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantForm>>> GetPlantForms()
        {
            return await _bll.PlantForms.AllAsync();
        }

        // GET: api/PlantForm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantForm>> GetPlantForm(int id)
        {
            var plantForm = await _bll.PlantForms.FindAsync(id);

            if (plantForm == null)
            {
                return NotFound();
            }

            return plantForm;
        }

        // PUT: api/PlantForm/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutPlantForm(int id, PlantForm plantForm)
        {
            if (id != plantForm.Id)
            {
                return BadRequest();
            }

            _bll.PlantForms.Update(plantForm);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/PlantForm
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PlantForm>> PostPlantForm(PlantForm plantForm)
        {
            await _bll.PlantForms.AddAsync(plantForm);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPlantForm", new { id = plantForm.Id }, plantForm);
        }

        // DELETE: api/PlantForm/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PlantForm>> DeletePlantForm(int id)
        {
            var plantForm = await _bll.PlantForms.FindAsync(id);
            if (plantForm == null)
            {
                return NotFound();
            }

            _bll.PlantForms.Remove(plantForm);
            await _bll.SaveChangesAsync();

            return plantForm;
        }
    }
}
