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
    public class AuthUsersController : ControllerBase
    {
        private readonly CoreContext _context;

        public AuthUsersController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/AuthUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthUser>>> GetAuthUser()
        {
            return await _context.AuthUser.ToListAsync();
        }

        // GET: api/AuthUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthUser>> GetAuthUser(long id)
        {
            var authUser = await _context.AuthUser.FindAsync(id);

            if (authUser == null)
            {
                return NotFound();
            }

            return authUser;
        }

        // PUT: api/AuthUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthUser(long id, AuthUser authUser)
        {
            if (id != authUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(authUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthUserExists(id))
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

        // POST: api/AuthUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AuthUser>> PostAuthUser(AuthUser authUser)
        {
            _context.AuthUser.Add(authUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthUser", new { id = authUser.Id }, authUser);
        }

        // DELETE: api/AuthUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthUser>> DeleteAuthUser(long id)
        {
            var authUser = await _context.AuthUser.FindAsync(id);
            if (authUser == null)
            {
                return NotFound();
            }

            _context.AuthUser.Remove(authUser);
            await _context.SaveChangesAsync();

            return authUser;
        }

        private bool AuthUserExists(long id)
        {
            return _context.AuthUser.Any(e => e.Id == id);
        }


    }
}
