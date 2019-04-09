using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.DTO;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyRoleController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public CompanyRoleController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/CompanyRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyRoleDTO>>> GetCompanyRoles()
        {
            var res = await _uow.CompanyRoles.GetAllWithConnections();
            return Ok(res);
        }

        // GET: api/CompanyRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyRole>> GetCompanyRole(int id)
        {
            var companyRole = await _uow.CompanyRoles.FindAsync(id);

            if (companyRole == null)
            {
                return NotFound();
            }

            return companyRole;
        }

        // PUT: api/CompanyRole/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCompanyRole(int id, CompanyRole companyRole)
        {
            if (id != companyRole.Id)
            {
                return BadRequest();
            }

            _uow.CompanyRoles.Update(companyRole);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/CompanyRole
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompanyRole>> PostCompanyRole(CompanyRole companyRole)
        {
            await _uow.CompanyRoles.AddAsync(companyRole);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetCompanyRole", new { id = companyRole.Id }, companyRole);
        }

        // DELETE: api/CompanyRole/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompanyRole>> DeleteCompanyRole(int id)
        {
            var companyRole = await _uow.CompanyRoles.FindAsync(id);
            if (companyRole == null)
            {
                return NotFound();
            }

            _uow.CompanyRoles.Remove(companyRole);
            await _uow.SaveChangesAsync();

            return companyRole;
        }
    }
}
