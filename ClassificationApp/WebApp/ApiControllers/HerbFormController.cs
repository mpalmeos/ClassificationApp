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
    public class HerbFormController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public HerbFormController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/HerbForm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerbForm>>> GetHerbForms()
        {
            var res = await _uow.HerbForms.AllAsync();
            return Ok(res);
        }

        // GET: api/HerbForm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HerbForm>> GetHerbForm(int id)
        {
            var herbForm = await _uow.HerbForms.FindAsync(id);

            if (herbForm == null)
            {
                return NotFound();
            }

            return herbForm;
        }

        // PUT: api/HerbForm/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutHerbForm(int id, HerbForm herbForm)
        {
            if (id != herbForm.Id)
            {
                return BadRequest();
            }

            _uow.HerbForms.Update(herbForm);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/HerbForm
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<HerbForm>> PostHerbForm(HerbForm herbForm)
        {
            await _uow.HerbForms.AddAsync(herbForm);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetHerbForm", new { id = herbForm.Id }, herbForm);
        }

        // DELETE: api/HerbForm/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<HerbForm>> DeleteHerbForm(int id)
        {
            var herbForm = await _uow.HerbForms.FindAsync(id);
            if (herbForm == null)
            {
                return NotFound();
            }

            _uow.HerbForms.Remove(herbForm);
            await _uow.SaveChangesAsync();

            return herbForm;
        }
    }
}
