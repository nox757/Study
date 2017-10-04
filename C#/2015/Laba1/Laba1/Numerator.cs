using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba1
{
    /// <summary>
    /// Нумерация запросов
    /// </summary>
    sealed class Numerator
    {
        private ulong curnum;        
        public ulong CurNum { get { return curnum; } } 
        public Numerator() { curnum = 0; } 
        public ulong GetNewNum() { return curnum++; } 
     
    }
}
