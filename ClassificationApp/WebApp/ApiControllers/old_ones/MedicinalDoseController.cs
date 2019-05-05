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
    public class MedicinalDoseController : ControllerBase
    {
        private readonly IAppBll _bll;

        public MedicinalDoseController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/MedicinalDose
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicinalDose>>> GetMedicinalDoses()
        {
            return await _bll.MedicinalDoses.AllAsync();
        }

        // GET: api/MedicinalDose/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicinalDose>> GetMedicinalDose(int id)
        {
            var medicinalDose = await _bll.MedicinalDoses.FindAsync(id);

            if (medicinalDose == null)
            {
                return NotFound();
            }

            return medicinalDose;
        }

        // PUT: api/MedicinalDose/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutMedicinalDose(int id, MedicinalDose medicinalDose)
        {
            if (id != medicinalDose.Id)
            {
                return BadRequest();
            }

            _bll.MedicinalDoses.Update(medicinalDose);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/MedicinalDose
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<MedicinalDose>> PostMedicinalDose(MedicinalDose medicinalDose)
        {
            await _bll.MedicinalDoses.AddAsync(medicinalDose);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetMedicinalDose", new { id = medicinalDose.Id }, medicinalDose);
        }

        // DELETE: api/MedicinalDose/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<MedicinalDose>> DeleteMedicinalDose(int id)
        {
            var medicinalDose = await _bll.MedicinalDoses.FindAsync(id);
            if (medicinalDose == null)
            {
                return NotFound();
            }

            _bll.MedicinalDoses.Remove(medicinalDose);
            await _bll.SaveChangesAsync();

            return medicinalDose;
        }
    }
}
