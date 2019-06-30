namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookBookingUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        UserCode = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.BookID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        Publisher = c.String(),
                        Author = c.String(),
                        Description = c.String(),
                        Booked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            AddColumn("dbo.AspNetUsers", "UserCode", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bookings", "BookID", "dbo.Books");
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "BookID" });
            DropColumn("dbo.AspNetUsers", "UserCode");
            DropTable("dbo.Books");
            DropTable("dbo.Bookings");
        }
    }
}
