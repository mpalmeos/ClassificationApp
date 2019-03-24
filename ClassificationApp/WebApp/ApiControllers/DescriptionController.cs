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

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public DescriptionController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Description
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Description>>> GetDescriptions()
        {
            var res = await _uow.Descriptions.AllAsync();
            return Ok(res);
        }

        // GET: api/Description/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Description>> GetDescription(int id)
        {
            var description = await _uow.Descriptions.FindAsync(id);

            if (description == null)
            {
                return NotFound();
            }

            return description;
        }

        // PUT: api/Description/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescription(int id, Description description)
        {
            if (id != description.Id)
            {
                return BadRequest();
            }

            _uow.Descriptions.Update(description);
            await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Description
        [HttpPost]
        public async Task<ActionResult<Description>> PostDescription(Description description)
        {
            await _uow.Descriptions.AddAsync(description);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetDescription", new { id = description.Id }, description);
        }

        // DELETE: api/Description/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Description>> DeleteDescription(int id)
        {
            var description = await _uow.Descriptions.FindAsync(id);
            if (description == null)
            {
                return NotFound();
            }

            _uow.Descriptions.Remove(description);
            await _uow.SaveChangesAsync();

            return description;
        }
    }
}
