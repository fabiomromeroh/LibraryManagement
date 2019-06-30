namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingRename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Bookings", newName: "BorrowedBooks");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BorrowedBooks", newName: "Bookings");
        }
    }
}
