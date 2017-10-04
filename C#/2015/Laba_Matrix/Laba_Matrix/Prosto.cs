using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_Matrix
{
    public static class Prosto
    {
        /// <summary>
        /// Перевод строки в int
        /// </summary>
        /// <param name="s"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool CheckInt(string s, out int num)
        {
            bool res = true;
            num = 0;
            try
            {
                num = Convert.ToInt32(s);
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
    }
}
