using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace my_books
{
    class Cartoteka : Que
    {

        private Que curr_que;
        private Request curr_req;
        private double[] intervals;

        /// <summary>
        /// Рандомный интервал нахождения в картотеке
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

        public string type;


        public  new delegate void _notEmpty();
        public  new event _notEmpty  notEmpty;

        public delegate bool _giveReq(Request req);
        public event _giveReq giveReq;

        //Подключаемая картотека
        List<lb_Cart> Kartoteka;

        public Cartoteka(int _id, Que _que, int _max_len, List<lb_Cart> _Kartoteka)
        {
            id = _id;
            state = "Empty";
            curr_que = _que;
            type = "Cart";
            max_len = _max_len;
            Catalog = new List<Request>(max_len);
            intervals = new double[max_len];
            curr_len = 0;

            Kartoteka = _Kartoteka;

            t_que = new Timer(20);///Интервал проверки на пустоту
            t_que.Elapsed += t_cart_Elapsed;
            t_que.Start();
        }
        private void t_cart_Elapsed(object sender, ElapsedEventArgs e)
        {
            t_que.Stop();
            if (notEmpty != null && !IsNull())
            {
                for (int i = 0; i < curr_len; i++)
                {
                    intervals[i] -= t_que.Interval;
                    Catalog[i].t_work += t_que.Interval;
                    if (intervals[i] < 0 && Catalog[i].type == "Cart")
                    {
                        Find_cr(i);                        
                    }
                }
                notEmpty();               
            }
            t_que.Start();
        }

        private void Find_cr(int i)
        {          
            bool fl_no = false;            
            for(int j = 0; j < Catalog[i].sum_books; j++)//Ищем по запросам пользователя в заяке
            {
               lb_Cart cur_c = new lb_Cart();
                if(Catalog[i].name_books[j] != null && Catalog[i].name_books[j] != "")
                {
                    cur_c = Kartoteka.Find(p => p.name_book_cart == Catalog[i].name_books[j]);
                    if (cur_c.id_shifr != 0)
                    {
                        Catalog[i].res_book[j] = cur_c.id_shifr;
                        fl_no = true;
                    }
                    continue;
                }
                          
            }
            if(fl_no)
            {
                Catalog[i].type = "Libr";
            }
            else
            {
                Catalog[i].type = "Que_no";
                Catalog[i].state = "No_in";
                curr_req = Catalog[i];
                Remove(Catalog[i]);
                if (giveReq != null)
                {
                        giveReq(curr_req);

                }
            }
        }

        public override bool Add(Request Req)
        {
            if (!IsFull())
            {
                Catalog.Add(Req);
                curr_len++;
                state = "Process";
                return true;
            }
            else
            {
                state = "Full";
                return false;
            }            
        }
        public override bool Remove(Request Req)
        {
            if (IsNull())
                return false;
            else
            {
                if (Catalog.Remove(Req))
                {
                    curr_len--;
                    state = "Process";
                    if (curr_len == 0)
                        state = "Empty";
                    
                    return true;
                }
                else
                    return false;
            }
        }
        public override void Clear()
        {
            Catalog.Clear();
            Catalog = new List<Request>(max_len);
            state = "Empty";
            curr_len = 0;

        }
        /// <summary>
        /// Получение заявки не из пустой очереди
        /// </summary>
        public void getRequest()
        {
            //Поиск первой заявки
            if (state != "Full")
            {
                rnd = new Random();
                int i = 0;
                for (i = 0; i < curr_que.curr_len && curr_len < max_len; i++)
                {
                    if (type == curr_que.Catalog[i].type)
                    {
                        curr_req = curr_que.Catalog[i];                        
                        curr_que.Remove(curr_req);
                        curr_req.state = "BusyCart";
                        Add(curr_req);
                        num++;
                        intervals[curr_len - 1] = rnd.Next(rnd_f, rnd_l);
                        
                    }
                }
            }
        }

        
    }
}
