using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_books
{
    class lb_Human
    {
        public int id_human;
        public string FIO;
        public string sex;
        public string passport;
        public string adress;
        public DateTime born;
        public string phone;
        public string role;

        public lb_Human()
        {
            id_human = 0;
            FIO = "";
            sex = "";
            passport = "";
            adress = "";
            born = DateTime.Now.AddYears(5);
            phone = "";
            role = "";
        }
    }
}
