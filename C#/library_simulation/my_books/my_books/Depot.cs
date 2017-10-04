using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace my_books
{
    /// <summary>
    /// Класс хранилища
    /// </summary>
    class Depot : Que
    {
        public new delegate void _notEmpty();
        public new event _notEmpty notEmpty;
        private List<double> intervals;

        /// <summary>
        /// Рандомный интервал нахождения в хранилище
        /// </summary>
        Random rnd;
        /// <summary>
        /// Начальное значение рандома обработки
        /// </summary>
        public int rnd_f = 0;
        /// <summary>
        /// Конечное значение рандома обработки
        /// </summary>
        public int rnd_l = 10;

        private string type;


        Dictionary<int, lb_Book> Books;//Ссылка на хранилище книг
        /// <summary>
        /// Хранилище бесконечное
        /// </summary>
        /// <param name="_id"></param>
        public Depot(int _id, Dictionary<int, lb_Book> _Books)
        {
            id = _id;
            state = "Empty";
            curr_len = 0;
            Catalog = new List<Request>();
            type = "Depot";
            intervals = new List<double>();

            Books = _Books;

            t_que = new Timer(20);
            t_que.Elapsed += t_que_Elapsed;
            t_que.Start();
        }
        /// <summary>
        /// Хранилище ограниченное
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_max_len"></param>
        public Depot(int _id, int _max_len, Dictionary<int, lb_Book> _Books)
        {
            id = _id;
            max_len = _max_len;
            curr_len = 0;
            Catalog = new List<Request>(max_len);
            state = "Empty";
            type = "Depot";
            intervals = new List<double>();

            Books = _Books;
            t_que = new Timer(20);
            t_que.Elapsed += t_que_Elapsed;
            t_que.Start();
        }
                

        private void t_que_Elapsed(object sender, ElapsedEventArgs e)
        {
            t_que.Stop();
            if (notEmpty != null && !IsNull())
            {
                int l = curr_len;     
                for (int i = 0; i < l; i++)
                {
                    intervals[i] -= t_que.Interval;
                    Catalog[i].t_work += t_que.Interval;//Прибавление времени нахождения в хранилище
                    if (intervals[i] < 0 && Catalog[i].type == "Depot")
                    {
                        Find_hra(i);
                    }
                        
                }
                notEmpty();
            }
            t_que.Start();
        }

        private void Find_hra(int i)
        {
            bool flag_no = false;
            int g = -1;
            for (int j = 0; j < Catalog[i].sum_books; j++)
            {
                g = Catalog[i].res_book[j];
                if (Books.ContainsKey(g))
                {
                    if (Books[g].status)
                    {
                        Books[g].status = false;
                        flag_no = true;
                    }
                    else
                    {
                        Catalog[i].res_book[j] = -2;
                    }
                }
                else
                {
                    Catalog[i].res_book[j] = -1;
                }
            }
            if (flag_no)
            {
                Catalog[i].type = "Libr";
            }
            else
            {
                Catalog[i].type = "Libr_no";
            }
        }

        public bool Add(Request Req, Librarian sender)
        {
            if (!IsFull() || max_len == 0)
            {
                if (type == Req.type)
                {
                    rnd = new Random();
                    Req.state = "BusyDepot";
                    Catalog.Add(Req);
                    curr_len++;
                    num++;
                    if (intervals.Count < curr_len)
                        intervals.Add(rnd.Next(rnd_f, rnd_l));
                    else
                        intervals[curr_len-1] = rnd.Next(rnd_f, rnd_l);
                    
                    state = "Process";
                    sender.state = "Empty";
                    sender.t_delay.Stop();
                    return true;
                }
                else
                    return false;
            }
            else
            {
                state = "Full";
                return false;
            }
        }
    }
}
