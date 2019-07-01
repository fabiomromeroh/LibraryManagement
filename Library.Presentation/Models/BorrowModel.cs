using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models
{
    public class BorrowedBookModel
    {
        public int BorrowedBookID { get; set; }
        public int UserCode { get; set; }
        public int BookID { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int Days { get; set; }

        public virtual BookModel Book { get; set; }
    }
}