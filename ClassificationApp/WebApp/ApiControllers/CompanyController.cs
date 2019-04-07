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
    public class CompanyController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public CompanyController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var res = await _uow.Companies.AllAsync();
            return Ok(res);
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _uow.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _uow.Companies.Update(company);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Company
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            await _uow.Companies.AddAsync(company);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(int id)
        {
            var company = await _uow.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _uow.Companies.Remove(company);
            await _uow.SaveChangesAsync();

            return company;
        }
    }
}
