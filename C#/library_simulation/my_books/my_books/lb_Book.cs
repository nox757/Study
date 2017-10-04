using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_books
{
    class lb_Book
    {
        public int id_shifr;
        public int year;
        public int kol_page;
        public string name_book;
        public string authors;        
        public bool status;//взята ли?
        
        public lb_Book()
        {
            id_shifr = 0;
            name_book = "";
            authors = "";
            year = 0;
            kol_page = 0;
            status = true;//в библиотеке значит
        }
        public virtual string ToStr()
        {
            string s = "";
            s += id_shifr.ToString() + ";" + year.ToString() + ";" + kol_page.ToString() 
                + ";" + name_book + ";" + authors + ";" + ((status) ? "1" : "0");
            return s;
        }
    }
}
