
using H3IoTApi.Models;
using Microsoft.EntityFrameworkCore;

namespace H3IoTApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TemperatureReading> temperatureReading { get; set; }
        public DbSet<TempAndSoilMoist> tempAndSoilMoist { get; set; }
    }
}
