using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_books
{
    class lb_Cart
    {
        public int id_shifr;
        public string name_book_cart;
        public string authors;
       

        public lb_Cart()
        {
            id_shifr = 0;
            name_book_cart = "";
            authors = "";
            
        }

        public virtual string ToStr()
        {
            string s = "";
            s += id_shifr.ToString() + ";"  + name_book_cart + ";" + authors;
            return s;
        }
    }
}
