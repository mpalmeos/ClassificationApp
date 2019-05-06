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
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IAppBll _bll;

        public CompanyController(IAppBll bll)
        {
            _bll = bll;
        }


        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Company>>> GetCompanies()
        {
            return (await _bll.Companies.AllAsync())
                .Select(e => PublicApi.v1.Mappers.CompanyMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Company>> GetCompany(int id)
        {
            var company = 
                PublicApi.v1.Mappers.CompanyMapper.MapFromBLL(await _bll.Companies.FindAsync(id));

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _bll.Companies.Update(company);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Company
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            await _bll.Companies.AddAsync(company);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Company>> DeleteCompany(int id)
        {
            var company = await _bll.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _bll.Companies.Remove(company);
            await _bll.SaveChangesAsync();

            return company;
        }
    }
}
