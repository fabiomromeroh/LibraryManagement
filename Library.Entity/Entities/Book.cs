using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Entity
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }
}
