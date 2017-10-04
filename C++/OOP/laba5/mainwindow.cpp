/*
  Лабораторная работа №5

  Чибисов Андрей Павлович
  группа 25-АП
  Вариант 19
  Задание:
    переработать класс "где храним" с использованием шаблонов, познокомиться и использовать
    typedef, разработать функцию шаблон для сложения двух объектов классов.
  Храним: Журнал системных сообщений(текст сообщенияб и имя пользователя, указатель на след. и превед.)
  В чем: Двунаправленный список(указатель на голову и хвост)


*/
#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "templ.h"
#include "Message.h"

typedef doubleList<Message> Hranenie;

Hranenie Journal;


MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{

    ui->setupUi(this);


}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_button_add_clicked()//действия при нажатии кнопки "Добавить"
{
    QString s, s2;
    s = ui->line_mess->text();
    s2 = ui->line_user->text();
    if (s == "" || s2 == "" || s.length() > 50 || s2.length() > 50)//проверка на коррекность введеных строк
    {
       QMessageBox::critical(0, "Information", "Enter both line (Max 50 symb)");
    }
    else
    {
        Message *mess = new Message;
        mess->set_text(s);
        mess->set_user(s2);
        Journal.addMess(mess);
        on_button_view_clicked();
        ui->line_mess->clear();
        ui->line_user->clear();
    }

}

void MainWindow::on_button_clear_clicked()//дейсвия при нажатии кнопки "Очистить окно"
{
    ui->textBrowser->clear();
}

void MainWindow::on_button_addhead_clicked()//действия при нажатии кнопки "Добавить в начало"
{
    QString s, s2;//считываемые функции
    s = ui->line_mess->text();
    s2 = ui->line_user->text();
    if (s == "" || s2 == "" || s.length() > 50 || s2.length() > 50)
    {
       QMessageBox::critical(0, "Information", "Enter both line (Max 50 symb)");
    }
    else
    {
        Message *mess = new Message;
        mess->set_text(s);
        mess->set_user(s2);
        Journal.addHead(mess);
        on_button_view_clicked();
        ui->line_mess->clear();
        ui->line_user->clear();
    }
}

void MainWindow::on_button_view_clicked()//действия при нажатии кнопки "Показать список"
{
    QString s, s0;//строка выводимая в textBrowser
    int n = Journal.get_size();
    if(n == 0)//если список пуст
    {
        QMessageBox::critical(0, "Delete", "List is empty");
    }
    else
    {
        for (int i = 0; i < n; i++)
        {

            s = QString::number(i+1);
            s += ". ";
            s += Journal.getMess(i+1)->outstr();


            ui->textBrowser->append(s);
        }
        ui->textBrowser->append("");
    }
}

void MainWindow::on_button_del_clicked()//действия при нажатии кнопки "Удалить"
{
    int n = ui->spinBox->value();
    int l = Journal.get_size();
    if (l == 0)//если список пуст
    {
        QMessageBox::critical(0, "Delete", "List is empty");
    }
    else
    {
        if(n > l || n < 1)//если выходит за размеры списка
        {
            QString s;
            s = "Delelte num must be > 0 and <= ";
            s += QString::number(l);
            QMessageBox::critical(0, "Delete", s);
        }
        else//удаление сообщения
        {
            Journal.delMess(n);
            if(l - 1 != 0)
                on_button_view_clicked();//вывод списка
            else
                ui->textBrowser->append("List is empty");
        }
    }
}

void MainWindow::on_button_add_4_clicked()//действия при нажатии кнопки добавить для NewMessage(tab2)
{
    QString s, s2;
    int id;
    id = ui->lineEdit->text().toInt();
    s = ui->line_mess_4->text();
    s2 = ui->line_user_4->text();
    if (s == "" || s2 == "" || s.length() > 50 || s2.length() > 50 || (ui->lineEdit->text() == "") )//проверка на коррекность введеных строк
    {
       QMessageBox::critical(0, "Information", "Enter all line (Max 50 symb)");
    }
    else
    {
        NewMessage *mess = new NewMessage;
        mess->set_text(s);
        mess->set_user(s2);
        mess->set_ID(id);
        Journal.addMess(mess);
        on_button_view_clicked();
        ui->line_mess_4->clear();
        ui->line_user_4->clear();
        ui->lineEdit->clear();
    }

}

void MainWindow::on_button_addhead_4_clicked()//добавить в начало таб2
{
    int id;
    QString s, s2;//считываемые функции
    id = ui->lineEdit->text().toInt();
    s = ui->line_mess_4->text();
    s2 = ui->line_user_4->text();
    if (s == "" || s2 == "" || s.length() > 50 || s2.length() > 50 || (ui->lineEdit->text() == "") )//проверка на коррекность введеных строк
    {
       QMessageBox::critical(0, "Information", "Enter all line (Max 50 symb)");
    }
    else
    {
        NewMessage *mess = new NewMessage;
        mess->set_text(s);
        mess->set_user(s2);
        mess->set_ID(id);
        Journal.addHead(mess);
        on_button_view_clicked();
        ui->line_mess_4->clear();
        ui->line_user_4->clear();
        ui->lineEdit->clear();
    }

}

void MainWindow::on_pushButton_clicked()//кнопка  показа результата сложения объектов класса
{
    NewMessage nmes ;
    nmes.set_ID(223);
    nmes.set_text("new_m");
    nmes.set_user("pasha");
    Message mes;
    mes.set_text("old_m");
    mes.set_user("oleg");
    Message k;
    k = summa(mes,mes);
    ui->textBrowser->append("-----------------------------");
    ui->textBrowser->append(mes.outstr());
    ui->textBrowser->append(nmes.outstr());
    ui->textBrowser->append(k.outstr());
    ui->textBrowser->append("-----------------------------");
}



/*
  Вывод:
  В ходе выполнения данной лабораторной работы, я ознакомилься c использованием
  шаблона класса и с шаблонными функциями.
  Так же ознакомился и использовал функцию шаблон для сложения объектов классов(различных типов)
  для которых объявлен оператор +.


 */





