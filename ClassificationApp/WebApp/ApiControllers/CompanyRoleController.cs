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
        private readonly IAppBll _bll;

        public CompanyRoleController(IAppBll bll)
        {
            _bll = bll;
        }


        // GET: api/CompanyRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyRoleDTO>>> GetCompanyRoles()
        {
            return await _bll.CompanyRoles.GetAllWithConnections();
        }

        // GET: api/CompanyRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyRole>> GetCompanyRole(int id)
        {
            var companyRole = await _bll.CompanyRoles.FindAsync(id);

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

            _bll.CompanyRoles.Update(companyRole);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/CompanyRole
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompanyRole>> PostCompanyRole(CompanyRole companyRole)
        {
            await _bll.CompanyRoles.AddAsync(companyRole);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetCompanyRole", new { id = companyRole.Id }, companyRole);
        }

        // DELETE: api/CompanyRole/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CompanyRole>> DeleteCompanyRole(int id)
        {
            var companyRole = await _bll.CompanyRoles.FindAsync(id);
            if (companyRole == null)
            {
                return NotFound();
            }

            _bll.CompanyRoles.Remove(companyRole);
            await _bll.SaveChangesAsync();

            return companyRole;
        }
    }
}
