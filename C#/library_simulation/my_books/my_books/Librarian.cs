using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Diagnostics;





namespace my_books
{

    class Librarian : Common
    {
        /// <summary>
        /// Из какой очереди получать заявки
        /// </summary>
        private Que curr_que;
        private Cartoteka curr_cart;
        private Depot curr_hra;
        public Request curr_req;

        public string type, type1;
        public string old_req_state = "";

        /// <summary>
        /// Отдать заявку
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public delegate bool _giveReq(Request req, Librarian sender);
        public event _giveReq giveReq;


        public Timer t_delay;
        public int rnd_f = 16;
        public int rnd_l = 30;

        Dictionary<int, lb_Book> Books;
        Dictionary<int, lb_Abonement> Abon;

        public Librarian(int _id, Que _que, Cartoteka _cart, Dictionary<int, lb_Book> _Books, Dictionary<int, lb_Abonement> _Abon)
        {
            id = _id;
            state = "Empty";
            curr_que = _que;
            type = "Libr";
            type1 = "Libr_no";
            curr_cart = _cart;
            curr_hra = null;
            Books = _Books;
            Abon = _Abon;
        }
        public Librarian(int _id, Depot _hra, Dictionary<int, lb_Book> _Books, Dictionary<int, lb_Abonement> _Abon)
        {
            id = _id;
            state = "Empty";
            curr_hra = _hra;
            type = "Libr";
            type1 = "Libr_no";
            curr_cart = null;
            curr_que = null;
            Abon = _Abon;
            Books = _Books;
        }


        public void getReq_fromQue()
        {
            if (state == "Empty")
            {
                state = "Busy";
                //Поиск первой заявки
                int i = 0;
                for (i = 0; i < curr_que.curr_len && (type != curr_que.Catalog[i].type); i++) ;
                if (i < curr_que.curr_len)
                {
                    if (giveReq != null)
                    {
                        curr_req = curr_que.Catalog[i];// Событие отдачи заявки
                        //Так как заявка сразу из очереди значит только сдача книг
                        curr_que.Remove(curr_que.Catalog[i]);
                        Vozvrat();


                        state = "Busy";
                        delay();

                    }
                }
                else
                {
                    state = "Empty";
                }
            }
        }

        private void Vozvrat()
        { 
            curr_req.type = "Que_done";
            curr_req.state = "Give_books";
            int size_ = curr_req.res_book.Count();
            int g = -1;
            for (int i = 0; i < size_; i++)
            {
                g = curr_req.res_book[i];
                if (Books.ContainsKey(g))
                {
                    Books[g].status = true;
                    Abon[curr_req.id_abonement].Give_book(g);
                }
            }
        }

        public void getReq_fromCart()
        {
            if (state == "Empty")
            {
                state = "Busy";
                //Поиск первой заявки
                int i = 0;
                for (i = 0; i < curr_cart.curr_len && (type != curr_cart.Catalog[i].type ); i++) ;
                if (i < curr_cart.curr_len)
                {
                    if (giveReq != null)
                    {
                        curr_req = curr_cart.Catalog[i];// Событие отдачи заявки
                        curr_cart.Remove(curr_req);
                        if (Abon[curr_req.id_abonement].dolg == false)
                        {
                            curr_req.type = "Depot";
                            curr_req.state = "toDepot";
                        }
                        else
                        {
                            curr_req.type = "Que_no";
                            curr_req.state = "Dolg";
                        }
                        state = "Busy";
                        delay();

                    }
                }
                else
                {
                    state = "Empty";
                }
            }
        }
        public void getReq_fromDepot()
        {
            
            if (state == "Empty")
            {
                state = "Busy";
                //Поиск первой заявки
                int i = 0;
                type1 = "Libr_no";
                int l = curr_hra.curr_len;
                for (i = 0; i < l && type != curr_hra.Catalog[i].type && type1 != curr_hra.Catalog[i].type; i++) ;
                if (i < l)
                {
                    if (giveReq != null)
                    {
                        curr_req = curr_hra.Catalog[i];//Событие отдачи заявки
                        curr_hra.Remove(curr_hra.Catalog[i]);
                        if (type1 == curr_req.type)
                        {                           
                            curr_req.type = "Que_no";
                            curr_req.state = "No_get_book"; 
                            old_req_state = curr_req.state;
                        }
                        else
                        {
                            Poluchenie();                            
                            curr_req.type = "Que_done";
                            curr_req.state = "Get_book";
                            old_req_state = curr_req.state;
                        }
                        state = "Busy";
                        delay();

                    }
                }
                else
                {
                    state = "Empty";
                }
            }
            
        }

        private void Poluchenie()
        {
           
            int size_ = curr_req.res_book.Count();
            int g = -1;
            for (int i = 0; i < size_; i++)
            {
                g = curr_req.res_book[i];
                if (Books.ContainsKey(g))
                {
                    Books[g].status = false;
                    Abon[curr_req.id_abonement].Get_book(g, DateTime.Now.AddDays(7));///Время сдачи через 6 дней
                }
            }
        }
        /// <summary>
        /// Задержка заявки на обработку
        /// </summary>
        private void delay()
        {
            Random rnd = new Random();
            t_delay = new Timer();
            t_delay.Interval = rnd.Next(rnd_f, rnd_l);
            t_delay.Elapsed += t_delay_Elapsed;

            old_req_state = curr_req.state;
            curr_req.state = "BusyLabr";            

            t_delay.Start();

        }
        private void t_delay_Elapsed(object sender, ElapsedEventArgs e)
        {
             
            curr_req.t_work += t_delay.Interval;
            if (giveReq != null)
            {
                giveReq(curr_req, this);

            }
            
            
        }
    }
}
