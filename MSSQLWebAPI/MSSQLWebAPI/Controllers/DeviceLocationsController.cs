using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSSQLWebAPI.Data;
using MSSQLWebAPI.Models;

namespace MSSQLWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceLocationsController : ControllerBase
    {
        private readonly MSSQLWebAPIContext _context;

        public DeviceLocationsController(MSSQLWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/DeviceLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceLocation>>> GetDeviceLocation()
        {
          if (_context.DeviceLocation == null)
          {
              return NotFound();
          }
            return await _context.DeviceLocation.ToListAsync();
        }

        // GET: api/DeviceLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceLocation>> GetDeviceLocation(long id)
        {
          if (_context.DeviceLocation == null)
          {
              return NotFound();
          }
            var deviceLocation = await _context.DeviceLocation.FindAsync(id);

            if (deviceLocation == null)
            {
                return NotFound();
            }

            return deviceLocation;
        }

        // PUT: api/DeviceLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceLocation(long id, DeviceLocation deviceLocation)
        {
            if (id != deviceLocation.id)
            {
                return BadRequest();
            }

            _context.Entry(deviceLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceLocationExists(id))
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

        // POST: api/DeviceLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeviceLocation>> PostDeviceLocation(DeviceLocation deviceLocation)
        {
          if (_context.DeviceLocation == null)
          {
              return Problem("Entity set 'MSSQLWebAPIContext.DeviceLocation'  is null.");
          }
            _context.DeviceLocation.Add(deviceLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeviceLocation", new { id = deviceLocation.id }, deviceLocation);
        }

        // DELETE: api/DeviceLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceLocation(long id)
        {
            if (_context.DeviceLocation == null)
            {
                return NotFound();
            }
            var deviceLocation = await _context.DeviceLocation.FindAsync(id);
            if (deviceLocation == null)
            {
                return NotFound();
            }

            _context.DeviceLocation.Remove(deviceLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceLocationExists(long id)
        {
            return (_context.DeviceLocation?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
