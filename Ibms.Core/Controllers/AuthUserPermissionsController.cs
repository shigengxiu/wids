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
    public class AuthUserPermissionsController : ControllerBase
    {
        private readonly CoreContext _context;

        public AuthUserPermissionsController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/AuthUserPermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthUserPermission>>> GetAuthUserPermission()
        {
            return await _context.AuthUserPermission.ToListAsync();
        }

        // GET: api/AuthUserPermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthUserPermission>> GetAuthUserPermission(long id)
        {
            var authUserPermission = await _context.AuthUserPermission.FindAsync(id);

            if (authUserPermission == null)
            {
                return NotFound();
            }

            return authUserPermission;
        }

        // PUT: api/AuthUserPermissions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthUserPermission(long id, AuthUserPermission authUserPermission)
        {
            if (id != authUserPermission.Id)
            {
                return BadRequest();
            }

            _context.Entry(authUserPermission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthUserPermissionExists(id))
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

        // POST: api/AuthUserPermissions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AuthUserPermission>> PostAuthUserPermission(AuthUserPermission authUserPermission)
        {
            _context.AuthUserPermission.Add(authUserPermission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthUserPermission", new { id = authUserPermission.Id }, authUserPermission);
        }

        // DELETE: api/AuthUserPermissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthUserPermission>> DeleteAuthUserPermission(long id)
        {
            var authUserPermission = await _context.AuthUserPermission.FindAsync(id);
            if (authUserPermission == null)
            {
                return NotFound();
            }

            _context.AuthUserPermission.Remove(authUserPermission);
            await _context.SaveChangesAsync();

            return authUserPermission;
        }

        private bool AuthUserPermissionExists(long id)
        {
            return _context.AuthUserPermission.Any(e => e.Id == id);
        }
    }
}
