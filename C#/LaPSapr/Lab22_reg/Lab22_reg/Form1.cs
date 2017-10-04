using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab22_reg
{
    public partial class Form1 : Form
    {
        public static int count = 2;
        public static  List<int[]> NKA = new List<int[]>();

        public static char[] symbols = {'(', ')', '*', '+', '0', '1', '|'};//7

        private void NKA_clear(int i)
        {
            if (i == 0)
            {
                NKA.Clear();
                count = 0;
            }
            else
            {
                NKA.Clear();
                for (int j = 0; j < i; j++)
                    NKA.Add(new int[3]);
            }
        }

        public Form1()
        {
            InitializeComponent();
            NKA.Add(new int[3]);
            NKA.Add(new int[3]);
        }

        private int add_NKA_1(int left, int right, int fon, int num )
        {
          
            if (num == 0)///r == p | q // parral, obuchnoe dobavl
            {
                NKA[left][fon] = right;
                return right;
            }
            
            if (num == 1)///r == pq ///ishodzshay duga,new finish
            {
                NKA.Add(new int[3]);
                NKA[right][fon] = count;
                count++;
                return count - 1;
            }
            if (num == -1)//r in r ///samo v sebya
            {
                NKA[left][fon] = right;
                return right;
            }


          /*  if (num == 3)///r == p*
            {
                NKA.Add(new int[3]);
                NKA[right][3] = count;
                NKA[count][fon] = count;
                count++;

                NKA.Add(new int[3]);
                NKA[count-1][3] = count;
                count++;
                return count - 1;
            }

            if (num == 3)///r == p+
            {
                NKA.Add(new int[3]);
                NKA[right][fon] = count;
                NKA[count][fon] = count;
                count++;

                NKA.Add(new int[3]);
                NKA[count - 1][3] = count;
                count++;
                return count - 1;
            }*/

            return -1;
        }


        private bool reg(string str)
        {
            
            //skb
            int str_len = str.Length;
            int left = 0, right = 1, temp = 0;
            for (int i = 0; i < str_len; i++)
            {
                temp = 0;
                if (str[i] == '0' && temp == 0)
                {
                    add_NKA_1(left, right, 0, 0);
                    temp++;
                }
                if (str[i] == '0')
                    ;

            }
            

            return false;
        }


        string curr, str;
        int type_curr, i_str = -1;

        private void Get_curr()
        {
            curr = "";
            type_curr = -1;
            if (i_str >= str.Length)
                return;
            if(str[i_str]


        }


        private int add_NKA(int left, int right, int fon, int num)
        {
            if (num == 0)///просто вершина
            {
                NKA.Add(new int[3]);
                count++;
                return count - 1;
            }
            if (num == 1)///
            {
                NKA[left][fon] = right;
                return right;
            }

            if (num == 2)///r == pq
            {
                NKA.Add(new int[3]);
                NKA[right][fon] = count;
                count++;
                return count - 1;
            }
            if (num == 3)///r == p*
            {
                NKA.Add(new int[3]);
                NKA[left][2] = count;
                NKA[count][fon] = count;
                NKA[count][2] = right;
                count++;
                return right;
            }

            if (num == 4)///r == p+
            {
                NKA.Add(new int[3]);
                NKA[left][fon] = count;
                NKA[count][fon] = count;
                NKA[count][2] = right;
                count++;
                return right;
            }
            return -1;
        }

        private bool razbor(string str, int left, int right)
        {
            int count_skb = 0;
            int str_len = str.Length;
            int b_right = right, b_left = left;
            int temp = 0;
            if (str[0] == '0')//добавить условие на скобочку
            {
                add_NKA(left, right, 0, 1);
            }
            else
                if (str[0] == '1')
                {
                    add_NKA(left, right, 1, 1);
                }
                else
                    return false;
            
            for (int i = 1; i < str_len; i++)///??????
            {
                ///анализ скобочной стуктуры 

                temp = 0;

                if (str[i] == '|')
                {
                    right = b_right;
                    left = b_left;
                    temp++;
                }

                //анализ умножения
                if (i + 1 < str_len && str[i + 1] == '*')
                {
                    if (str[i] == '0')
                    {                        
                        right = add_NKA(left, right, -1, 0);
                        add_NKA(b_right, right, 0, 3);
                        b_right = right;
                        temp++;
                        i = i + 1;
                    }
                    else
                        if (str[i] == '1')
                        {                        
                            right = add_NKA(left, right, -1, 0);
                            add_NKA(b_right, right, 1, 3);
                            b_right = right;
                            i = i + 1;
                            temp++;
                        }
                        else
                            return false;                    
                }
                //анализ плюса
                if (i + 1 < str_len && temp == 0 && str[i + 1] == '+')
                {
                    if (str[i] == '0')
                    {                        
                        right = add_NKA(left, right, -1, 0);
                        add_NKA(left, right, 0, 4);
                        b_right = right;
                        temp++;
                        i = i + 1;
                    }
                    else
                        if (str[i] == '1')
                        {
                           right = add_NKA(left, right, -1, 0);
                            add_NKA(left, right, 1, 4);
                            b_right = right;
                            temp++;
                            i = i + 1;
                        }
                        else
                            return false;                    
                }


                if (str[i] == '0' && temp == 0)
                {
                    b_right = add_NKA(left, right, 0, 2);
                    right = b_right;
                    temp++;
                }
                if (str[i] == '1' && temp == 0)
                {
                    b_right = add_NKA(left, right, 1, 2);
                    right = b_right;
                    temp++;
                }

                if (temp != 1)
                    return false;
                
            }

            return true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void out_NKA()
        {
            string s;
            for(int i = 0; i < count; i++)
            {
                s = i.ToString() + " ";
                for (int j = 0; j < 3; j++)
                {
                    s += " " + NKA[i][j].ToString(); 
                }
                s += "\t\n";
                textBox2.AppendText(s);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            
            if (str != "")
            {
                razbor(str, 0, 1);
                out_NKA();
                NKA_clear(2);
                count = 2;
            }
            else
            {
                out_NKA();
                count = 2;
                NKA_clear(2);
            }
        }
    }
}
