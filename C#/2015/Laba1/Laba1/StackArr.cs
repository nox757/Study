using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba1
{
    sealed class StackArr : Stack
    {
        Request[] Pool;
        public StackArr(ulong _ID, string Descr, int _MaxNum)
        {
            
            ID = _ID;
            MaxSize = _MaxNum;
            Title = Descr;
            NumReq = 0;
            LastReq = -1;
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
                LastReq++;
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
                Pool[LastReq] = null;
                LastReq--;
                NumReq--;
                return true;
            }
        }

        public override string ToString()
        {
            string s = "";
            if (IsEmpty)
                return ("StackArr empty");
            else
            {
                s = "StackArr";
                s = "#" + NumReq.ToString() + " || ";
                for(int i = 0; i < NumReq; i++)
                {
                    s += Pool[i].ToString() + " ";
                }
                return s;
            }

        }
    
    }
}
