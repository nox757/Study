using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Collections;

namespace my_books
{
   
    

    public partial class Form1 : Form
    {
        DateTime t_start, t_end;
        double t_total = 0;
        Random rnd;

        //объявление нужных структур модели
        Que que2;
        Cartoteka kart2;
        Librarian libr1, libr2, libr_out;
        Depot hra;
        
        //списки результатов
        List<Request> done = new List<Request>();//список всех сделанных заявок        
        List<Request> deny = new List<Request>();//список отколонненых заявок???????добавить метод добавления
        List<int> done_g = new List<int>();//список взявших заявок

        //реализация структур с книгами
        Dictionary<int, lb_Human> People = new Dictionary<int, lb_Human>();//фактически это база с людьми ключ ид человека
        Dictionary<int, lb_Book> Books = new Dictionary<int, lb_Book>(); //фактически это хранилище ключ ид книги
       
        Dictionary<int, lb_Abonement> Abon = new Dictionary<int, lb_Abonement>();//ключ это ид человека
        
        List<lb_Cart> Kartoteka = new List<lb_Cart>();//картотека поиск будет осуществляться 
        

        string home = "Библиотека "; //состояние системы
        string state = "Выключена";

        public Form1()
        {
            InitializeComponent();

            textBox_diagn.Enabled = false;
            textBox_diagn.Hide();

            check_Abon.Enabled = false;
            check_Book.Enabled = false;
            check_Cart.Enabled = false;
            check_Peop.Enabled = false;

            //инициализация нужных моделей и их взаимосвязь
            que2 = new Que(1);
            que2.t_que.Interval = 50;

            kart2 = new Cartoteka(1, que2, 3,Kartoteka);
            kart2.t_que.Interval = 3000;
            kart2.rnd_f = 7000;
            kart2.rnd_l = 7000;

            libr1 = new Librarian(1, que2, kart2,Books, Abon);
            libr1.rnd_f = 1500;
            libr1.rnd_l = 3000;

            libr2 = new Librarian(2, que2, kart2,Books, Abon);
            libr2.rnd_f = 1000;
            libr2.rnd_l = 2000;

            hra = new Depot(1,Books);
            hra.t_que.Interval = 1500;
            hra.rnd_f = 3000;
            hra.rnd_l = 3000;

            libr_out = new Librarian(3, hra, Books, Abon);
            libr_out.rnd_f = 1000;
            libr_out.rnd_l = 1000;  
           
            

            //соединение объектов событиями
                
            que2.notEmpty += kart2.getRequest;
            que2.notEmpty += libr1.getReq_fromQue;
            que2.notEmpty += libr2.getReq_fromQue;

            kart2.notEmpty += libr1.getReq_fromCart;
            kart2.notEmpty += libr2.getReq_fromCart;
            kart2.giveReq += this.deny_Add;

            libr1.giveReq += hra.Add;
            libr2.giveReq += hra.Add;

            libr1.giveReq += this.done_Add;
            libr2.giveReq += this.done_Add;
            libr1.giveReq += this.deny_Add;
            libr2.giveReq += this.deny_Add;

            hra.notEmpty += libr_out.getReq_fromDepot;

            libr_out.giveReq += this.done_Add;
            libr_out.giveReq += this.deny_Add;


            //запуск настроенных таймеров
           
            que2.t_que.Stop();
            kart2.t_que.Stop();
            hra.t_que.Stop();
            timer_new.Stop();

            //настройка кнопок
            button_finish.Enabled = false;
            button_off.Enabled = false;
            button_start.Enabled = false;
            button_Reset.Enabled = false;

            rnd = new Random();
            this.Text = home +  state;

        }

   

        /// <summary>
        /// добавление в очередь готовых
        /// </summary>
        /// <param name="req"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool done_Add(Request req, Librarian sender)
        {
            if (req.type == "Que_done")
            {
                req.state = sender.old_req_state;
                done.Add(req);
                sender.state = "Empty";
                sender.t_delay.Stop();
                if (req.state == "Get_book")
                {
                    done_g.Add(done.Count() - 1);
                }

                return true;
            }
            else
            {
               return false;
            }
                
        }

