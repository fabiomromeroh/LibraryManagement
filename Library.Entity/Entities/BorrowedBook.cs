﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class BorrowedBook
    {
        [Key]
        public int BorrowedBookID { get; set; }
        public int UserCode { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual Book Book { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
