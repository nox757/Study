using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LAB_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "лаб1.2";
            button2.Text = "лаб1.3";

        }

        private bool proverka(string str)
        {
            int currState = 0, j;
            int[,] matr = {
                              //0  1  f 
                              { 1, 6, 0 },//A   0 
                              { 2, 6, 0 },//B   1 
                              { 3, 5, 1 },//C   2
                              { 0, 5, 1 },//D   3
                              { 0, 0, 0 },//E   4
                              { 3, 5, 1 },//F   5   
                              { 1, 6, 0 },//G   6  
            };


            for (int i = 0; i < str.Length; i++)
            {
                j = Convert.ToInt32(str[i].ToString());
                currState = matr[currState, j];
            }
            if (matr[currState, 2] == 1)
                return true;
            return false;
        }


        private bool proverka2(string str)
        {
            int currState = 0, j;
            int[,] matr = {
                              //0       1       2   3   4   5
                              //I-Ni-n  A-Za-z  0-9 _ pr_znk f 
                              { 1,      2,      2,  2,  2,   1},//   0 
                              { 1,      1,      1,  1,  2,   1},//   1  
                              { 2,      2,      2,  2,  2,   0},//   2 
                              
            };


            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '_')
                    j = 3;
                else
                    j = 4;
                if ((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z'))
                    j = 1;
                if ((str[i] >= 'I' && str[i] <= 'N') || (str[i] >= 'i' && str[i] <= 'n'))
                    j = 0;
                if ((str[i] >= '0' && str[i] <= '9'))
                    j = 2;                
                currState = matr[currState, j];
            }
            if (matr[currState, 5] == 1)
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            str = textBox1.Text;
            try
            {
                if (proverka(str) && str != "")
                {
                    label1.Text = str + "  YES";
                }
                else
                    label1.Text = str + "  NO";
            }
            catch(SystemException E)
            {
                MessageBox.Show("ONLY '0' AND '1'");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str;
            str = textBox1.Text;
            if (proverka2(str) && str != "")
            {
                label1.Text = str + "  YES";
            }
            else
                label1.Text = str + "  NO";
        }
    }
}
