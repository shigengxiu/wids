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
    public class AuthGroupsController : ControllerBase
    {
        private readonly CoreContext _context;

        public AuthGroupsController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/AuthGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthGroup>>> GetAuthGroup()
        {
            return await _context.AuthGroup.ToListAsync();
        }

        // GET: api/AuthGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthGroup>> GetAuthGroup(long id)
        {
            var authGroup = await _context.AuthGroup.FindAsync(id);

            if (authGroup == null)
            {
                return NotFound();
            }

            return authGroup;
        }

        // PUT: api/AuthGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthGroup(long id, AuthGroup authGroup)
        {
            if (id != authGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(authGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthGroupExists(id))
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

        // POST: api/AuthGroups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AuthGroup>> PostAuthGroup(AuthGroup authGroup)
        {
            _context.AuthGroup.Add(authGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthGroup", new { id = authGroup.Id }, authGroup);
        }

        // DELETE: api/AuthGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthGroup>> DeleteAuthGroup(long id)
        {
            var authGroup = await _context.AuthGroup.FindAsync(id);
            if (authGroup == null)
            {
                return NotFound();
            }

            _context.AuthGroup.Remove(authGroup);
            await _context.SaveChangesAsync();

            return authGroup;
        }

        private bool AuthGroupExists(long id)
        {
            return _context.AuthGroup.Any(e => e.Id == id);
        }
    }
}
