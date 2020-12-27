using System.Data.Entity;
using TestMVC.Models.Flight;
using TestMVC.Models.Transport;

namespace TestMVC.Context
{
    public class TestContext : DbContext
    {
        public TestContext() : base("TestContext")
        {

        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Transport> Transports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flight>()
                .HasIndex(t => t.FkTransport)
                .IsUnique();
            modelBuilder.Entity<Transport>();
        }
    }
}