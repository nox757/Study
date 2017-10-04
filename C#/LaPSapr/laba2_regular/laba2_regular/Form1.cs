using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace laba2_regular
{
    public partial class Form1 : Form
    {

        public static int[,] mas = new int[28,3];
        public static int count = 2;
        public static List<List<int>> NKA = new List<List<int> >();

        public Form1()
        {
            InitializeComponent();
            button1.Text = "Разобрать";
            NKA.Add(new List<int>(3));
            NKA.Add(new List<int>(3));
            
        }
        private static char _ToChar(int i)
        {
            char t;              
            t = (char)((int)(char)('A') + i);
            return t;
        }
       
        private bool reg(int left, int right, string str)
        {
            int i = -1;
            if (left == -1)///скобки???
            {
            }


            // finish
            if (str.Length == 1)
            {
                if (str == "0")
                {
                    NKA[left][0] = right;
                    return true;
                }
                if (str == "1")
                {
                    NKA[left][1] = right;
                    return true;
                }
                return false;
            }


            //   0|1 - all
            if ((i = str.IndexOf('|')) != -1)//нет проверки конца стр./нач.
            { 
                //отладка
                textBox1.AppendText(str.Substring(0, i) + "\r\n");
                textBox1.AppendText(str.Substring(i + 1, str.Length - i - 1) + "\r\n");
               //кон.
                
                reg(left, right, str.Substring(0, i));
                reg(left, right, str.Substring(i + 1, str.Length - i - 1));               
            }

            //   a* - all
            if ((i = str.IndexOf('*')) != -1)
            {
                int len_str = str.Length;
                if(i == 0)
                {
                    return false;
                }
                else
                {
                    if (i == len_str - 1)//last position 0001*
                    {
                        if (len_str != 2) //! 1*
                        {
                            NKA.Add(new List<int>(3));//new left
                            reg(left, count, str.Substring(0, len_str - 2));
                            left = count;
                            count++;
                        }

                        NKA.Add(new List<int>(3));// "*"
                        NKA[left][2] = count;
                        NKA[count][2] = right;
                        reg(count, count, str.Substring(len_str - 2, 1));
                        count++;
                    }
                    else
                    {
                        if (i == 1)///  1*000
                        {
                            NKA.Add(new List<int>(3));//new rigth
                            reg(count, right, str.Substring(2, len_str - 2));
                            right = count;
                            count++;

                            NKA.Add(new List<int>(3));// "*"
                            NKA[left][2] = count;
                            NKA[count][2] = right;
                            reg(count, count, str.Substring(0, 1));
                            count++;
                        }
                        else
                        {  
                            NKA.Add(new List<int>(3));//new left
                            reg(left, count, str.Substring(0, i - 1));
                            left = count;
                            count++;

                            NKA.Add(new List<int>(3));//new rigth
                            reg(count, right, str.Substring(i + 1, len_str -  i - 1));
                            right = count;
                            count++;
                         

                            NKA.Add(new List<int>(3));// "*"
                            NKA[left][2] = count;
                            NKA[count][2] = right;
                            reg(count, count, str.Substring(i - 1, 1));
                            count++;
                            return false;
                        }
                    }

                }
                
                
            }


            


            return true;
/*         if (str.Length == 1)
            {
                if (str == "0")
                {
                    mas[left, 0] = right;
                    return true;
                }
                if (str == "1")
                {
                    mas[left, 0] = right;
                    return true;
                }
                return false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '|') 
                {
                    reg(left, right, str.Substring(0, i ));
                    reg(left, right, str.Substring(i + 1, str.Length - i -1));
                    return true;
                }               
                
            } 
            if (str[0] == '0' || str[0] == '1')
                {
                    count++;
                    reg(left, count - 1, str.Substring(0, 1));
                    reg(count -1, right, str.Substring(1,str.Length - 1));
                    return true;
                }
            return false;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            str = maskedTextBox1.Text;
            if (str != "")
            {
                if (!reg(0, 1, str))
                {
                     textBox1.AppendText("ОШИБКА \r\n");
                }

                for (int i = 0; i < count; i++)//output result mas
                {
                   
                 /*   str = "";
                    str += _ToChar(i) + " ";
                    for (int j = 0; j < 3; j++)
                    {
                        if (mas[i,j] != 0) 
                            str += _ToChar(mas[i, j]) + " ";
                        else
                            str += (mas[i, j]).ToString() + " ";
                    }
                    textBox1.AppendText(str + "\r\n");*/
                }

            }
        }
    }
}