        private bool deny_Add(Request req, Librarian sender)
        {
            if (req.type == "Que_no")
            {
                req.state = sender.old_req_state;
                deny.Add(req);
                sender.state = "Empty";
                sender.t_delay.Stop();
                return true;
            }
            else
                return false;
        }
        private bool deny_Add(Request req)
        {
            if (req.type == "Que_no")
            {                
                deny.Add(req);
                return true;
            }
            else
                return false;
        }

        int id_req = 0;
        /// <summary>
        /// функция генерации заявок в системе
        /// </summary>
        void Generation_Req(string where)
        {
            Request req = new Request(id_req++, "");
            int i = 0;
            if (where == "")
            {
                i = rnd.Next(1, 1);
            }
            switch (i)
            {
                case 0: 
                    req.type = where;
                    break;
                case 1:
                    req.Generation_info_get(Abon, Books);
                    break;
                case 2:
                    req.type = "Libr";
                    break;
            }
            que2.Add(req);
        }



        //функиция  на выключение системы
        private void IsFinish()
        {
            if (que2.state == "Empty" && kart2.state == "Empty" &&
                libr1.state == "Empty" && libr2.state == "Empty" &&
                hra.state == "Empty" && libr_out.state == "Empty" &&
                button_off.Enabled == false)
            {
                timer_new.Stop();                
                state = "Выключена";
                this.Text = home + state;
                button_on.Enabled = true;
            }
        }
        /// <summary>
        /// обновленный вывод текущей ситуации системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_new_Tick(object sender, EventArgs e)
        {
            IsFinish();
            othcet();
            textBox_que2.Clear();
           
            for (int i = 0; i < que2.curr_len; i++)
                textBox_que2.AppendText(que2.Catalog[i].id.ToString() + " " + que2.Catalog[i].t_que.ToString() + " " + que2.Catalog[i].t_work.ToString() 
                    + que2.Catalog[i].state + que2.Catalog[i].type + "\n");
            
            textBox_kart2.Clear();
            
            for (int i = 0; i < kart2.curr_len; i++)
                textBox_kart2.AppendText(kart2.Catalog[i].id.ToString() + " " + kart2.Catalog[i].t_que.ToString() + " " + kart2.Catalog[i].t_work.ToString() 
                     + kart2.Catalog[i].state + kart2.Catalog[i].type + "\n");
            
            textBox_done.Clear();
            for (int i = 0; i < done.Count(); i++)
                textBox_done.AppendText(done[i].id.ToString() + " " + done[i].t_que.ToString() + " " + done[i].t_work.ToString()
                     +done[i].state + done[i].type + "\n");

            textBox_deny.Clear();
            for (int i = 0; i < deny.Count(); i++)
                textBox_deny.AppendText(deny[i].id.ToString() + " " + deny[i].t_que.ToString() + " " + deny[i].t_work.ToString()
                     + deny[i].state + deny[i].type + "\n");
           
            textBox_hra.Clear();
           
            for (int i = 0; i < hra.curr_len; i++)
                textBox_hra.AppendText(hra.Catalog[i].id.ToString() + " " + hra.Catalog[i].t_que.ToString() + " " + hra.Catalog[i].t_work.ToString()
                     + hra.Catalog[i].state + hra.Catalog[i].type + "\n");
            
            textBox_libr1.Clear();
            if (libr1.state != "Empty" && libr1.curr_req != null)
            {
                textBox_libr1.Text = (libr1.curr_req.id.ToString() + " " + libr1.curr_req.t_que.ToString() + " " + libr1.curr_req.t_work.ToString());
                
            }
            
            textBox_libr2.Clear();
            if (libr2.state != "Empty" && libr2.curr_req != null)
            {
                textBox_libr2.Text = (libr2.curr_req.id.ToString() + " " + libr2.curr_req.t_que.ToString() + " " + libr2.curr_req.t_work.ToString());
               
            }
            
            textBox_libr_out.Clear();
            if (libr_out.state != "Empty" && libr_out.curr_req != null)
            {
                textBox_libr_out.Text = (libr_out.curr_req.id.ToString() + " " + libr_out.curr_req.t_que.ToString() + " " + libr_out.curr_req.t_work.ToString());
                
            }
        }

   


