#ifndef MESSAGE_H
#define MESSAGE_H
#include <Qstring>
#include <fstream>
#include <iostream>

using namespace std;

class Message//класс сообщения журнала
{
protected:
    QString text, user;//текст сообщения, имя пользователя
    Message *prev;//указатель на пред. сообщение
    Message *next;//указатель на след. сообщение
    template <class T> friend class doubleList;

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


    virtual QString outstr()
    {
        QString s;
        s = get_user()+" "+get_text();
        return s;

    }

    friend Message operator +(Message const &a,  Message const &b)
    {
        Message temp;
        temp.text = a.text + "/"+ b.text;
        temp.user = a.user+"/"+b.user;
        return temp;
    }
    Message & operator =(Message const &a)
    {
        if(this != &a)
        {
            user = a.user;
            text = a.text;
        }
        return *this;
    }


};

class NewMessage : public Message
{
private:
    int ID;
public:
    NewMessage() : Message()
    {
      ID = -1;
    };
    NewMessage(const NewMessage &a)
    {
        ID = a.get_ID();
    }

    ~NewMessage(){};

    int get_ID() const {return ID;};
    void set_ID(int n){ ID = n; };

    virtual QString outstr()
    {
        QString f;
        f = QString::number(ID)+" "+ user+" "+text;
        return f;
    }

    NewMessage & operator =(NewMessage const &a)
    {
        if(this != &a)
        {
            user = a.user;
            text = a.text;
            ID = a.ID;
        }
        return *this;
    }


    friend const NewMessage  operator +(NewMessage const &a,  NewMessage const &b)
    {
        NewMessage temp;

        temp.text = a.text+ "/"+ b.text;
        temp.user = a.user+"/"+b.user;
        temp.ID = a.ID+b.ID;
        return temp;
    }

    friend NewMessage operator +(Message const &a, NewMessage const &b)
    {
        NewMessage temp;
        temp.text = a.get_text()+ "/"+ b.text;
        temp.user = a.get_text()+"/"+b.text;
        temp.ID = b.ID;
        return temp;

    }
    friend NewMessage operator +(NewMessage const &a, Message const &b)
    {
        NewMessage temp;
        temp.text = a.text+ "/"+ b.get_text();
        temp.user = a.text+"/"+b.get_text();
        temp.ID = a.ID;
        return temp;
    }

};

#endif // MESSAGE_H
