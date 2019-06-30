using Data;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public interface IBorrowRepository: IBaseRepository<BorrowedBook>
    {
        List<BorrowedBook> GetBorrowedBooksByUser(string userId);
    }
}
