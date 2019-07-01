using Data;
using Data.Base;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Library.Data
{
    public class BorrowedBookRepository : BaseRepository<BorrowedBook>, IBorrowedBookRepository
    {
        /// <summary>
        /// Return all borrowed books by user.
        /// </summary>
        /// <param name="userId">Logged User</param>
        /// <returns></returns>
        public List<BorrowedBook> GetBorrowedBooksByUser(string userId)
        {
            using (var Context = new LibraryContext())
            {
                return Context.BorrowedBook.Include(x => x.Book).Where(x => x.UserId == userId).ToList();
            }
        }
    }
}
