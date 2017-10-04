using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_books
{
    class lb_Abonement
    {
        public int id;
        public string debt;
        public int id_human;
        public bool dolg;
        public double size_dolg;
        public List<Tuple<int, string[]>> books  ;
        

        public lb_Abonement()
        {
            id = 0;
            books = new List<Tuple<int, string[]>>();
            debt = "";
            id_human = 0;
            dolg = false;
            size_dolg = 0;
            
        }
        /// <summary>
        /// сдача книги
        /// </summary>
        public virtual bool Give_book(int id_book)
        {
            if(books == null)
              return false;  
            int i = books.FindIndex(p => p.Item1 == id_book);
            DateTime temp = DateTime.Now;
            books[i].Item2[2] = temp.ToString();
            DateTime tmp = DateTime.Parse(books[i].Item2[1]);
            if (temp > tmp)
            {
                dolg = true;
                size_dolg += 2 * (temp - tmp).TotalDays;//начисление штрафа
            }

            return true;
        }
        public virtual void Get_book(int id_book, DateTime d_back)
        {
            books.Add(new Tuple<int, string[]>(id_book, new string[3]));

            int i = books.Count-1;
            books[i].Item2[0] = DateTime.Now.ToString();
            books[i].Item2[1] = d_back.ToString();
           
        }

    }
}
