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
    public class DosageController : ControllerBase
    {
        private readonly IAppBll _bll;

        public DosageController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/Dosage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dosage>>> GetDosages()
        {
            return await _bll.Dosages.AllAsync();
        }

        // GET: api/Dosage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dosage>> GetDosage(int id)
        {
            var dosage = await _bll.Dosages.FindAsync(id);

            if (dosage == null)
            {
                return NotFound();
            }

            return dosage;
        }

        // PUT: api/Dosage/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutDosage(int id, Dosage dosage)
        {
            if (id != dosage.Id)
            {
                return BadRequest();
            }

            _bll.Dosages.Update(dosage);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Dosage
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Dosage>> PostDosage(Dosage dosage)
        {
            await _bll.Dosages.AddAsync(dosage);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetDosage", new { id = dosage.Id }, dosage);
        }

        // DELETE: api/Dosage/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Dosage>> DeleteDosage(int id)
        {
            var dosage = await _bll.Dosages.FindAsync(id);
            if (dosage == null)
            {
                return NotFound();
            }

            _bll.Dosages.Remove(dosage);
            await _bll.SaveChangesAsync();

            return dosage;
        }
    }
}
