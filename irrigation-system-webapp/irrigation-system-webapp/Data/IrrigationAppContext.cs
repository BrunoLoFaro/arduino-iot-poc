using irrigation_system_webapp.Models;
using Microsoft.EntityFrameworkCore;

namespace irrigation_system_webapp.Data
{
    public class IrrigationAppContext : DbContext
    {
        public IrrigationAppContext(DbContextOptions<IrrigationAppContext> options) : base(options)
        {
        }

        public DbSet<Temperature> Temperatures{ get; set; }
    }
}