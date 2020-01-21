using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ibms.Core.Models;

namespace Ibms.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiModelsController : ControllerBase
    {
        private readonly CoreContext _context;

        public ApiModelsController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/ApiModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiModel>>> GetApiModel()
        {
            return await _context.ApiModel.ToListAsync();
        }

        // GET: api/ApiModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiModel>> GetApiModel(long id)
        {
            var apiModel = await _context.ApiModel.FindAsync(id);

            if (apiModel == null)
            {
                return NotFound();
            }

            return apiModel;
        }

        // PUT: api/ApiModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApiModel(long id, ApiModel apiModel)
        {
            if (id != apiModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(apiModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApiModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ApiModel>> PostApiModel(ApiModel apiModel)
        {
            _context.ApiModel.Add(apiModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApiModel", new { id = apiModel.Id }, apiModel);
        }

        // DELETE: api/ApiModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiModel>> DeleteApiModel(long id)
        {
            var apiModel = await _context.ApiModel.FindAsync(id);
            if (apiModel == null)
            {
                return NotFound();
            }

            _context.ApiModel.Remove(apiModel);
            await _context.SaveChangesAsync();

            return apiModel;
        }

        private bool ApiModelExists(long id)
        {
            return _context.ApiModel.Any(e => e.Id == id);
        }
    }
}
