using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graphes
{
    public partial class Form1 : Form
    {
        private DataTable MatrixA = null;
        int[,] M;//матрица смежности


        public Form1()
        {
            InitializeComponent();
            //запрет удаления и добавления строк
            dataGridView1.AllowUserToAddRows = false; dataGridView1.AllowUserToDeleteRows = false;
            //инициализация данных
            MatrixA = new DataTable();
            
            dataGridView1.DataSource = MatrixA;            
            textBox1.Text = "1";
            ChangeSizes();
        }

        /// <summary>
        /// изменение размеров матриц по кнопке
        /// </summary>
        private void ChangeSizes()
        {
            int n;
            bool res = true;
            res = Matric.CheckInt(textBox1.Text, out n);
            if (!res)
                MessageBox.Show("Введены неположительные размеры матриц", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (n <= 0)
                {
                    MessageBox.Show("Введены неположительные размеры матриц", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SetMatrixSize(MatrixA, dataGridView1, n);                    
                }
            }

        }

        /// <summary>
        /// Задание размеров существующей таблицы (обновление имеющихся)
        /// </summary>
        private void SetMatrixSize(DataTable dt, DataGridView dgv, int n)
        {
            // добавляем столбцы
            int i, j;
            if (n > dt.Columns.Count)       // добавляем недостающие столбцы
                for (i = dt.Columns.Count; i < n; i++)
                {
                    // добавляем в DataTable столбец и задаём формат данных в нём
                    dt.Columns.Add(new DataColumn(/*"Column 1"*/(i).ToString(), typeof(string)));
                    dgv.Columns[i].Width = 35;  // задание ширины для отображения (поэтому DataGridView)
                    // DataTable только хранит данные, а ширина столбца - на уровне отображения

                    // Также здесь нужно проверить случай добавления столбцов при неизменном
                    // количестве строк, чтобы новые столбцы заполнить нулями
                    for (j = 0; j < dt.Rows.Count; j++)
                        dt.Rows[j][i] = "0";
                }
            else        // удаляем лишние столбцы
                for (i = dt.Columns.Count - 1; i >= n; i--) // обход с конца
                    // т.к. при удалении столбца следующий сместится на его место, Columns - список
                    dt.Columns.RemoveAt(i);

            // добавляем строки
            if (n > dt.Rows.Count)       // добавляем недостающие строки
                for (i = dt.Rows.Count; i < n; i++)
                {
                    //dt.Rows.Add(new DataRow());   // неизвестен формат, в котором должна быть строка
                    dt.Rows.Add(/*чей формат*/dt.NewRow());     // строка в формате имеющейся таблицы (dt)
                    for (j = 0; j < n; j++)
                        dt.Rows[i][j] = "0";
                }
            else
                for (i = dt.Rows.Count - 1; i >= n; i--) // обход с конца
                    // т.к. при удалении строки следующая сместится на её место, Rows - список
                    dt.Rows.RemoveAt(i);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeSizes();
            string mes;
            if (Matric.MatrixFromDataTable(MatrixA, MatrixA.Rows.Count, out M, out mes))
            {
               // MessageBox.Show("Good", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(mes, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       private void button2_Click(object sender, EventArgs e)
            {
                string mes;
                if (Matric.MatrixFromDataTable(MatrixA, MatrixA.Rows.Count, out M, out mes))
                {
                    //MessageBox.Show("Good", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(mes, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Kosar();
            }
    
        int[] used;
        List<int> v = new List<int>(), comp = new List<int>();
        
        int n;
        private void dfs1(int i)//первый поиск в глубину
        {
            used[i] = 1;
            for (int g = 0; g < n; g++)
            {
                if (used[g] == 0 && M[g,i] != 0)
                    dfs1(g); 
            }
            v.Add(i);//направление обхода
        }
        private void dfs2(int i)//второй поиск в глубину
        {
            used[i] = 1;
            comp.Add(i);//компонента связности
            for (int g = 0; g < n; g++)
            {
                if (used[g] == 0 && M[i, g] != 0)
                {
                    dfs2(g);
                }
            }

        }

        private void Kosar()
        {
            int c = 0;
            n = MatrixA.Rows.Count;
            used = new int[n];//массив вершин в которых уже побывали
            for (int i = 0; i < n; i++)
            {
                if (used[i] == 0)
                {
                    dfs1(i);
                }
            }
            string s = "";
            foreach (int i in v)
            {
                s += i.ToString() + "_";
            }
            textBox2.AppendText(s+"\n");
            for(int i = 0; i < n; i++)
                used[i] = 0;



            for (int i = n-1; i >= 0; i--)
            {

                if (used[v[i]] == 0)
                {
                    c++;
                    comp.Clear(); 
                    s = "comp " + c.ToString() + ":";                    
                    dfs2(v[i]);
                    foreach (int k in comp)
                    {
                        s +=  k.ToString() + " ";
                    }
                    textBox2.AppendText(s + "\n");
                }
            }
            v.Clear();
        }

       
       
    }
}
