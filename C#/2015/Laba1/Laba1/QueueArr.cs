using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba1
{
    sealed class QueueArr : Queue
    {
        Request[] Pool;
        public QueueArr(ulong _ID, string Descr, int _MaxNum)
        {
            
            this.ID = _ID;
            this.MaxSize = _MaxNum;
            this.Title = Descr;
            this.NumReq = 0;
            this.FirstReq = -1;
            this.LastReq = -1;
            Pool = new Request[MaxSize];

        }
        public override bool AddReq(Request req)
        {
            if (IsFull)
            {
                return false;
            }
            else
            {
                if(IsEmpty)
                    FirstReq = 0;
                if (LastReq < MaxSize - 1)
                {
                    LastReq++;
                }
                else
                {
                    LastReq = 0; //зацикливание
                }
                Pool[LastReq] = req;
                NumReq++;
                return true;
            }
        }

        public override bool RemoveReq()
        {
            if (IsEmpty)
                return false;
            else
            {
                Pool[FirstReq] = null;
                FirstReq = (FirstReq + 1) % MaxSize;
                NumReq--;
                if (IsEmpty)
                {
                    FirstReq = -1;
                    LastReq = -1;
                }
                return true;
            }
        }

        public override string ToString()
        {
            string s = "";
            if (IsEmpty)
                return ("QueueArr empty");
            else
            {
                s = "QueueArr";
                s += "#" + NumReq.ToString() + " || ";
                for (int i = 0; i < NumReq; i++)
                {
                    s += Pool[(FirstReq + i) % MaxSize].ToString() + " ";
                }
                return s;
            }

        }

         //s += ((Pool[i] != null) ? Pool[i].ToString(): "_") + " ";
    }
}
