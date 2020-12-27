namespace TestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightCode = c.String(nullable: false, maxLength: 128),
                        DepartureStation = c.String(nullable: false),
                        ArrivalStation = c.String(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        FkTransport = c.String(nullable: false, maxLength: 128),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FlightCode)
                .ForeignKey("dbo.Transports", t => t.FkTransport, cascadeDelete: true)
                .Index(t => t.FkTransport, unique: true);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        FlightNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FlightNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "FkTransport", "dbo.Transports");
            DropIndex("dbo.Flights", new[] { "FkTransport" });
            DropTable("dbo.Transports");
            DropTable("dbo.Flights");
        }
    }
}
