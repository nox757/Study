using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace my_books
{
    class Que : Common
    {
        public List<Request> Catalog;

        public int max_len = 0;
        public int curr_len = 0;
        public int num = 0;

        public Timer t_que;
        public delegate void _notEmpty();
        public event _notEmpty notEmpty;

        private string type;

        public Que()
        {

        }

        public Que(int _id)
        {
            id = _id;
            state = "Empty";
            curr_len = 0;
            Catalog = new List<Request>();
            type = "Que";

            t_que = new Timer(20);
            t_que.Elapsed += t_que_Elapsed;
        }

    
        public Que(int _id, int _max_len)
        {
            id = _id;
            max_len = _max_len;
            curr_len = 0;
            Catalog = new List<Request>(max_len);
            state = "Empty";
            type = "Que";

            t_que = new Timer(20);//Интервал проверки пустоты очереди
            t_que.Elapsed += t_que_Elapsed;
            t_que.Start();
        }
        private void t_que_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (notEmpty != null && !IsNull())
            {
                for (int i = 0; i < curr_len; i++)
                    Catalog[i].t_que += t_que.Interval;
                notEmpty();
            }
        }

        protected bool IsNull()
        {
            return curr_len == 0;
        }
        protected bool IsFull()
        {
            return curr_len == max_len;
        }
        /// <summary>
        /// Добавить в конец очереди
        /// </summary>
        /// <param name="Req"></param>
        /// <returns></returns>
        public virtual bool Add(Request Req)
        {
            if (!IsFull() || max_len == 0)
            {
                    Catalog.Add(Req);
                    curr_len++;
                    num++;
                    state = "Process";
                    return true;
              
            }
            else
            {
                state = "Full";
                return false;
            }
        }

        public virtual bool Remove(Request Req)
        {
            if (IsNull())
                return false;
            else
            {
                Catalog.Remove(Req);
                curr_len--;
                state = "Process";
                if (curr_len == 0)
                    state = "Empty";
                return true;
            }
        }

        public virtual void Clear()
        {
            Catalog.Clear();
            if (max_len == 0)
            {
                Catalog = new List<Request>();
            }
            else
            {
                Catalog = new List<Request>(max_len);
            }
            state = "Empty";
            curr_len = 0;
            
        }
    }
}
