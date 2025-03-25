using H3IoTApi.Data;
using H3IoTApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H3IoTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TemperatureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // C, R, U, D : Create, Read, Update, Delete

        // R - Læs alle temperaturer
        [HttpGet]
        public IActionResult GetTemperatureReadings()
        {
            // Henter alle temperaturer og tilføjer dem til en liste
            var temps = _context.temperatureReading.ToList();

            // Returnerer en status 200 og listen med temperaturer
            return Ok(temps);
        }

        // R - Læs en specifik temperatur
        [HttpGet("{id}")]
        public IActionResult GetTemperatureReading(int id)
        {
            // Forsøger at finde en temperaturmåling med et specifikt id
            var temp = _context.temperatureReading.Find(id);

            // Tjekker om søgningen gav svar
            if (temp == null)
            {
                // Returnerer ikke fundet
                return NotFound();
            }

            // Returnerer en status 200 og den fundne temperatur
            return Ok(temp);
        }

        // C - Opret en temperatur
        [HttpPost]
        public IActionResult CreateTemperatureReading(TemperatureReading tempReading)
        {
            // Tilføjer temperaturmåling til DbSettet
            _context.temperatureReading.Add(tempReading);

            // Gemmer i databasen via EFC
            _context.SaveChanges();

            // Returnerer en status 201
            return CreatedAtAction(nameof(GetTemperatureReading), new { id = tempReading.Id }, tempReading);
        }

        // U - Opdater en temperatur
        [HttpPut("{id}")]
        public IActionResult UpdateTemperatureReading(int id, TemperatureReading tempReading)
        {
            // Tjekker om id'et matcher
            if (id != tempReading.Id)
            {
                return BadRequest();
            }

            // Opdaterer temperaturmålingen
            _context.Entry(tempReading).State = EntityState.Modified;

            try
            {
                // Gemmer ændringerne i databasen
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Tjekker om temperaturmålingen stadig findes
                if (!_context.temperatureReading.Any(e => e.Id == id))
                {
                    // Returnerer ikke fundet
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Returnerer en status 204 (No Content)
            return NoContent();
        }

        // D - Slet en temperatur
        [HttpDelete("{id}")]
        public IActionResult DeleteTemperatureReading(int id)
        {
            // Finder temperaturmålingen med det specifikke id
            var temp = _context.temperatureReading.Find(id);

            // Tjekker om søgningen gav svar
            if (temp == null)
            {
                // Returnerer ikke fundet
                return NotFound();
            }

            // Fjerner temperaturmålingen fra DbSettet
            _context.temperatureReading.Remove(temp);

            // Gemmer ændringerne i databasen
            _context.SaveChanges();

            // Returnerer en status 204 (No Content)
            return NoContent();
        }
    }
}