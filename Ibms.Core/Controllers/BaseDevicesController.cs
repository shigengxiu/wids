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
    [Route("api/base_devices")]
    [ApiController]
    public class BaseDevicesController : ControllerBase
    {
        private readonly CoreContext _context;

        public BaseDevicesController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/BaseDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseDevice>>> GetBaseDevices()
        {
            return await _context.BaseDevices.ToListAsync();
        }

        // GET: api/BaseDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDevice>> GetBaseDevice(long id)
        {
            var baseDevice = await _context.BaseDevices.FindAsync(id);

            if (baseDevice == null)
            {
                return NotFound();
            }

            return baseDevice;
        }

        // PUT: api/BaseDevices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseDevice(long id, BaseDevice baseDevice)
        {
            if (id != baseDevice.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseDeviceExists(id))
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

        // POST: api/BaseDevices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BaseDevice>> PostBaseDevice(BaseDevice baseDevice)
        {
            _context.BaseDevices.Add(baseDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBaseDevices), new { id = baseDevice.Id }, baseDevice);
        }

        // DELETE: api/BaseDevices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseDevice>> DeleteBaseDevice(long id)
        {
            var baseDevice = await _context.BaseDevices.FindAsync(id);
            if (baseDevice == null)
            {
                return NotFound();
            }

            _context.BaseDevices.Remove(baseDevice);
            await _context.SaveChangesAsync();

            return baseDevice;
        }

        private bool BaseDeviceExists(long id)
        {
            return _context.BaseDevices.Any(e => e.Id == id);
        }
    }
}
