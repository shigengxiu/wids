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
    public class DeviceTypesController : ControllerBase
    {
        private readonly CoreContext _context;

        public DeviceTypesController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/DeviceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceType>>> GetDeviceType()
        {
            return await _context.DeviceType.ToListAsync();
        }

        // GET: api/DeviceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceType>> GetDeviceType(long id)
        {
            var deviceType = await _context.DeviceType.FindAsync(id);

            if (deviceType == null)
            {
                return NotFound();
            }

            return deviceType;
        }

        // PUT: api/DeviceTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceType(long id, DeviceType deviceType)
        {
            if (id != deviceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(deviceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceTypeExists(id))
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

        // POST: api/DeviceTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DeviceType>> PostDeviceType(DeviceType deviceType)
        {
            _context.DeviceType.Add(deviceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeviceType", new { id = deviceType.Id }, deviceType);
        }

        // DELETE: api/DeviceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeviceType>> DeleteDeviceType(long id)
        {
            var deviceType = await _context.DeviceType.FindAsync(id);
            if (deviceType == null)
            {
                return NotFound();
            }

            _context.DeviceType.Remove(deviceType);
            await _context.SaveChangesAsync();

            return deviceType;
        }

        private bool DeviceTypeExists(long id)
        {
            return _context.DeviceType.Any(e => e.Id == id);
        }
    }
}
