using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigNum
{
    /// <summary>
    /// Большое безнаковое число с основанием 10, храним в обратном порядке c основанием 10^9
    /// </summary>
    class BigNumber
    {

        private static int Osn = 1000000000, lenOsn = 9;
        private List<int> mas = new List<int>();//массив с дл.числом

        public BigNumber(List<int> mas)
        {
            this.mas = mas;
        }
        public List<int> ToNumList()
        {
            return mas;
        }
        public BigNumber(string s)
        {
            if (s == "")
            {
                mas.Add(0);
                return;
            }
            string temp = "";
            int count = s.Length / lenOsn;//количество эл. в массиве
            if (s.Length % lenOsn != 0)
                count++;
            int startPos = s.Length - lenOsn, endPos = s.Length;//текущии поз. для разбивки числа
            for (int i = 0; i < count; i++)
            {
                if (startPos < 0)
                    startPos = 0;
                temp = s.Substring(startPos, endPos - startPos);
                mas.Add(Convert.ToInt32(temp));
                endPos = startPos;
                startPos = endPos - lenOsn;
                temp = "";
            }

        }

        /// <summary>
        /// Перевод числа в строковый вид
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            string ans = "";
            ans += mas[mas.Count - 1].ToString();
            for (int i = mas.Count - 2; i >= 0; i--)
            {
                string temp;
                temp = mas[i].ToString();
                while (temp.Length < lenOsn)
                {
                    temp = "0" + temp;
                }
                ans += temp;
            }
            return ans;
        }
        /// <summary>
        /// Сравнение текущего числа с нужным
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        public int Compare(BigNumber B)
        {
            if (this.mas.Count < B.mas.Count)
                return -1;
            if (this.mas.Count > B.mas.Count)
                return 1;
            for (int i = this.mas.Count - 1; i >= 0; i--)
            {
                if (this.mas[i] < B.mas[i])
                    return -1;
                else
                    if (this.mas[i] > B.mas[i])
                        return 1;
            }
            return 0;
        }
        public static BigNumber operator +(BigNumber A, BigNumber B)
        {

            int temp_count = Math.Max(A.mas.Count, B.mas.Count);//количество операции сложения
            List<int> res = new List<int>();//список хранящий результат суммы
            List<int> tempA = A.ToNumList();//список с первым слагаемым
            List<int> tempB = B.ToNumList();//список со вторым слагаемым
            int ostatok = 0;//остаток возникающий при сложении
            for (int i = 0; i < temp_count; i++)
            {
                res.Add(A.mas.ElementAtOrDefault(i) + B.mas.ElementAtOrDefault(i) + ostatok);
                ostatok = res[i] / Osn;
                res[i] = res[i] % Osn;
            }
            if (ostatok > 0)
            {
                res.Add(ostatok);
            }
            BigNumber Res = new BigNumber(res);
            return Res;
        }
        /// <summary>
        /// Правильно A-B if A >= B >= 0
        /// </summary>
        /// <param name="A">большее</param>
        /// <param name="B">меньшее</param>
        /// <returns></returns>
        public static BigNumber operator -(BigNumber A, BigNumber B)
        {
            int temp_count = Math.Max(A.mas.Count, B.mas.Count);
            List<int> res = new List<int>();
            List<int> tempA = A.ToNumList();
            List<int> tempB = B.ToNumList();
            int ostatok = 0;
            for (int i = 0; i < temp_count; i++)
            {
                res.Add(A.mas.ElementAtOrDefault(i) - B.mas.ElementAtOrDefault(i) - ostatok);
                if (res[i] < 0)
                {
                    res[i] = res[i] + Osn;
                    ostatok = 1;
                }
                else
                    ostatok = 0;
            }
            while (res[temp_count - 1] == 0 && temp_count > 1)
            {
                res.RemoveAt(temp_count-1);
                temp_count--;
            }
            BigNumber Res;
            if (res.Count == 0)
            {
                Res = new BigNumber("");//если нулевой результат
            }
            else
                Res = new BigNumber(res);
            return Res;
        }

    }
}
