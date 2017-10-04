/*
  ������������ ������ �2

  ������� ������ ��������
  ������ 25-��
  ������� 19
  ������: ������ ��������� ���������(����� ���������� � ��� ������������, ��������� �� ����. � ������.)
  � ���: ��������������� ������(��������� �� ������ � �����)
  �������:
  �� ������ ������� ������������� � ������������ ������ 1(������ ��������� ��������� �������� � ����������. ������)
  ����������� ���������� ���������, ��������� ��������� ���������� ������� QMessagebox.


*/
#include "mainwindow.h"
#include "ui_mainwindow.h"

//�������� �������
class Message//����� ��������� �������
{
private:
    QString text, user;//����� ���������, ��� ������������
    Message *prev;//��������� �� ����. ���������
    Message *next;//��������� �� ����. ���������
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
    QString get_text() const;//��������� ������ ���������
    QString get_user() const;//��������� ����� ������������
    bool set_text(QString str);//�������� �������� ������ ���������
    bool set_user(QString str);//��������� �������� ��� ������������
};



class doubleList//����� ��������������� ������
{
private:
    Message *Head;//��������� �� ������
    Message *Tail;//��������� �� �����
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
    bool addMess(QString str, QString str2);//���������� � ������
    bool addHead(QString str, QString str2);//���������� � ������

    bool delMess(int n);//�������� ��������� �� �����
    int get_size() const;//��������� ���-�� ��������� ������
    Message getMess(int n) const;//��������� ���������

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
        if(Head == NULL)//���� ������ ����
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
        size++;//���������� ���-�� ��������� �������
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
        if(Head == NULL)//���� ������ ����
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
        size++;//���������� ���-�� ��������� � ������
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
        for(int i = 0; i < n-1; i++)//���������� n �������� ������
        {
            mes = mes->next;
        }
        if (n == 1)//���� ��� ������ �������
        {
            if(mes->next == NULL)//���� ������������ �������
                Head = NULL;
            else
            {
                Head = mes->next;
                Head->prev = NULL;
            }
        }
        else
        {
            if(size == n)//���� ��������� �������
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
        size--;//���������� �� ���� ���-�� ��������� � ������
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


void MainWindow::on_button_add_clicked()//�������� ��� ������� ������ "��������"
{
    QString s, s2;
    s = ui->line_mess->text();
    s2 = ui->line_user->text();
    if (s == "" || s2 == "" || s.length() > 50 || s2.length() > 50)//�������� �� ����������� �������� �����
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

void MainWindow::on_button_clear_clicked()//������� ��� ������� ������ "�������� ����"
{
    ui->textBrowser->clear();
}

void MainWindow::on_button_addhead_clicked()//�������� ��� ������� ������ "�������� � ������"
{
    QString s, s2;//����������� �������
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

void MainWindow::on_button_view_clicked()//�������� ��� ������� ������ "�������� ������"
{
    QString s;//������ ��������� � textBrowser
    Message mes;
    int n = Journal.get_size();
    if(n == 0)//���� ������ ����
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

void MainWindow::on_button_del_clicked()//�������� ��� ������� ������ "�������"
{
    int n = ui->spinBox->value();
    int l = Journal.get_size();
    if (l == 0)//���� ������ ����
    {
        QMessageBox::critical(0, "Delete", "List is empty");
    }
    else
    {
        if(n > l || n < 1)//���� ������� �� ������� ������
        {
            QString s;
            s = "Delelte num must be > 0 and <= ";
            s += QString::number(l);
            QMessageBox::critical(0, "Delete", s);
        }
        else//�������� ���������
        {
            Journal.delMess(n);
            if(l - 1 != 0)
                on_button_view_clicked();//����� ������
            else
                ui->textBrowser->append("List is empty");
        }
    }
}


/*
  �����:
  � ���� ���������� ������ ������������ ������, � ������������� � �������� ������������
  �������� ������������ ���������� ���������� (SpinBox, lineEdit, pushButton � TextBrowser)
  ��� ����� � ������� ��������� ���������������� ������,
  ��� �� ��� �����������  QMessagebox, � ������� �������� ����� ����� �������� ������ � �������������.

 */
