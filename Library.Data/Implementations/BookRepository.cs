using Data;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class BookRepository: BaseRepository<Book>, IBookRepository
    {
    }
}
