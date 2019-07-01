namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BorrowedBooks", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BorrowedBooks", "Active");
        }
    }
}
