using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Hamit
{
    public class Book
    {
        [PrimaryKey]
        public int ISBN_10 { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Boolean IsBorrowed { get; set; } = false;

        public string Borrower { get; set; } = "";

    }
}
