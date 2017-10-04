using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace matrixKA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            checkBox1.Text = "4";
            button1.Text = "OK";
            button2.Text = "CLEAR";
            textBox1.Text = "A";
            textBox2.Text = "B";
            textBox3.Text = "C";
            textBox4.Text = "D";

            maskedTextBox10.Hide();
            maskedTextBox11.Hide();
            maskedTextBox12.Hide();
            textBox4.Hide();
            
         
        }

        private List <string> R_Gram = new List<string>();
        private List <string> L_Gram = new List<string>();
        private List<string> R_Gram_e = new List<string>();
        private List<string> L_Gram_e = new List<string>();
        private int n = 3;
        private string[] str0 = { "0", "1"," e ", " ::= ", " | " };
                                // 0    1   2       3       4

        private void MatrToR_Gram(int[,] matr, int k, string[] noterm)
        {

            string temp = "";

            for (int i = 0; i < n; i++)
            {
                temp += noterm[i] + str0[3];  
               
                for (int j = 0; j < k; j++)
                {
                    if (matr[i, j] != -1)
                    {
                        if (j != k - 1)
                            temp += str0[j] + noterm[matr[i, j]] + str0[4];
                        else
                            temp += str0[j] + str0[4];
                    }
                }
                if (temp[temp.Length - 2] == '|')
                    temp = temp.Substring(0, temp.Length - 3);
                R_Gram.Add(temp);
                temp = "";
            }

        }

        private void MatrToR_Gram_e(int[,] matr, int k, string[] noterm)
        {
            string temp = "";

            for (int i = 0; i < n; i++)
            {
                temp += noterm[i] + str0[3];  
               
                for (int j = 0; j < k - 1; j++)
                {
                    if (matr[i, j] != -1)
                    {
                       temp += str0[j] + noterm[matr[i, j]] + str0[4];
                       if(matr[matr[i,j], k - 1] == 1)
                          temp += str0[j] + str0[4];
                       
                    }
                }
                if (temp[temp.Length - 2] == '|')
                    temp = temp.Substring(0, temp.Length - 3);
                R_Gram_e.Add(temp);
                temp = "";
            }           

        }

        private void MatrToL_Gram(int[,] matr, int k, string[] noterm)
        {

            string temp = "";           


            for (int i = 0; i < n; i++)
            {
                temp += noterm[i] + str0[3];
                L_Gram.Add(temp);
                temp = "";
            }
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k - 1; j++)
                {
                    if (matr[i, j] != -1)
                    {
                        L_Gram[matr[i, j]] += noterm[i] + str0[j] + str0[4];  
                    }
                }
            }
            L_Gram[0] += str0[k - 1];
            for (int i = 0; i < n; i++)//удаление последней черты
            {
                int j = L_Gram[i].Length;
                if (L_Gram[i][j - 2] == '|')
                    L_Gram[i] = L_Gram[i].Substring(0, j - 3);                    
                
            }            
        }

        private void MatrToL_Gram_e(int[,] matr, int k, string[] noterm)//без е
        {

            string temp = "";

            for (int i = 0; i < n; i++)
            {
                temp += noterm[i] + str0[3];
                L_Gram_e.Add(temp);
                temp = "";
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k - 1; j++)
                {
                    if (matr[i, j] != -1)
                    {
                        if (i != 0)
                        {
                            L_Gram_e[matr[i, j]] += noterm[i] + str0[j] + str0[4];
                        }
                        else
                        {
                            L_Gram_e[matr[i, j]] += noterm[i] + str0[j] + str0[4] + str0[j] + str0[4];
                        }
                    }
                }
            }
            for (int i = 0; i < n; i++)//удаление последней черты
            {
                int j = L_Gram_e[i].Length;
                if (L_Gram_e[i][j - 2] == '|')
                    L_Gram_e[i] = L_Gram_e[i].Substring(0, j - 3);

            } 
        }


    
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0, k = 3;
            int[,] matr;
            string str_temp = "";
            matr = new int[n, k];
            string[] nt = {textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text};
            

           foreach (Control ctrl in panel1.Controls) // считывание данных, создание матрицы
           {
                
                if (ctrl.GetType() == typeof(MaskedTextBox))
                {
                    i = ctrl.TabIndex;
                    str_temp = ctrl.Text;
                    if (n * k >= i)
                    {
                        if ((i - 1) % k == k - 1)
                        {
                            if(str_temp == "1")
                                matr[(i - 1) / k, (i - 1) % k] = 1;
                            else
                            {
                                matr[(i - 1) / k, (i - 1) % k] = -1;
                                ctrl.Text = "-1";
                            }
                        }
                        else
                        {
                            int g;
                            for (g = 0; g < n && str_temp != nt[g]; g++)
                            {
                            }                              
                            if (g < n)
                                matr[(i - 1) / k, (i - 1) % k] = g;
                            else
                            {
                                matr[(i - 1) / k, (i - 1) % k] = -1;
                                ctrl.Text = "-1";
                            }
                        }
                    }
                }
            }
            R_Gram.Clear();
            L_Gram.Clear();
            R_Gram_e.Clear();
            L_Gram_e.Clear();

            MatrToR_Gram(matr, k, nt);
            MatrToL_Gram(matr, k, nt);

            MatrToL_Gram_e(matr, k, nt);
            MatrToR_Gram_e(matr, k, nt);

            for (int g = 0; g < n; g++)//Вывод
            {
                textBox5.AppendText(R_Gram[g] + "\n");
                textBox6.AppendText(L_Gram[g] + "\n");
            }
            textBox5.AppendText("\n");
            textBox6.AppendText("\n");

            for (int g = 0; g < n; g++)//Вывод без e
            {
                textBox5.AppendText(R_Gram_e[g] + "\n");
                textBox6.AppendText(L_Gram_e[g] + "\n");
            }
            textBox5.AppendText("\n");
            textBox6.AppendText("\n");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (!checkBox1.Checked)
            {
                maskedTextBox10.Hide();
                maskedTextBox11.Hide();
                maskedTextBox12.Hide();
                textBox4.Hide();
                n = 3;
            }
            else
            {
                maskedTextBox10.Show();
                maskedTextBox11.Show();
                maskedTextBox12.Show();
                textBox4.Show();
                n = 4;
            }
           
        }




        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskedTextBox1.SelectAll();
            maskedTextBox2.SelectAll();
            maskedTextBox3.SelectAll();
            maskedTextBox4.SelectAll();
            maskedTextBox5.SelectAll();
            maskedTextBox6.SelectAll();
            maskedTextBox7.SelectAll();
            maskedTextBox8.SelectAll();
            maskedTextBox9.SelectAll();
            maskedTextBox10.SelectAll();
            maskedTextBox11.SelectAll();
            maskedTextBox12.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();
        }
        

    }
}
