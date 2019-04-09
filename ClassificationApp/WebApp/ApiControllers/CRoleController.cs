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
    public class CRoleController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public CRoleController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/CRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CRole>>> GetCRoles()
        {
            var res = await _uow.CRoles.AllAsync();
            return Ok(res);
        }

        // GET: api/CRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CRole>> GetCRole(int id)
        {
            var cRole = await _uow.CRoles.FindAsync(id);

            if (cRole == null)
            {
                return NotFound();
            }

            return cRole;
        }

        // PUT: api/CRole/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCRole(int id, CRole cRole)
        {
            if (id != cRole.Id)
            {
                return BadRequest();
            }

            _uow.CRoles.Update(cRole);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/CRole
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CRole>> PostCRole(CRole cRole)
        {
            await _uow.CRoles.AddAsync(cRole);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetCRole", new { id = cRole.Id }, cRole);
        }

        // DELETE: api/CRole/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CRole>> DeleteCRole(int id)
        {
            var cRole = await _uow.CRoles.FindAsync(id);
            if (cRole == null)
            {
                return NotFound();
            }

            _uow.CRoles.Remove(cRole);
            await _uow.SaveChangesAsync();

            return cRole;
        }
    }
}
