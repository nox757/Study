/*
  Лабораторная работа №2

  Чибисов Андрей Павлович
  группа 25-АП
  Вариант 19
  Храним: Журнал системных сообщений(текст сообщенияб и имя пользователя, указатель на след. и превед.)
  В чем: Двунаправленный список(указатель на голову и хвост)
  Задания:
  На основе классов разработанных в лабораторной работе 1(журнал системных сообщений хранимый в двунаправл. списке)
  разработать визуальный интерфейс, используя несколько компонетов изучить QMessagebox.


*/
#include "mainwindow.h"
#include "ui_mainwindow.h"

//описание классов
class Message//класс сообщения журнала
{
private:
    QString text, user;//текст сообщения, имя пользователя
    Message *prev;//указатель на пред. сообщение
    Message *next;//указатель на след. сообщение
    friend class doubleList;

public:
    Message();
    Message(const Message &mes)
    {
        text = mes.text;
        user = mes.user;
        prev = NULL;
        next = NULL;
    }
    ~Message(){};
    QString get_text() const;//получение текста сообщения
    QString get_user() const;//получение имени пользователя
    bool set_text(QString str);//установа значения текста сообщения
    bool set_user(QString str);//установка значения имя пользователя
};



class doubleList//класс двунаправленный список
{
private:
    Message *Head;//указатель на голову
    Message *Tail;//указатель на хвост
    int size;
public:
    doubleList();
    doubleList(const doubleList &dlist)
    {
        int l = dlist.size;
        Head = NULL;
        Tail = NULL;

        for (int i = 0; i < l; i++)
        {
            this->addMess(dlist.getMess(i+1).get_text(),dlist.getMess(i+1).get_user());
        }
        size = l;
    };

    ~doubleList();
    bool addMess(QString str, QString str2);//добавление в список
    bool addHead(QString str, QString str2);//добавлнеие в начало

    bool delMess(int n);//удаление сообщения из списк
    int get_size() const;//получение кол-ва элементов списка
    Message getMess(int n) const;//получение сообщения

} Journal;


doubleList::doubleList()
{
    Head = NULL;
    Tail = NULL;
    size = 0;
}

doubleList::~doubleList()
{

    while(Head != NULL)
    {
        Message *t = Head->next;
        delete Head;
        Head = t;
    }
}

int doubleList::get_size() const
{
    return size;
}

Message doubleList::getMess(int n) const
{
    if(n > 0 && n <= size)
    {
        Message *mes = Head;
        for(int i = 0; i < n-1; i++)
        {
            mes = mes->next;
        }
        Message l(*mes);
        return l;
    }
    else
    {
        Message l;
        return l;
    }
}

Message::Message()
{
    text = "";
    user = "";
    prev = NULL;
    next = NULL;
}


bool Message::set_text(QString s)
{
    if (s == "" || s.length() > 50)
        return false;
    else
    {
        text = s;
        return true;
    }

}
bool Message::set_user(QString s)
{
    if (s == "" || s.length() > 50)
        return false;
    else
    {
        user = s;
        return true;
    }
}

QString Message::get_text() const
{
    return text;
}

QString Message::get_user() const
{
    return user;
}

bool doubleList::addMess(QString str, QString str2)
{
    Message *mes = new Message;
    if((mes->set_text(str)) && (mes->set_user(str2)))
    {
        if(Head == NULL)//если список пуст
        {
            Head = mes;
            Tail = mes;
        }
        else
        {
            Tail->next = mes;
            mes->prev = Tail;
            Tail = mes;
        }
        size++;//увелечение кол-ва элементов списков
        return true;
    }
    else
    {
        delete mes;
        return false;
    }
}

bool doubleList::addHead(QString str, QString str2)
{
    Message *mes = new Message;
    if((mes->set_text(str)) && (mes->set_user(str2)))
    {
        if(Head == NULL)//если список пуст
        {
            Head = mes;
            Tail = mes;

        }
        else
        {

            mes->next = Head;
            Head->prev = mes;
            Head = mes;

        }
        size++;//увелечение кол-ва элементов в списке
        return true;
    }
    else
    {
        delete mes;
        return false;
    }
}

bool doubleList::delMess(int n)
{
    Message *mes = Head;
    if(n > 0 && n <= size)
    {
        for(int i = 0; i < n-1; i++)//нахождение n элемента списка
        {
            mes = mes->next;
        }
        if (n == 1)//если это первый элемент
        {
            if(mes->next == NULL)//если единственный элемент
                Head = NULL;
            else
            {
                Head = mes->next;
                Head->prev = NULL;
            }
        }
        else
        {
            if(size == n)//если последний элемент
            {
                Tail = mes->prev;
                Tail->next = NULL;
            }
            else
            {
                mes->prev->next = mes->next;
                mes->next->prev = mes->prev;
            }
        }
        delete mes;
        size--;//уменьшение на один кол-ва элементов в списке
        return true;

    }
    else
        return false;
}



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
        Journal.addMess(s, s2);
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
        Journal.addHead(s, s2);
        on_button_view_clicked();
        ui->line_mess->clear();
        ui->line_user->clear();
    }
}

void MainWindow::on_button_view_clicked()//действия при нажатии кнопки "Показать список"
{
    QString s;//строка выводимая в textBrowser
    Message mes;
    int n = Journal.get_size();
    if(n == 0)//если список пуст
    {
        QMessageBox::critical(0, "Delete", "List is empty");
    }
    else
    {
        for (int i = 0; i < n; i++)
        {
            mes = Journal.getMess(i+1);
            s = QString::number(i+1);
            s += ". ";
            s += mes.get_user();
            s += "  ";
            s += mes.get_text();
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


/*
  Вывод:
  В ходе выполнения данной лабораторной работы, я познакомилься и научился использовать
  базовыми графическими элементами интерфейса (SpinBox, lineEdit, pushButton и TextBrowser)
  для ввода и ввывода элементов двунаправленного списка,
  так же был использован  QMessagebox, с помощью которого можно легко наладить диалог с пользователем.

 */
