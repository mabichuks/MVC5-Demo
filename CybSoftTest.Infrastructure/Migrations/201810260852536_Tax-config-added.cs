namespace CybSoftTest.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Taxconfigadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaxConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monthly = c.Double(nullable: false),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaxConfigs");
        }
    }
}
