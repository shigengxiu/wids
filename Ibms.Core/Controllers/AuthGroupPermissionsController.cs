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
    public class AuthGroupPermissionsController : ControllerBase
    {
        private readonly CoreContext _context;

        public AuthGroupPermissionsController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/AuthGroupPermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthGroupPermission>>> GetAuthGroupPermission()
        {
            return await _context.AuthGroupPermission.ToListAsync();
        }

        // GET: api/AuthGroupPermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthGroupPermission>> GetAuthGroupPermission(long id)
        {
            var authGroupPermission = await _context.AuthGroupPermission.FindAsync(id);

            if (authGroupPermission == null)
            {
                return NotFound();
            }

            return authGroupPermission;
        }

        // PUT: api/AuthGroupPermissions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthGroupPermission(long id, AuthGroupPermission authGroupPermission)
        {
            if (id != authGroupPermission.Id)
            {
                return BadRequest();
            }

            _context.Entry(authGroupPermission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthGroupPermissionExists(id))
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

        // POST: api/AuthGroupPermissions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AuthGroupPermission>> PostAuthGroupPermission(AuthGroupPermission authGroupPermission)
        {
            _context.AuthGroupPermission.Add(authGroupPermission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthGroupPermission", new { id = authGroupPermission.Id }, authGroupPermission);
        }

        // DELETE: api/AuthGroupPermissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthGroupPermission>> DeleteAuthGroupPermission(long id)
        {
            var authGroupPermission = await _context.AuthGroupPermission.FindAsync(id);
            if (authGroupPermission == null)
            {
                return NotFound();
            }

            _context.AuthGroupPermission.Remove(authGroupPermission);
            await _context.SaveChangesAsync();

            return authGroupPermission;
        }

        private bool AuthGroupPermissionExists(long id)
        {
            return _context.AuthGroupPermission.Any(e => e.Id == id);
        }
    }
}
