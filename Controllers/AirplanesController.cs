using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteGolCleiton.Models;

namespace TesteGolCleiton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        private readonly AirplaneDbContext _context;

        public AirplanesController(AirplaneDbContext context)
        {
            _context = context;
        }

        // GET: api/Airplanes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airplanes>>> GetAirplane()
        {
            return await _context.Airplane.ToListAsync();
        }

        // GET: api/Airplanes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airplanes>> GetAirplanes(string id)
        {
            var airplanes = await _context.Airplane.FindAsync(id);

            if (airplanes == null)
            {
                return NotFound();
            }

            return airplanes;
        }

        // PUT: api/Airplanes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplanes(string id, Airplanes airplanes)
        {
            if (id != airplanes.Modelo)
            {
                return BadRequest();
            }

            _context.Entry(airplanes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplanesExists(id))
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

        // POST: api/Airplanes
        [HttpPost]
        public async Task<ActionResult<Airplanes>> PostAirplanes(Airplanes airplanes)
        {
            _context.Airplane.Add(airplanes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirplanes", new { id = airplanes.Modelo }, airplanes);
        }

        // DELETE: api/Airplanes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Airplanes>> DeleteAirplanes(string id)
        {
            var airplanes = await _context.Airplane.FindAsync(id);
            if (airplanes == null)
            {
                return NotFound();
            }

            _context.Airplane.Remove(airplanes);
            await _context.SaveChangesAsync();

            return airplanes;
        }

        private bool AirplanesExists(string id)
        {
            return _context.Airplane.Any(e => e.Modelo == id);
        }
    }
}