        private void timer_gen_Tick(object sender, EventArgs e)
        {
            Generation_Req("");
        }
        /// <summary>
        /// пуск заявок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_start_Click(object sender, EventArgs e)
        {
               timer_gen.Start();
               button_finish.Enabled = true;
               button_start.Enabled = false;

               state = "Заявки подаются";
               this.Text = home + state;
        }
        /// <summary>
        /// стоп пуска заявок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_finish_Click(object sender, EventArgs e)
        {
            t_end = DateTime.Now;
            t_total = (t_end - t_start).TotalSeconds;
            timer_gen.Stop();
            button_finish.Enabled = false;
            button_start.Enabled = true;
            state = "Заявки не подаются";
            this.Text = home + state;

        }
        /// <summary>
        /// вкл. систему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_on_Click(object sender, EventArgs e)
        {
            button_Reset.Enabled = true;
            que2.t_que.Start();
            kart2.t_que.Start();
            hra.t_que.Start();
            t_start = DateTime.Now;

            timer_new.Start();
            button_start.Enabled = true;
            button_off.Enabled = true;
            button_on.Enabled = false;


            state = "Включена";
            this.Text = home + state;

        }
        /// <summary>
        /// выкл. систему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_off_Click(object sender, EventArgs e)
        {
            button_finish_Click(this, e);
            button_start.Enabled = false;
            state =  "Выключается";
            this.Text = home + state;
            button_off.Enabled = false;

        }




        //подключение библиотек с файлами

        private void init_fileDia()
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory= AppDomain.CurrentDomain.BaseDirectory;
           
        }

