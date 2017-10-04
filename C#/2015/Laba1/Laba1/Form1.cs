using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label1.Text = "0";
            
        }
            QueueLst ql = new QueueLst(1, "one", 5);
            QueueArr qa = new QueueArr(2, "two", 5);
            StackLst sl = new StackLst(3,"three",5);
            StackArr sa = new StackArr(4, "four",5);
            Numerator count = new Numerator();
            
        private void buttClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button_show1_Click(object sender, EventArgs e)
        {
            show(1);
            
        }

        private void button_show2_Click(object sender, EventArgs e)
        {
            show(2);
        }

        private void button_show3_Click(object sender, EventArgs e)
        {
            show(3);
        }

        private void button_show4_Click(object sender, EventArgs e)
        {
            show(4);
        }
        private void show(int i)
        {
            switch (i)
            {
                case 1:
                    textBox1.AppendText(ql.ToString() + "\n");
                    break;
                case 2:
                    textBox1.AppendText(qa.ToString() + "\n");
                    break;
                case 3:
                    textBox1.AppendText(sl.ToString() + "\n");
                    break;
                case 4:
                    textBox1.AppendText(sa.ToString() + "\n");
                    break;
            }
        }
        private void buttAdd_Click(object sender, EventArgs e)
        {
            int i = tabControl1.SelectedIndex;
            Request req0 = new Request(count.GetNewNum(), "req");
            label1.Text = count.CurNum.ToString();            
            switch (i)
            {
                case 0:
                    ql.AddReq(req0);             
                    break;
                case 1:
                    qa.AddReq(req0);
                    break;
                case 2:
                    sl.AddReq(req0);
                    break;
                case 3:
                    sa.AddReq(req0);
                    break;                    
            }
            show(i+1);
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            int i = tabControl1.SelectedIndex;         
            
            switch (i)
            {
                case 0:
                    ql.RemoveReq();             
                    break;
                case 1:
                    qa.RemoveReq();
                    break;
                case 2:
                    sl.RemoveReq();
                    break;
                case 3:
                    sa.RemoveReq();
                    break;                    
            }
            show(i+1);
        
        }
    }
}
