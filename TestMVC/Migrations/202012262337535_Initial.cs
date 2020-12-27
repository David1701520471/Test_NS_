namespace TestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flight",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureStation = c.String(nullable: false),
                        ArrivalStation = c.String(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        FkTransport = c.String(nullable: false, maxLength: 128),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transport", t => t.FkTransport, cascadeDelete: true)
                .Index(t => t.FkTransport);
            
            CreateTable(
                "dbo.Transport",
                c => new
                    {
                        FlightNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FlightNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flight", "FkTransport", "dbo.Transport");
            DropIndex("dbo.Flight", new[] { "FkTransport" });
            DropTable("dbo.Transport");
            DropTable("dbo.Flight");
        }
    }
}