        private void books_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            init_fileDia();
            openFileDialog1.Title = "Select a File with Books";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Read_Book(openFileDialog1.FileName))
                {
                    check_Book.Checked = true;
                }
                else
                {
                   
                        MessageBox.Show("Плохой файл!", "Err");
                    
                }

                
            }                
           
        }

        private void Abon_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            init_fileDia();
            openFileDialog1.Title = "Select a File with Abonements";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (check_Book.Checked && check_Peop.Checked)
                {
                    if (Read_Abon(openFileDialog1.FileName))
                    {

                        check_Abon.Checked = true;

                    }
                    else
                    {
                        MessageBox.Show("Плохой файл!", "Err");
                    }
                }
                else
                {
                    MessageBox.Show("Сперва подлючи Книги и Людей", "Err");
                    Abon.Clear();
                }
            }
        }

        private void people_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            init_fileDia();
            openFileDialog1.Title = "Select a File with People";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Read_People(openFileDialog1.FileName))
                {
                    check_Peop.Checked = true;
                }
                else
                {

                    MessageBox.Show("Плохой файл!", "Err");

                }

            }
        }

        private void kart_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            init_fileDia();
            openFileDialog1.Title = "Select a File with Kartoteka";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (check_Book.Checked)
                {
                    if (Read_Cart(openFileDialog1.FileName))
                    {

                        check_Cart.Checked = true;

                    }
                    else
                    {
                        MessageBox.Show("Плохой файл!", "Err");
                    }
                }
                else
                {
                    MessageBox.Show("Сперва подлючи Книги", "Err");
                    Abon.Clear();
                }
            }
        }

        //правила считывания 
        private bool Read_Book(string path_f)
        {    

            StreamReader fs = new StreamReader(path_f, System.Text.Encoding.Default);
            string[] temp;
            bool flag = false;
            while (!fs.EndOfStream)
            {
                if (fs.Peek() != -1)
                {
                    temp = fs.ReadLine().Trim().ToLower().Split(';');
                    if (temp.Length == 7)
                    {
                        if (temp[0] == "#kniga")
                        {
                            lb_Book lb_b = new lb_Book();
                            temp[2] = temp[2].Trim();//year
                            temp[3] = temp[3].Trim();//stranic
                            temp[4] = temp[4].Trim();//name
                            temp[5] = temp[5].Trim();//authurs
                            temp[6] = temp[6].Trim();//state                           
                            DateTime t_b = DateTime.Now.AddYears(5);
                            if ((temp[4] != "" || temp[5] != "") &&
                                (temp[6] == "0" || temp[6] == "1") 
                               )
                            {
                                int id = -2, year = 0, stra = 0;
                                if (int.TryParse(temp[1], out id))
                                {
                                    if (int.TryParse(temp[3], out stra))
                                    {
                                        if(temp[2].Length == 4 && int.TryParse(temp[2], out year))
                                        {
                                            if (DateTime.TryParse("01 " + temp[2], out t_b))
                                            {
                                                flag = true;
                                                lb_b.id_shifr = id;
                                                lb_b.kol_page = stra;
                                                lb_b.year = year;
                                                lb_b.name_book = temp[4];
                                                lb_b.authors = temp[5];
                                                lb_b.status = (temp[6] == "1")? (true) : (false);
                                                Books.Add(id, lb_b);
                                            }
                                        }
                                    }
                                  
                                }
                            }
                        }

                    }
                }
                else
                {
                    break;
                }
            }
            fs.Close();
            if (flag)
                return true;
            else
                return false;
        }

        private bool Read_Cart(string path_f)
        {
            StreamReader fs = new StreamReader(path_f, System.Text.Encoding.Default);
            string[] temp ;
            bool flag = false;
            while (!fs.EndOfStream)
            {
                if (fs.Peek() != -1)
                {
                    temp = fs.ReadLine().Trim().ToLower().Split(';');
                    if (temp.Length == 4)
                    {
                        if (temp[0] == "#cart")
                        {
                            lb_Cart lb_c = new lb_Cart();
                            temp[2] = temp[2].Trim();
                            temp[3] = temp[3].Trim();
                            if (temp[2] != "" && temp[3] != "")
                            {
                                int g = -2;
                                if (int.TryParse(temp[1], out g))
                                {
                                    if (Books.ContainsKey(g))
                                    {
                                        if(Books[g].name_book == temp[2])//!!!!организовать грамматную проверку авторов
                                            if (Books[g].authors == temp[3])
                                            {
                                                flag = true;
                                                lb_c.id_shifr = g;
                                                lb_c.name_book_cart = temp[2];
                                                lb_c.authors = temp[3];
                                                Kartoteka.Add(lb_c);
                                            }
                                    }
                                }
                            }
                        }
                        
                    }

                }
                else
                {
                    break;
                }
            }
            fs.Close();
            if (flag)
                return true;
            else
                return false;
        }

        private bool Read_People(string path_f)
        {
            StreamReader fs = new StreamReader(path_f, System.Text.Encoding.Default);
            string[] temp;
            bool flag = false;
            while (!fs.EndOfStream)
            {
                if (fs.Peek() != -1)
                {
                    temp = fs.ReadLine().Trim().ToLower().Split(';');
                    if (temp.Length == 9)
                    {
                        if (temp[0] == "#human")
                        {
                            lb_Human lb_h = new lb_Human();
                            temp[2] = temp[2].Trim();//fio
                            temp[3] = temp[3].Trim();//sex
                            temp[4] = temp[4].Trim();//passport
                            temp[5] = temp[5].Trim();//adress
                            temp[6] = temp[6].Trim();//born
                            temp[7] = temp[7].Trim();//phone
                            temp[8] = temp[8].Trim();//role
                            DateTime t_b = DateTime.Now.AddYears(5);
                            if ((temp[8] == "libr" || temp[8] == "reader") &&
                                (temp[7].All(p => p >= '0' && p <= '9')) &&
                                DateTime.TryParse(temp[6], out t_b) && t_b < DateTime.Now &&
                                temp[5] != "" && (temp[4].All(p => p >= '0' && p <= '9')) &&
                                (temp[3] != "м" || temp[3] != "ж") && temp[2] != "")
                            {
                                int g = -2;
                                if (int.TryParse(temp[1], out g))
                                {
                                    flag = true;
                                    lb_h.id_human = g;
                                    lb_h.FIO = temp[2];
                                    lb_h.sex = temp[3];
                                    lb_h.passport = temp[4];
                                    lb_h.adress = temp[5];
                                    lb_h.born = t_b;
                                    lb_h.phone = temp[7];
                                    lb_h.role = temp[8];
                                    People.Add(lb_h.id_human, lb_h);
                                }
                            }
                        }

                    }
                }
                else
                {
                    break;
                }
            }
            fs.Close();
            if (flag)
                return true;
            else
                return false;
        }

        private bool Read_Abon(string path_f)
        {
            StreamReader fs = new StreamReader(path_f, System.Text.Encoding.Default);
            string[] temp;
            bool flag = false;
            while (!fs.EndOfStream)
            {
                if (fs.Peek() != -1)
                {
                    temp = fs.ReadLine().Trim().ToLower().Split(';');
                    if (temp.Length >= 6)
                    {
                        if (temp[0] == "#abon")
                        {
                            int id, dolg;
                            double dolg_d;
                            lb_Abonement lb_a = new lb_Abonement();
                            temp[1] = temp[1].Trim();//id 
                            temp[2] = temp[2].Trim();//debt
                            temp[3] = temp[3].Trim();//id_abon
                            temp[4] = temp[4].Trim();//dolg b
                            temp[5] = temp[5].Trim();//dolg d
                            DateTime t_b = DateTime.Now.AddYears(5);
                            if (int.TryParse(temp[1], out id) &&
                                temp[2] != "" &&
                                int.TryParse(temp[4], out dolg) &&
                                double.TryParse(temp[5], out dolg_d) &&
                                dolg_d >= 0
                                )                                
                              
                            {
                                int g = -2;
                                if (int.TryParse(temp[3], out g))
                                {
                                    if (People.ContainsKey(g))
                                    {
                                        flag = true;
                                        lb_a.id_human = g;
                                        lb_a.id = id;
                                        if (dolg_d == 0)
                                            lb_a.dolg = false;
                                        else
                                            lb_a.dolg = true;
                                        lb_a.size_dolg = dolg_d;
                                        if (temp.Length >  6)
                                        {                                          
                                            int len = temp.Length;
                                            for (int i = 6; i < len; i++)
                                            {
                                                string[] temp_b = new string[4];
                                                temp_b = temp[i].Split(new char[] {'|'}, 4);
                                                g = -2;
                                                if(int.TryParse(temp_b[0], out g))
                                                {
                                                    if (Books.ContainsKey(g))
                                                    {
                                                        //уже в конструкторе lb_a.books = new List<Tuple<int, string[]>>();
                                                        lb_a.books.Add(new Tuple<int, string[]>(g, new string[3]));
                                                        for (int j = 1; j < 4; j++)
                                                        {
                                                            DateTime t_d = DateTime.Now.AddYears(-200);
                                                            if (DateTime.TryParse(temp_b[j], out t_d))
                                                            {
                                                                lb_a.books[lb_a.books.Count - 1].Item2[j - 1] = temp_b[j];
                                                            }
                                                            else
                                                            {
                                                                if (j == 3 && temp_b[3] == "")
                                                                {
                                                                    lb_a.books[lb_a.books.Count - 1].Item2[j - 1] = "";
                                                                }
                                                                else
                                                                {
                                                                    lb_a.books[lb_a.books.Count - 1].Item2[j - 1] = t_b.ToString();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                               
                                            }
                                        }
                                        Abon.Add(lb_a.id_human, lb_a);
                                        flag = true;
                                    }
                                }
                            }
                        }

                    }

                }
                else
                {
                    break;
                }
            }
            fs.Close();
            if (flag)
            {
                return true;
            }
            else
                return false;
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = AppDomain.CurrentDomain.BaseDirectory;
            if(Read_Book(s + "\\Knigi.txt") &&
            Read_Cart(s + "\\Carts.txt") &&
            Read_People(s + "\\Human.txt") &&
            Read_Abon(s + "\\Abon.txt") )

          
            {
                check_Abon.Checked = true;
                check_Book.Checked = true;
                check_Cart.Checked = true;
                check_Peop.Checked = true;
            }
        }
        ////\конец подключение библиотек
    

        private void Res_All()
        {
            que2.t_que.Stop();
            kart2.t_que.Stop();
            hra.t_que.Stop();
            timer_gen.Stop();
            timer_new.Stop();

            textBox_que2.Clear();
            textBox_deny.Clear();
            textBox_diagn.Clear();
            textBox_done.Clear();
            textBox_hra.Clear();
            textBox_libr_out.Clear();
            textBox_libr1.Clear();
            textBox_libr2.Clear();
            textBox_kart2.Clear();
            textBox_otchet.Clear();

            button_finish.Enabled = false;
            button_off.Enabled = false;
            button_start.Enabled = false;
            button_Reset.Enabled = false;
            button_on.Enabled = true;
            
            this.done = new List<Request>();
            this.deny = new List<Request>();
            this.done_g = new List<int>();
            this.Text = home;

            check_Abon.Checked = false;
            check_Book.Checked = false;
            check_Cart.Checked = false;
            check_Peop.Checked = false;

            //реализация структур с книгами
             People = new Dictionary<int, lb_Human>();//фактически это база с людьми ключ ид человека
            Books = new Dictionary<int, lb_Book>(); //фактически это хранилище ключ ид книги

             Abon = new Dictionary<int, lb_Abonement>();//ключ это ид человека

             Kartoteka = new List<lb_Cart>();//картотека поиск будет осуществляться 
             t_total = 0;
             id_req = 0;

        }

        private void othcet()
        {
            textBox_otchet.Clear();
            textBox_otchet.AppendText("Время работы системы: " + (DateTime.Now - t_start).TotalSeconds.ToString("N2") + "c \n");
            textBox_otchet.AppendText( "Количество заявок, поступивших в систему: " + que2.num.ToString() + "\n");
            textBox_otchet.AppendText ("Количество заявок, прошедших через картотеку: " + kart2.num.ToString() + "\n");
            textBox_otchet.AppendText("Количество заявок, прошедших через хранилище: " + hra.num.ToString() + "\n");
            int r = 0;
            double t_q = 0, t_w = 0;
            if ( done.Count != 0)
            {
               
               for (int i = 0; i < done.Count; i++)
               {
                   r++;
                   t_q += done[i].t_que;
                   t_w += done[i].t_work;
               }
            }
            if (deny.Count != 0)
            {

                for (int i = 0; i < deny.Count; i++)
                {
                    r++;
                    t_q += deny[i].t_que;
                    t_w += deny[i].t_work;
                }

            }
            textBox_otchet.AppendText("Среднее время нахождения заявки в очереди: " + ((t_q/1000)/r).ToString("N2") + " c\n");
            textBox_otchet.AppendText("Среднее время нахождения заявки в системе: " + ((t_w / 1000) / r).ToString("N2") + " c\n");
                
           textBox_otchet.AppendText( "Количество отказанных заявок: " + deny.Count + "\n");
        }

        private void button_Res_Click(object sender, EventArgs e)
        {
            Res_All();
        }
      
    }
}
