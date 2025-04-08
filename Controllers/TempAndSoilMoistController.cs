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
    }
}
