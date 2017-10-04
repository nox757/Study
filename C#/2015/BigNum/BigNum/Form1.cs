using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BigNum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool IsDig(string s)
        {
            for(int i = 0; i < s.Length;i++)
                if (!(s[i] >= '0' && s[i] <= '9'))
                {
                    return false;
                }
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!IsDig(textBox1.Text))
            {
                MessageBox.Show("A-error", "Error");
            }
            else
            {
                BigNumber A = new BigNumber(textBox1.Text.ToString());
                textBox3.Text = A.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!IsDig(textBox2.Text))
            {
                MessageBox.Show("B-error", "Error");
            }
            else
            {
                BigNumber B = new BigNumber(textBox2.Text.ToString());
                textBox3.Text = B.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsDig(textBox2.Text) || !IsDig(textBox1.Text))
            {
                MessageBox.Show("A or B-eroro", "Error");
            }
            else
            {
                BigNumber A = new BigNumber(textBox1.Text.ToString());
                BigNumber B = new BigNumber(textBox2.Text.ToString());
                textBox3.Text = (A+B).ToString();
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!IsDig(textBox2.Text) || !IsDig(textBox1.Text))
            {
                MessageBox.Show("A or B-error", "Error");
            }
            else
            {
                BigNumber A = new BigNumber(textBox1.Text.ToString());
                BigNumber B = new BigNumber(textBox2.Text.ToString());
                if (A.Compare(B) >= 0)
                {

                    textBox3.Text = (A - B).ToString();
                }
                else
                {
                    textBox3.Text = "-" + (B - A).ToString();
                }
            }
        }

        
    }
}
