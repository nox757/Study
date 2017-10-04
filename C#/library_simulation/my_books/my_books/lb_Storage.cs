using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_books
{
    class lb_Storage
    {
        public List<int> Spisok_book;
        public int id_storage;
        public string name_st;

        public lb_Storage()
        {
            Spisok_book = new List<int>();            
            id_storage = 0;
            name_st = "";
        }
    }
}
