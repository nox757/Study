using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_books
{
    abstract class Common
    {
        /// <summary>
        /// индитификатор
        /// </summary>
        public int id;
        /// <summary>
        /// состояние текущее
        /// </summary>
        public string state;
        public string specification;
        public Common()
        {
            id = 0;
            state = "Empty";
            specification = "";
        }

    }
}
