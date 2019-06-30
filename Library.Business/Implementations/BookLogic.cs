using Business;
using Library.Data;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class BookLogic: BaseLogic<Book, BookRepository>, IBookLogic
    {
        private readonly IBookRepository bookRepository;

        public BookLogic(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
    }
}
