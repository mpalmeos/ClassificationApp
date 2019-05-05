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
    public class SubstanceCategoryController : ControllerBase
    {
        private readonly IAppBll _bll;

        public SubstanceCategoryController(IAppBll bll)
        {
            _bll = bll;
        }

        // GET: api/SubstanceCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubstanceCategoryDTO>>> GetSubstanceCategories()
        {
            return await _bll.SubstanceCategories.GetAllWithConnections();
        }

        // GET: api/SubstanceCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubstanceCategory>> GetSubstanceCategory(int id)
        {
            var substanceCategory = await _bll.SubstanceCategories.FindAsync(id);

            if (substanceCategory == null)
            {
                return NotFound();
            }

            return substanceCategory;
        }

        // PUT: api/SubstanceCategory/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutSubstanceCategory(int id, SubstanceCategory substanceCategory)
        {
            if (id != substanceCategory.Id)
            {
                return BadRequest();
            }

            _bll.SubstanceCategories.Update(substanceCategory);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/SubstanceCategory
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<SubstanceCategory>> PostSubstanceCategory(SubstanceCategory substanceCategory)
        {
            await _bll.SubstanceCategories.AddAsync(substanceCategory);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSubstanceCategory", new { id = substanceCategory.Id }, substanceCategory);
        }

        // DELETE: api/SubstanceCategory/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<SubstanceCategory>> DeleteSubstanceCategory(int id)
        {
            var substanceCategory = await _bll.SubstanceCategories.FindAsync(id);
            if (substanceCategory == null)
            {
                return NotFound();
            }

            _bll.SubstanceCategories.Remove(substanceCategory);
            await _bll.SaveChangesAsync();

            return substanceCategory;
        }
    }
}
