using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Graphes
{
    class Matric
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

        public static bool MatrixFromDataTable(DataTable dt, int n, out int[,] M, out string msg)
        {
            //DataTable - из библиотеки System.Data
            bool res = true;
            msg = "";           // Всё штатно, ошибки нет
            M = null;           // Инициализация M, т.к. оно должно быть задано перед окончанием
            // функции, а try теоретически может не заполнить значение
            res = dt != null;   // DataTable существует
            if (!res)
                msg = "Передана пустая ссылка на таблицу с данными.";
            else
                try
                {
                    #region Conversion
                    M = new int[n, n];
                    int val, // сюда попадёт результат конверсии
                        nn = dt.Rows.Count,      // кол-во строк в таблице
                        mm = dt.Columns.Count;   // кол-во столбцов в таблице
                    if ((n <= nn) & (n <= mm))
                    {
                        for (int i = 0; i < n & res; i++)
                            for (int j = 0; j < n & res; j++)
                            // res - 2е условие, чтобы не проверять оставшиеся ячейки, если ошибка уже найдена
                            {
                                /*  dt.Columns[j]   // формат данных
                                    dt.Rows[][]     // сами данные */
                                res &= CheckInt(dt.Rows[i][j].ToString(), out val);
                                // res = res & ....         // аналог +=
                                // Для каждого столбца DataTable при инициализации задаётся его тип.
                                // Если тип числовой, то при попытке юзера ввести букву и перейти в новую
                                // ячейку вылетает ошибка, которую сложно отловить. Поэтому проще хранить
                                // в ячейках строки, и проверку выполнять в этой функции (вместо поиска
                                // места отлова ошибки, чтобы там проверять корректность вводимых данных),
                                // поскольку пользователю разрешён ввод и он может ошибиться.
                                if (res)
                                    M[i, j] = val;
                                else
                                    msg = "Ошибка проверки значения в ячейке [" + (i + 1).ToString() +
                                        "," + (j + 1).ToString() + "].";  // юзеру понятнее нумерация с 1
                            }
                    }
                    else
                    {
                        res = false;
                        msg = "Переданы неверные размеры, таблица с данными меньше заявленных габаритов.";
                        M = null;
                    }
                    #endregion Conversion
                }
                catch (Exception ex /*ex - переменная для данных ошибки*/)   // ошибка
                {
                    res = false;
                    msg = ex.Message;
                    M = null;
                }
            return res;
        }

      

    }
}
