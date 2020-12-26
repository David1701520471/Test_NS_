using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}