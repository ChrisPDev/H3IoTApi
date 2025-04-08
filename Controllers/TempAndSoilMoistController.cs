using H3IoTApi.Data;
using H3IoTApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H3IoTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempAndSoilMoistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TempAndSoilMoistController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTempAndSoilMoists()
        {
            var tempAndSoilMoist = _context.tempAndSoilMoist.ToList();

            return Ok(tempAndSoilMoist);
        }

        [HttpGet("{id}")]
        public IActionResult GetTempAndSoilMoist(int id)
        {
            var tempAndSoilMoist = _context.temperatureReading.Find(id);

            if (tempAndSoilMoist == null)
            {
                return NotFound();
            }

            return Ok(tempAndSoilMoist);
        }

        [HttpPost]
        public IActionResult CreateTempAndSoilMoist(TempAndSoilMoist tempAndSoilMoist)
        {
            _context.tempAndSoilMoist.Add(tempAndSoilMoist);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTempAndSoilMoist), new { id = tempAndSoilMoist.Id }, tempAndSoilMoist);
        }
    }
}
