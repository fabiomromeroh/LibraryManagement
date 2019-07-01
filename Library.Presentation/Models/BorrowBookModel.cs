using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models
{
    public class BorrowBookModel
    {
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public int Days { get; set; }
    }
}