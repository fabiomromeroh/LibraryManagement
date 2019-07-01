using Business;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public interface IBorrowedBookLogic: IBaseLogic<BorrowedBook>
    {
        List<BorrowedBook> GetBorrowedBooksByUser(string userId);
        void BorrowBook(int bookId, string userId, int quantity, int days);
        void ReturnBook(int id);
    }
}
