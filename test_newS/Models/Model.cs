using Domain.Transport;
using Domain.Flight; 
using Microsoft.EntityFrameworkCore;


namespace test_newS.Models
{
    public class Model:DbContext
    {
        public Model() 
        {
        }

        public Model(DbContextOptions options):base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=postefcore;Uid=root;Pwd=root;");
            }
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Transport> Transports { get; set; }
    }
}
