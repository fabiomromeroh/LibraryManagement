namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.BorrowedBooks", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.BorrowedBooks", "Days", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Booked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Booked", c => c.Boolean(nullable: false));
            DropColumn("dbo.BorrowedBooks", "Days");
            DropColumn("dbo.BorrowedBooks", "Quantity");
            DropColumn("dbo.Books", "Stock");
        }
    }
}
