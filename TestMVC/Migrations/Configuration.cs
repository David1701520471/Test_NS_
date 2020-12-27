namespace TestMVC.Migrations
{

    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TestMVC.Context.TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TestMVC.Context.TestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
