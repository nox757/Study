using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_books
{
    class Request : Common
    {
        
        /// <summary>
        /// время в очереди мс
        /// </summary>
        public double t_que = 0;
        /// <summary>
        /// время обработки заявки
        /// </summary>
        public double t_work = 0;

        /// <summary>
        /// куда должна отправиться, тип следующего подразделения
        /// </summary>
        public string type;

        /// <summary>
        /// кем создано/кому нужно
        /// </summary>
        public int id_abonement;

        public int sum_books = 0;//сколько книг нужно
        public List<List<string>> authors = new List<List<string>>();//какого автора/-ов нужна книга
        public List<string> name_books = new List<string>();// название нужной книги

        /// <summary>
        /// список книг, которые удволетворяют условию
        /// </summary>
        public int[] res_book = null;

        public Request(int _id, string _specification)
        {
            id = _id;
            state = "Created";
            specification = _specification;
            type = "";
        }

        public Request(int _id, string _specification, int _sum, List<List<string>> _auth, List<string> _nameb)
        {
            id = _id;
            state = "Created";
            specification = _specification;
            type = "";
            sum_books = _sum;
            authors = _auth;
            name_books = _nameb;
        }


        public virtual bool Generation_info_get(Dictionary<int, lb_Abonement> Abon, Dictionary<int, lb_Book> Books)
        {
            Random rnd = new Random();
            if (Abon != null && Books != null && Abon.Count > 0 && Books.Count > 0)
            {
                int g = -1;
                int r_min = Abon.Keys.Min();
                int r_max = Abon.Keys.Max();
                while(!Abon.ContainsKey(g))
                {
                    g = rnd.Next(r_min, r_max);
                }
                this.id_abonement = g;

                sum_books = rnd.Next(1, 3);
                res_book = new int[sum_books];
                r_min = Books.Keys.Min();
                r_max = Books.Keys.Max();
                int[] j = new int[3];
                for (int i = 0; i < 3; i++)
                    j[i] = -2;
                for (int i = 0; i < sum_books; i++)
                {
                    g = -1;
                    while (!Books.ContainsKey(g) && (g ==-1 || j.Any(p => p == g)))
                    {
                        g = rnd.Next(r_min, r_max);
                    }
                    string ss = string.Copy(Books[g].name_book);
                    this.name_books.Add(ss);
                    j[i] = g;
                }
                type = "Cart";

                return true;
            }

            return false;
        }
    }
}
