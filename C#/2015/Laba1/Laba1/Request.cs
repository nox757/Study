using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba1
{
    /// <summary>
    /// Заявка
    /// </summary>
    sealed class Request
    {
        public readonly ulong ID;
        private string text;
        public string Text { get { return text; } private set { } }
        public Request(ulong _ID, string _Text)
        {
            ID = _ID;
            text = _Text;
        }
        public override string ToString()
        {
            return text + "(" + ID.ToString() + ")";
        }
    }
}
