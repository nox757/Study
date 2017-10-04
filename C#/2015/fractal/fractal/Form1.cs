using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fractal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 3000;//интервал таймера
            timer1.Enabled = false;
            
        }

        int i = 0/*счетчик шага*/, l0 = 256/*длина средней черты*/, n = 256/*до какой длины рисовать*/;        
        
        
        /// <summary>
        /// Отрисовка фрактала
        /// </summary>
        /// <param name="x">абцисса середины</param>
        /// <param name="y">ордината середины</param>
        /// <param name="l">длина черты</param>
        void draw_fractal(int x, int y, int l)
        {
           Graphics graph = Graphics.FromHwnd(pictureBox1.Handle);
            var drawing_pen = new Pen(Brushes.Black, 1);
            
            if (l >= n)
            {
                l /= 2;
                //отрисовка буквы
                graph.DrawLine(drawing_pen, x - l, y, x + l, y);
                graph.DrawLine(drawing_pen, x - l, y - l, x - l, y + l);
                graph.DrawLine(drawing_pen, x + l, y - l, x + l, y + l); 
                //рекурсивная отрисовка остальных букв
                draw_fractal(x - l, y - l, l);
                draw_fractal(x - l, y + l, l);
                draw_fractal(x + l, y + l, l);
                draw_fractal(x + l, y - l, l);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
            }
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int x0 = pictureBox1.Size.Width / 2;
            int y0 = pictureBox1.Size.Height / 2;

            if (n < 2)
            {
                n = 256;
                i = 0;
                timer1.Enabled = false;

            }
            else
            { 
                i++;
                Graphics graph = Graphics.FromHwnd(pictureBox1.Handle);
                graph.Clear(Color.White);
                label1.Text = i.ToString();
                draw_fractal(x0, y0, l0);
                n /= 2;       
                
            }
        }
    }
}
