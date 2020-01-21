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
    public class AuthUserGroupsController : ControllerBase
    {
        private readonly CoreContext _context;

        public AuthUserGroupsController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/AuthUserGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthUserGroup>>> GetAuthUserGroup()
        {
            return await _context.AuthUserGroup.ToListAsync();
        }

        // GET: api/AuthUserGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthUserGroup>> GetAuthUserGroup(long id)
        {
            var authUserGroup = await _context.AuthUserGroup.FindAsync(id);

            if (authUserGroup == null)
            {
                return NotFound();
            }

            return authUserGroup;
        }

        // PUT: api/AuthUserGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthUserGroup(long id, AuthUserGroup authUserGroup)
        {
            if (id != authUserGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(authUserGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthUserGroupExists(id))
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

        // POST: api/AuthUserGroups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AuthUserGroup>> PostAuthUserGroup(AuthUserGroup authUserGroup)
        {
            _context.AuthUserGroup.Add(authUserGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthUserGroup", new { id = authUserGroup.Id }, authUserGroup);
        }

        // DELETE: api/AuthUserGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthUserGroup>> DeleteAuthUserGroup(long id)
        {
            var authUserGroup = await _context.AuthUserGroup.FindAsync(id);
            if (authUserGroup == null)
            {
                return NotFound();
            }

            _context.AuthUserGroup.Remove(authUserGroup);
            await _context.SaveChangesAsync();

            return authUserGroup;
        }

        private bool AuthUserGroupExists(long id)
        {
            return _context.AuthUserGroup.Any(e => e.Id == id);
        }
    }
}
