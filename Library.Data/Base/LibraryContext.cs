using Library.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Data.Base
{

    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryContext()
            : base("LibraryDBContext", throwIfV1Schema: false)
        {
        }

        public static LibraryContext Create()
        {
            return new LibraryContext();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBook { get; set; }
    }
}
