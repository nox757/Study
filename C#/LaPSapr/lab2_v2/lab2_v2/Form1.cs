using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab2_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
        }

        public static List<List<string>> NFA = new List<List<string>>();
        public static int count = 0;
        public static List<List<string>> DFA_1 = new List<List<string>>();
        public static int count_1 = 0;
        public static List<List<string>> DFA_2 = new List<List<string>>();
        public static int count_2 = 0;



        private void new_NFA()//add empty state
        {
            NFA.Add(new List<string>());
            for (int i = 0; i < 4; i++)
            {
                NFA[count].Add("");
            }
            count++;
        }
        private void new_DFA_2()//add empty state
        {
            DFA_2.Add(new List<string>());
            for (int i = 0; i < 4; i++)
            {
                DFA_2[count_2].Add("");
            }
            count_2++;
        }

        private void out_NFA()
        {
            textBox2.AppendText(" \t 0\t 1\t e\t f\t\n");
            string s_temp = "";
            for (int i = 0; i < count; i++)
            {
                s_temp = i.ToString() + "\t";
                for(int j = 0; j < 4; j++)
                {
                    if (NFA[i][j] == "")
                        s_temp += "-" + "\t";
                    else
                    {
                        s_temp += NFA[i][j] + "\t";
                    }
                }
                s_temp += "\n";
                textBox2.AppendText(s_temp);
            }
        }

        private void out_DFA()
        {
            textBox3.AppendText(" \t 0\t 1\t e\t f\t\n");
            string s_temp = "";
            for (int i = 0; i < count_1; i++)
            {
                s_temp = i.ToString() + "\t";
                for (int j = 0; j < 4; j++)
                {
                    if (DFA_1[i][j] == "" )//&& j != 2)
                        s_temp += "-" + "\t";
                    else
                    {
                        //if(j != 2)
                            s_temp += DFA_1[i][j] + "\t";
                    }
                }
                s_temp += "\n";
                textBox3.AppendText(s_temp);
            }
        }
        private void out_DFA_2()
        {
            textBox3.AppendText(" \t 0\t 1\t e\t f\t\n");
            string s_temp = "";
            for (int i = 0; i < count_2; i++)
            {
                s_temp = i.ToString() + "\t";
                for (int j = 0; j < 4; j++)
                {
                    if (DFA_2[i][j] == "")//&& j != 2)
                        s_temp += "-" + "\t";
                    else
                    {
                        //if(j != 2)
                        s_temp += DFA_2[i][j] + "\t";
                    }
                }
                s_temp += "\n";
                textBox3.AppendText(s_temp);
            }
        }
        private bool regular1(int first, int last, string curr_reg)
        {
            int len_reg = curr_reg.Length;
            int first_1 = first, last_1 = last;
            int temp = 0;
            int prev_reg = -1;
            int flag_sym = -1;
            for (int i = 0; i < len_reg; i++)
            {
                flag_sym = 0;
                if (curr_reg[i] == '(')
                {
                    int count_skb = 1, j = i + 1;
                    while (count_skb != 0 && j < len_reg)
                    {
                        if (curr_reg[j] == ')')
                            count_skb--;
                        if (curr_reg[j] == '(')
                            count_skb++;
                        j++;
                    }
                    if (count_skb != 0)
                        return false;
                    else
                    {
                        j = j - 1;
                        if (j  >= len_reg)
                            return false;
                        else
                        {
                            string s2 = "";
                            s2 = curr_reg.Substring(i + 1, j - i - 1);
                            if (prev_reg != -1)//если есть предшествующая дуга
                            {
                                new_NFA();
                                NFA[first_1][prev_reg] += "," + (count - 1).ToString();
                                first_1 = count - 1;
                                prev_reg = -1;
                            }
                            if (j == len_reg - 1)//закрывающая скобка последняя в строке
                            {
                                return regular1(first_1, last, s2);
                            }
                            else
                            {
                                if (curr_reg[j + 1] == '*')//вариант )*
                                {
                                    new_NFA();
                                    NFA[first_1][2] += "," + (count - 1).ToString();
                                    first_1 = count - 1;
                                    prev_reg = 2;

                                    if(!regular1(first_1, first_1, s2))
                                        return false;
                                    i = j + 1;
                                    continue;
                                    
                                }
                                else
                                {
                                    if (curr_reg[j + 1] == '+')//вариант )+
                                    {
                                        new_NFA();
                                        last_1 = count - 1;
                                        if (!regular1(first_1, last_1, s2))
                                            return false;

                                        first_1 = last_1;
                                        prev_reg = 2;

                                        if (!regular1(first_1, first_1, s2))
                                            return false;
                                        i = j + 1;
                                        continue;
                                    }
                                    else//после скобок что-то есть
                                    {
                                        if (curr_reg[j + 1] == '|' || curr_reg[j + 1] == ')')
                                            last_1 = last;
                                        else
                                        {
                                            new_NFA(); //новая конечная вершина для скобок
                                            last_1 = count - 1;
                                        }
                                        if (!regular1(first_1, last_1, s2))
                                            return false;
                                        first_1 = last_1;
                                        i = j;
                                        continue;
                                    }
                                }

                            }
                            
                        }
                    }
                }
                if (curr_reg[i] == '|')
                {
                    flag_sym = 1;
                    if (i == len_reg - 1)
                        return false;
                    if(prev_reg != -1)
                        NFA[first_1][prev_reg] += "," + last.ToString();
                    first_1 = first;
                    last_1 = last;
                    prev_reg = -1;                    
                }
                if (curr_reg[i] == '0')
                {
                    flag_sym = 1;
                    temp = 1;//flag * or +

                    if (i + 1 < len_reg)
                    {
                        if (curr_reg[i + 1] == '+')
                        {
                            if (prev_reg == -1)
                            {
                                new_NFA();
                                NFA[first_1][0] += "," + (count - 1).ToString();
                                NFA[count - 1][0] += "," + (count - 1).ToString();
                                prev_reg = 2;
                                first_1 = count - 1;
                                i = i + 1;
                                temp++;
                            }
                            else
                            {
                                new_NFA();
                                last_1 = count - 1;
                                NFA[first_1][prev_reg] += "," + (last_1).ToString();
                                first_1 = count - 1;

                                new_NFA();
                                NFA[first_1][0] += "," + (count - 1).ToString();
                                NFA[count - 1][0] += "," + (count - 1).ToString();
                                prev_reg = 2;
                                first_1 = count - 1;
                                i = i + 1;
                                temp++;
                            }
                        }
                        else
                        {

                            if (curr_reg[i + 1] == '*')
                            {
                                if (prev_reg == -1)
                                {
                                    new_NFA();
                                    NFA[first_1][2] += "," + (count - 1).ToString();
                                    NFA[count - 1][0] += "," + (count - 1).ToString();
                                    prev_reg = 2;
                                    first_1 = count - 1;
                                    i = i + 1;
                                    temp++;
                                }
                                else
                                {
                                    new_NFA();
                                    last_1 = count - 1;
                                    NFA[first_1][prev_reg] += "," + (last_1).ToString();
                                    first_1 = count - 1;

                                    new_NFA();
                                    NFA[first_1][2] += "," + (count - 1).ToString();
                                    NFA[count - 1][0] += "," + (count - 1).ToString();
                                    prev_reg = 2;
                                    first_1 = count - 1;
                                    i = i + 1;
                                    temp++;
                                }
                            }
                        }
                    }
                    if (temp == 1)
                    {
                        if (prev_reg == -1)
                            prev_reg = 0;
                        else
                        {
                            new_NFA();
                            last_1 = count - 1;
                            NFA[first_1][prev_reg] += "," + (last_1).ToString();
                            first_1 = count - 1;
                            prev_reg = 0;
                        }
                    }
                }
                if (curr_reg[i] == '1') //начало и конец соединение
                {
                    flag_sym = 1;
                    temp = 1;//flag * or +

                    if (i + 1 < len_reg)
                    {
                        if (curr_reg[i + 1] == '+')
                        {
                            if (prev_reg == -1)
                            {
                                new_NFA();
                                NFA[first_1][1] += "," + (count - 1).ToString();
                                NFA[count - 1][1] += "," + (count - 1).ToString();
                                prev_reg = 2;
                                first_1 = count - 1;
                                i = i + 1;
                                temp++;
                            }
                            else
                            {
                                new_NFA();
                                last_1 = count - 1;
                                NFA[first_1][prev_reg] += "," + (last_1).ToString();
                                first_1 = count - 1;

                                new_NFA();
                                NFA[first_1][1] += "," + (count - 1).ToString();
                                NFA[count - 1][1] += "," + (count - 1).ToString();
                                prev_reg = 2;
                                first_1 = count - 1;
                                i = i + 1;
                                temp++;
                            }
                        }
                        else
                        {

                            if (curr_reg[i + 1] == '*')
                            {
                                if (prev_reg == -1)
                                {
                                    new_NFA();
                                    NFA[first_1][2] += "," + (count - 1).ToString();
                                    NFA[count - 1][1] += "," + (count - 1).ToString();
                                    prev_reg = 2;
                                    first_1 = count - 1;
                                    i = i + 1;
                                    temp++;
                                }
                                else
                                {
                                    new_NFA();
                                    last_1 = count - 1;
                                    NFA[first_1][prev_reg] += "," + (last_1).ToString();
                                    first_1 = count - 1;

                                    new_NFA();
                                    NFA[first_1][2] += "," + (count - 1).ToString();
                                    NFA[count - 1][1] += "," + (count - 1).ToString();
                                    prev_reg = 2;
                                    first_1 = count - 1;
                                    i = i + 1;
                                    temp++;
                                }
                            }
                        }
                    }
                    if (temp == 1)
                    {
                        if (prev_reg == -1)
                            prev_reg = 1;
                        else
                        {
                            new_NFA();
                            last_1 = count - 1;
                            NFA[first_1][prev_reg] += "," + (last_1).ToString();
                            first_1 = count - 1;
                            prev_reg = 1;
                        }
                    }
                }
                if (flag_sym == 0)
                    return false;
            }
            if (prev_reg != -1)
            {
                NFA[first_1][prev_reg] += "," + last.ToString();
            }
            return true;
        }


        private string no_repeat(string s)//убираем повторяющиеся переходы
        {
            string res = "";
            int[] a = s.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
            int count_a = a.Count();
           
            if (count_a <= 0)
                return res;
            else
            { 
                Array.Sort(a);
                res += a[0].ToString();
                for (int i = 1; i < count_a; i++)
                    if(a[i-1] != a[i])
                        res += "," + a[i].ToString();
                return res;
            }
        }

        private void no_repeat_NFA()
        {
            for (int i = 0; i < count; i++)
                for (int j = 0; j < 4; j++)
                    NFA[i][j] = no_repeat(NFA[i][j]);
        }

        private void clone_DFA()
        {
            count_1 = count;
            for(int i = 0; i < count; i++)
            {   
                DFA_1.Add(new List<string>());
                for(int j = 0; j < 4; j++)
                {
                    DFA_1[i].Add(NFA[i][j]);
                }
            }
        }
        private void del_e_DFA()
        {
            for (int i = 0; i < count_1; i++)
            {
                while (DFA_1[i][2] != "")
                {
                    int g = DFA_1[i][2].IndexOf(',');
                    int k = 0;
                    if (g != -1)
                    {
                        k = Convert.ToInt32(DFA_1[i][2].Substring(0, g));
                        DFA_1[i][2] = DFA_1[i][2].Substring(g + 1);
                    }
                    else
                    {
                        k = Convert.ToInt32(DFA_1[i][2]);
                        DFA_1[i][2] = "";
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        DFA_1[i][j] = no_repeat(DFA_1[i][j] + ","+ DFA_1[k][j]);
                    }
                }
            }
        }

        public static List<string> temp = new List<string>();
        
        
        
        private void union1_DFA(int ind)
        {
            for (int i = 0; i < 2; i++)
            {
                if (DFA_2[ind][i] != "")
                {
                    int j = 0;
                    for (j = 0; j < temp.Count && DFA_2[ind][i] != temp[j]; j++) ;
                    if (j == temp.Count)
                    {
                       
                        temp.Add(DFA_2[ind][i]);
                        DFA_2[ind][i] = j.ToString();
                        
                        new_DFA_2();
                        int[] a = temp[j].Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
                        for(int k = 0; k < a.Count(); k++)
                        {
                            for(int j2 = 0; j2 < 4; j2++)
                            {
                                DFA_2[j][j2] = no_repeat(DFA_2[j][j2] + ","+ DFA_1[a[k]][j2]);
                            }
                        }
                        union1_DFA(j);
                    }
                    else
                    {
                        DFA_2[ind][i] = j.ToString();
                        DFA_2[ind][3] = DFA_2[j][3];
                    }
                }
            }
        }
        private void union_DFA()
        {
           
            new_DFA_2();
            for (int j = 0; j < 3; j++)
            {
                if (DFA_1[0][j] != "")
                {
                    DFA_2[0][j] = DFA_1[0][j];
                }
            }
            DFA_2[0][3] = DFA_1[0][3];
            temp.Add("0");
            union1_DFA(0);
         
        }


        private void equal_DFA()
        {
            List<List<int>> mnog = new List<List<int>>();
            mnog.Add(new List<int>());
            mnog.Add(new List<int>());
            int size = 2;//количесво множеств
            for (int i = 0; i < count_2; i++)//разбили на два подмноженства
            {
                if (DFA_2[i][3] == "1")
                    mnog[1].Add(i);
                else
                    mnog[0].Add(i);
            }
            for (int i = 0; i < size; i++)
            {
                if (mnog[i].Count() > 1)
                {
                    for (int j = 0; j < mnog[i].Count() - 1; j++)//идем по подмножеству
                    {
                        int m1_0 = Convert.ToInt32(DFA_2[mnog[i][j]][0]);
                        int m2_0 = Convert.ToInt32(DFA_2[mnog[i][j + 1]][0]);
                        int m1_1 = Convert.ToInt32(DFA_2[mnog[i][j]][1]);
                        int m2_1 = Convert.ToInt32(DFA_2[mnog[i][j + 1]][1]);
                        int t;
                        for (int i1 = 0; i1 < size; i1++)
                            if ((t = mnog[i1].IndexOf(m1_0)) != -1)
                            {

                            }
                    }
                }
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            new_NFA();//0
            new_NFA();//1
            NFA[1][3] = ",1";
            string curr_reg = textBox1.Text;//read regular
            if (curr_reg == "")
            {
                MessageBox.Show("Пустая строка!!!");
                NFA.Clear();
                count = 0;
                textBox1.Text = "";
            }
            else
            {
                if(!regular1(0, 1, curr_reg))
                    MessageBox.Show("Ошибка в выражении");
                else
                {
                    label1.Text = curr_reg;                   
                    no_repeat_NFA();
                    out_NFA();

                    clone_DFA();
                    del_e_DFA();            
                    out_DFA();
                    union_DFA();
                    out_DFA_2();
                    //0|01*|01+
                    //очистка
                    NFA.Clear();
                    DFA_1.Clear();
                    count_1 = 0;
                    count = 0;
                    textBox1.Text = "";
                }
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            NFA.Clear();
            count = 0;
            label1.Text = "";    
            //label1.Text = no_repeat("1");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

    }
}
