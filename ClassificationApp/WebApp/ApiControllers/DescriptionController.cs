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
    public class DescriptionController : ControllerBase
    {
        private readonly IAppBll _bll;

        public DescriptionController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/Description
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Description>>> GetDescriptions()
        {
            return await _bll.Descriptions.AllAsync();
        }

        // GET: api/Description/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Description>> GetDescription(int id)
        {
            var description = await _bll.Descriptions.FindAsync(id);

            if (description == null)
            {
                return NotFound();
            }

            return description;
        }

        // PUT: api/Description/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutDescription(int id, Description description)
        {
            if (id != description.Id)
            {
                return BadRequest();
            }

            _bll.Descriptions.Update(description);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Description
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Description>> PostDescription(Description description)
        {
            await _bll.Descriptions.AddAsync(description);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetDescription", new { id = description.Id }, description);
        }

        // DELETE: api/Description/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Description>> DeleteDescription(int id)
        {
            var description = await _bll.Descriptions.FindAsync(id);
            if (description == null)
            {
                return NotFound();
            }

            _bll.Descriptions.Remove(description);
            await _bll.SaveChangesAsync();

            return description;
        }
    }
}
