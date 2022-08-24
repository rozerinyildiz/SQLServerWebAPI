﻿using System;
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
    public class DevicesController : ControllerBase
    {
        private readonly MSSQLWebAPIContext _context;

        public DevicesController(MSSQLWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevice()
        {
          if (_context.Device == null)
          {
              return NotFound();
          }
            return await _context.Device.ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(long id)
        {
          if (_context.Device == null)
          {
              return NotFound();
          }
            var device = await _context.Device.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(long id, Device device)
        {
            if (id != device.id)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/Devices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
          if (_context.Device == null)
          {
              return Problem("Entity set 'MSSQLWebAPIContext.Device'  is null.");
          }
            _context.Device.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.id }, device);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(long id)
        {
            if (_context.Device == null)
            {
                return NotFound();
            }
            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Device.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(long id)
        {
            return (_context.Device?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
