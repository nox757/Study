using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba1
{
    sealed class QueueLst : Queue
    {
        List<Request> Pool;
        public QueueLst(ulong _ID, string Descr, int _MaxNum)
        {
            this.ID = _ID;
            this.MaxSize = _MaxNum;
            this.Title = Descr;
            this.NumReq = 0;
            this.FirstReq = -1;
            this.LastReq = -1;
            Pool = new List<Request>();

        }
        public override bool AddReq(Request req)
        {
            if (IsFull)
            {
                return false;
            }
            else
            {
                FirstReq = 0;
                LastReq++;
                NumReq++;
                Pool.Add(req);
                return true;
            }
        }

        public override bool RemoveReq()
        {
            if (IsEmpty)
            {
                return false;
            }
            else
            {
                Pool.RemoveAt(FirstReq);
                NumReq--;
                if (IsEmpty)
                {
                    FirstReq = -1;
                    LastReq = -1;
                }
                else
                    LastReq--;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";
            if (IsEmpty)
                return ("QueueLst empty");
            else
            {
                s = "QueueLst";
                s += "#" + NumReq.ToString() + " || ";
                foreach (Request req in Pool)
                {
                    s += req.ToString() + " ";
                }
                return s;
            }

        }
    }
}
