using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using irrigation_system_webapp.Data;
using irrigation_system_webapp.Models;

namespace irrigation_system_webapp.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturesController : ControllerBase
    {
        private readonly IrrigationAppContext _context;

        public TemperaturesController(IrrigationAppContext context)
        {
            _context = context;
        }

        // GET: api/Temperatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temperature>>> GetTemperatures()
        {
            List<Temperature> temps = new List<Temperature>();
            try
            {
                temps = await _context.Temperatures.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + ex.Message + ex.StackTrace);
            }
            return temps;
        }

        // GET: api/Temperatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Temperature>> GetTemperature(int id)
        {
            var temperature = await _context.Temperatures.FindAsync(id);

            if (temperature == null)
            {
                return NotFound();
            }

            return temperature;
        }
        // GET: api/LastTemperature
        [HttpGet("Last")]
        public async Task<ActionResult<Temperature>> GetLastTemperature()
        {
            var temp = new Temperature();
            try
            {
                temp = await _context.Temperatures.OrderByDescending(t=>t.TemperatureId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + ex.Message + ex.StackTrace);
            }
            return temp;
        }

        // PUT: api/Temperatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemperature(int id, Temperature temperature)
        {
            if (id != temperature.TemperatureId)
            {
                return BadRequest();
            }

            _context.Entry(temperature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperatureExists(id))
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

        // POST: api/Temperatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Temperature>> PostTemperature(Temperature temperature)
        {
            _context.Temperatures.Add(temperature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemperature", new { id = temperature.TemperatureId }, temperature);
        }

        // DELETE: api/Temperatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemperature(int id)
        {
            var temperature = await _context.Temperatures.FindAsync(id);
            if (temperature == null)
            {
                return NotFound();
            }

            _context.Temperatures.Remove(temperature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemperatureExists(int id)
        {
            return _context.Temperatures.Any(e => e.TemperatureId == id);
        }
    }
}
