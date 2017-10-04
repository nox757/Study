using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba1
{
    abstract class CommonPool
    {
        public ulong ID { get; protected set; }
        public string Title { get; protected set; }
        

        public int NumReq { get; protected set; }
        public int MaxSize { get; protected set; }

        public virtual bool AddReq(Request req) { return false ;}
        public virtual bool RemoveReq(){ return false;}
        
        public bool IsFull { get { return NumReq == MaxSize; } }
        public bool IsEmpty { get { return NumReq == 0; } }
    }
}
