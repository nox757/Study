using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Laba_Matrix
{
    /// <summary>
    /// Разряженная матрица схема Дженнингса.
    /// </summary>
    class Matrica
    {
        private int[] mas, pd;//массив с элементами, с поз. диагональных элементов
        public Matrica()
        {
            mas = null;
            pd = null;           
        }
        /// <summary>
        /// Возращает истино, если удалось записать данные
        /// </summary>
        /// <param name="dt">таблица данных</param>
        /// <param name="n">размерность матрицы</param>
        /// <returns></returns>
        public bool FromDataTable(DataTable dt, int n)
        {
            int j = 0, val = 0;
            List<int> temp_mas = new List<int>();
            List<int> temp_pd= new List<int>(); 
            for (int i = 0; i < n; i++)
            {
                j = 0;
                while (j<= i && Prosto.CheckInt(dt.Rows[i][j].ToString(), out val) && val == 0)
                    j++;
                if (j <= i  && !Prosto.CheckInt(dt.Rows[i][j].ToString(), out val))
                {
                    return false;
                }
                else
                {
                    if (j == i + 1)
                    {
                     
                        temp_mas.Add(0);
                        temp_pd.Add(temp_mas.Count - 1);
                    }
                    else
                    {
                      
                        for (int g = j; g <= i; g++)
                        {
                            if (!Prosto.CheckInt(dt.Rows[i][g].ToString(), out val))
                            {
                                return false;
                            }
                            else
                            {
                                temp_mas.Add(val);
                            }
                        }
                        temp_pd.Add(temp_mas.Count - 1);
                    }
                }
            }
            this.mas = new int[temp_mas.Count];
            this.pd = new int[temp_pd.Count];
            this.mas = temp_mas.ToArray();
            this.pd = temp_pd.ToArray();
            return true;
        }
        /// <summary>
        /// Запись в Datatable
        /// </summary>
        /// <param name="dt">ссылка на Datatable</param>
        /// <param name="n">размерность</param>
        /// <returns></returns>
        public bool ToDataTable(ref DataTable dt, int n)
        {
            
            if(mas == null || dt == null)
                return false;
            dt.Rows[0][0] = mas[0].ToString();
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {

                    if (pd[i] - (i - j) > pd[i - 1])
                    {
                        dt.Rows[i][j] = mas[pd[i] - (i - j)].ToString();
                        dt.Rows[j][i] = dt.Rows[i][j];
                    }
                    else
                    {
                        dt.Rows[i][j] = "0";
                        dt.Rows[j][i] = "0";
                    }
                }
            }
            for (int j = 1; j < n; j++)
            {
                dt.Rows[0][j] = dt.Rows[j][0];
            }


            return true;

        }

        
        public static Matrica operator +(Matrica A, Matrica B)
        {
            int n1, n2;
            n1 = A.pd.Length;
            n2 = B.pd.Length;
            if (n1 != n2 && A.mas != null && B.mas != null)//если разные размерности
            {
                return new Matrica();
            }
            else
            { 
                Matrica C = new Matrica();
                if (n1 == 1)//если 1*1
                {                   
                    C.pd = new int[1];
                    C.mas = new int[1];
                    C.pd[0] = 0;
                    C.mas[0] = A.mas[0] + B.mas[0];
                    return C;
                }
                else
                {
                    int j, count;
                    List<int> temp_mas = new List<int>();
                    List<int> temp_pd = new List<int>();
                    List<int> temp = new List<int>();//список для хранение сложенных строк
                    temp_mas.Add(A.mas[0] + B.mas[0]);
                    temp_pd.Add(0);
                    for (int i = 1; i < n1; i++)
                    {
                        int posA1 = A.pd[i - 1];//положение предыдужещего диагонального элем
                        int posB1 = B.pd[i - 1];
                        int posA = A.pd[i];//текущего
                        int posB = B.pd[i];
                        if (posA - posA1 == posB - posB1)
                        {
                            bool flag = true;
                            count = posA - posA1;//количество элементов в строке
                            for ( j = 1; j < count; j++)
                            {
                                if ((A.mas[posA1 + j] + B.mas[posB1 + j] == 0) && flag)
                                        flag = true;
                                else
                               {
                                        temp.Add(A.mas[posA1 + j] + B.mas[posB1 + j]);
                                        flag = false;
                               }
                            }
                            temp.Add(A.mas[posA] + B.mas[posB]);
                            
                        }
                        else
                        {
                            if (posA - posA1 > posB - posB1)
                            {
                                while (posA - posA1 != posB - posB1)//доходим до равной позиции
                                { 
                                    posA1++;
                                    temp.Add(A.mas[posA1]);
                                   
                                }
                                count = posB - posB1;
                                for (j = 1; j <= count; j++)
                                {
                                    
                                        temp.Add(A.mas[posA1 + j] + B.mas[posB1 + j]);
                                      
                                }
                               
                            }
                            else
                            {
                                 while (posA - posA1 != posB - posB1)//доходим до равной позиции
                                {
                                    temp.Add(B.mas[posB1 + 1]);
                                    posB1++;
                                }
                                 count = posA - posA1;
                                 for (j = 1; j <= count; j++)
                                 {

                                     temp.Add(A.mas[posA1 + j] + B.mas[posB1 + j]);

                                 }
                            }
                        }

                        temp_mas.AddRange(temp);
                        temp_pd.Add(temp_mas.Count - 1);
                        temp.Clear();
                    }
                    C.mas = new int[temp_mas.Count];
                    C.pd = new int[temp_pd.Count];
                    C.mas = temp_mas.ToArray();
                    C.pd = temp_pd.ToArray();
                    return C;
                 }

            }
        }

     
           
        
    }
}
