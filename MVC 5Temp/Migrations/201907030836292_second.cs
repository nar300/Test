namespace MVC_5Temp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Phone", c => c.Int(nullable: false));
        }
    }
}
