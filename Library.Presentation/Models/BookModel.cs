using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }
}