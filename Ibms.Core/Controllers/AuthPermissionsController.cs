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
    public class AuthPermissionsController : ControllerBase
    {
        private readonly CoreContext _context;

        public AuthPermissionsController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/AuthPermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthPermission>>> GetAuthPermission()
        {
            return await _context.AuthPermission.ToListAsync();
        }

        // GET: api/AuthPermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthPermission>> GetAuthPermission(long id)
        {
            var authPermission = await _context.AuthPermission.FindAsync(id);

            if (authPermission == null)
            {
                return NotFound();
            }

            return authPermission;
        }

        // PUT: api/AuthPermissions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthPermission(long id, AuthPermission authPermission)
        {
            if (id != authPermission.Id)
            {
                return BadRequest();
            }

            _context.Entry(authPermission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthPermissionExists(id))
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

        // POST: api/AuthPermissions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AuthPermission>> PostAuthPermission(AuthPermission authPermission)
        {
            _context.AuthPermission.Add(authPermission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthPermission", new { id = authPermission.Id }, authPermission);
        }

        // DELETE: api/AuthPermissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthPermission>> DeleteAuthPermission(long id)
        {
            var authPermission = await _context.AuthPermission.FindAsync(id);
            if (authPermission == null)
            {
                return NotFound();
            }

            _context.AuthPermission.Remove(authPermission);
            await _context.SaveChangesAsync();

            return authPermission;
        }

        private bool AuthPermissionExists(long id)
        {
            return _context.AuthPermission.Any(e => e.Id == id);
        }
    }
}
