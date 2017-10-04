using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba1
{
    sealed class StackLst : Stack
    {
        List<Request> Pool;
        public StackLst(ulong _ID, string Descr, int _MaxNum)
        {
            ID = _ID;
            MaxSize = _MaxNum;
            Title = Descr;
            NumReq = 0;
            LastReq = -1;
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
                Pool.RemoveAt(LastReq);
                NumReq--;
                if (IsEmpty)
                {                    
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
                return ("StackLst empty");
            else
            {
                s = "StackLst";
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
