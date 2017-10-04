using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab_mp_3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
        }

        private Stack <int> st = new Stack<int>();

        private Stack<char> st2_1 = new Stack<char>();
        private Stack<char> st2_2 = new Stack<char>();
        private string str = "";
        private bool proverka(string s)
        {

          
            int curr_state = 1;
            int i = 0;
            while (i < s.Length)
            {                
                if (curr_state == 1)
                {
                    if (s[i] == '1' && st.Peek() == -2)
                    {
                        st.Push(1);
                        curr_state = 1;
                        i++;
                    }
                    else
                    {
                        if (s[i] == '1' && st.Peek() == 1)
                        {
                            curr_state = 1;
                            st.Push(1);
                            i++;
                        }
                        else
                        {
                            if (s[i] == '0' && st.Peek() == 1)
                            {
                                st.Pop();
                                curr_state = 2;
                                i++;
                            }
                            else
                                return false;
                        }
                    }
                }
                else
                {
                    if (curr_state == 2)
                    {
                        if (s[i] == '0' && st.Peek() == 1)
                        {
                            st.Pop();
                            curr_state = 2;
                            i++;
                        }
                        else
                        {
                            if (s[i] == '1' && st.Peek() == -2)
                            {
                                curr_state = 3;
                                st.Push(1);
                                i++;
                            }
                            else
                                 return false;
                        }
                    }
                    else
                    {
                        if (curr_state == 3)
                        {
                            if (s[i] == '0' && st.Peek() == 1)
                            {
                                curr_state = 4;
                                st.Pop();
                                i++;
                            }
                            else
                            {
                                if (s[i] == '1' && st.Peek() == 1)
                                {
                                    st.Push(1);
                                    curr_state = 3;
                                    i++;
                                }
                                else
                                    return false;
                            }

                        }
                        else
                            if (curr_state == 4)
                            {
                                if (s[i] == '0' && st.Peek() == 1)
                                {
                                    curr_state = 4;
                                    st.Pop();
                                    i++;
                                }
                                else
                                {
                                    return false;
                                }

                            }
                            else
                                return false;
                    }
                }
            }
            if (curr_state == 4 && st.Peek() == -2)
                return true;
            else
                return false;

        }

        private bool proverka2(string s)
        {
            int i = 0;
            str = "";
            while (i < s.Length)
            {
                if (st2_1.Peek() == 'z')
                {
                    if (s[i] == '1')
                    {
                        st2_1.Pop();
                        st2_1.Push('x');
                        st2_1.Push('z');
                        i++;
                    }
                    else
                    {
                        if (s[i] == '0')
                        {
                            st2_1.Pop();
                            st2_1.Push('y');
                            st2_2.Push('t');
                            i++;
                            str += '1';
                        }
                        else
                            return false;
                    }
                }
                else
                {
                    if (st2_1.Peek() == 'y')
                    {
                        if (s[i] == '1')
                        {
                            st2_1.Pop();
                        }
                        else
                        {
                            if (s[i] == '0')
                            {
                                st2_2.Push('t');
                                i++;
                                str += '1';
                            }
                            else
                                return false;
                        }
                    }
                    else
                    {
                        if (st2_1.Peek() == 'x')
                        {
                            if (s[i] == '1')
                            {
                                st2_1.Pop();
                                i++;
                                str += '0';
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (st2_1.Peek() == 'n')
                            {
                                if (s[i] == '0' && st2_2.Peek() == 't')
                                {
                                    st2_2.Pop();
                                    i++;
                                    str += '0';
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                                return false;
                        }
                    }
                }
            }
            if (st2_1.Peek() == 'n' && st2_2.Peek() == 'n')
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            st.Clear();
            st.Push(-2);


            if (s != "")
            {
                label1.Text = s;
                if (proverka(s))
                {
                   
                    label2.Text = "OK";
                }
                else
                    label2.Text ="NO";
            }
            else
            {
                MessageBox.Show("Пустая строка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            st2_1.Clear();
            st2_1.Push('n');
            st2_1.Push('z');
            st2_2.Clear();
            st2_2.Push('n');

            if (s != "")
            {
                label1.Text = s;
                if (proverka2(s))
                {

                    label2.Text = str;
                }
                else
                    label2.Text = "NO";
            }
            else
            {
                MessageBox.Show("Пустая строка");
            }
        }
    }
}
