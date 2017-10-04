/*
  ������������ ������ �5

  ������� ������ ��������
  ������ 25-��
  ������� 19
  �������:
    ������������ ����� "��� ������" � �������������� ��������, ������������� � ������������
    typedef, ����������� ������� ������ ��� �������� ���� �������� �������.
  ������: ������ ��������� ���������(����� ���������� � ��� ������������, ��������� �� ����. � ������.)
  � ���: ��������������� ������(��������� �� ������ � �����)


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
        Message *mess = new Message;
        mess->set_text(s);
        mess->set_user(s2);
        Journal.addMess(mess);
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
        Message *mess = new Message;
        mess->set_text(s);
        mess->set_user(s2);
        Journal.addHead(mess);
        on_button_view_clicked();
        ui->line_mess->clear();
        ui->line_user->clear();
    }
}

void MainWindow::on_button_view_clicked()//�������� ��� ������� ������ "�������� ������"
{
    QString s, s0;//������ ��������� � textBrowser
    int n = Journal.get_size();
    if(n == 0)//���� ������ ����
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

void MainWindow::on_button_add_4_clicked()//�������� ��� ������� ������ �������� ��� NewMessage(tab2)
{
    QString s, s2;
    int id;
    id = ui->lineEdit->text().toInt();
    s = ui->line_mess_4->text();
    s2 = ui->line_user_4->text();
    if (s == "" || s2 == "" || s.length() > 50 || s2.length() > 50 || (ui->lineEdit->text() == "") )//�������� �� ����������� �������� �����
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

void MainWindow::on_button_addhead_4_clicked()//�������� � ������ ���2
{
    int id;
    QString s, s2;//����������� �������
    id = ui->lineEdit->text().toInt();
    s = ui->line_mess_4->text();
    s2 = ui->line_user_4->text();
    if (s == "" || s2 == "" || s.length() > 50 || s2.length() > 50 || (ui->lineEdit->text() == "") )//�������� �� ����������� �������� �����
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

void MainWindow::on_pushButton_clicked()//������  ������ ���������� �������� �������� ������
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
  �����:
  � ���� ���������� ������ ������������ ������, � ������������ c ��������������
  ������� ������ � � ���������� ���������.
  ��� �� ����������� � ����������� ������� ������ ��� �������� �������� �������(��������� �����)
  ��� ������� �������� �������� +.


 */





