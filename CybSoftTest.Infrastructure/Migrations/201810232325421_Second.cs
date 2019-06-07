namespace CybSoftTest.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "StaffNumber", c => c.String());
            DropColumn("dbo.Staffs", "StaffId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "StaffId", c => c.String());
            DropColumn("dbo.Staffs", "StaffNumber");
        }
    }
}
