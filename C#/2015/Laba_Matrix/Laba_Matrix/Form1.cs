using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Laba_Matrix
{
    public partial class Form1 : Form
    {

        private DataTable MatrixA = null,
                          MatrixB = null,
                          MatrixC = null;

        public Form1()
        {
            InitializeComponent();
            //запрет удаления и добавления строк
            dataGridView1.AllowUserToAddRows = false; dataGridView1.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToAddRows = false; dataGridView2.AllowUserToDeleteRows = false;
            dataGridView3.AllowUserToAddRows = false; dataGridView3.AllowUserToDeleteRows = false;
            //инициализация данных
            MatrixA = new DataTable();
            MatrixB = new DataTable();
            MatrixC = new DataTable();
            dataGridView1.DataSource = MatrixA;
            dataGridView2.DataSource = MatrixB;
            dataGridView3.DataSource = MatrixC;
            textBox1.Text = "1";
            ChangeSizes();

            MessageBox.Show("Можно заполнять только нижний треугол. матрицы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void button_size_Click(object sender, EventArgs e)
        {
            ChangeSizes();
        }
        /// <summary>
        /// изменение размеров матриц по кнопке
        /// </summary>
        private void ChangeSizes()
        {
            int n;
            bool res = true;
            res = Prosto.CheckInt(textBox1.Text,out n);
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
                    SetMatrixSize(MatrixB, dataGridView2, n);
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
                    dt.Columns.Add(new DataColumn(/*"Column 1"*/(i + 1).ToString(), typeof(string)));
                    dgv.Columns[i].Width = 35;  // задание ширины для отображения (поэтому DataGridView)
                    // DataTable только хранит данные, а ширина столбца - на уровне отображения

                    // Также здесь нужно проверить случай добавления столбцов при неизменном
                    // количестве строк, чтобы новые столбцы заполнить нулями
                    for ( j = 0; j < dt.Rows.Count; j++)
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
        /// <summary>
        /// Деланье симметричной матрицы
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="n"></param>
        public void SetView(ref DataTable dt, int n)
        {
            for(int i = 0; i < n; i++)
                for (int j = 0; j < i; j++)
                {
                    dt.Rows[j][i] = dt.Rows[i][j];
                }
        }
        private void button_plus_Click(object sender, EventArgs e)
        {
            Matrica A = new Matrica();
            Matrica B = new Matrica();
            Matrica C = new Matrica();
            SetMatrixSize(MatrixC, dataGridView3, MatrixA.Rows.Count);
            if (!(A.FromDataTable(MatrixA, MatrixA.Rows.Count) &&
                 B.FromDataTable(MatrixB, MatrixB.Rows.Count)))
            {
                MessageBox.Show("Проверьте корректность", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SetView(ref MatrixA, MatrixA.Rows.Count);
                SetView(ref MatrixB, MatrixB.Rows.Count);
                C = (A + B);
                if (!C.ToDataTable(ref MatrixC, MatrixA.Rows.Count))
                    MessageBox.Show("Проверьте корректность", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

       
        
    }
}
