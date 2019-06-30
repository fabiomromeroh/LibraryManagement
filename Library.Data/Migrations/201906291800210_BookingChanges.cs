namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserCode", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserCode", c => c.Int(nullable: false));
        }
    }
}
