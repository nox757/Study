/*
  Чибисов Андрей Павлович
  группа 25-АП
  Вариант 19
  Храним: Журнал системных сообщений(текст сообщения, указатель на след. и превед.)
  В чем: Двунаправленный список(указатель на голову и хвост)

*/


#include <iostream>
#include <string>

using namespace std;

//описание классов
class Message//класс сообщения журнала
{
private:
    string text, user;//текст сообщения
    Message *prev;
    Message *next;
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
    string get_text() const;//получение текста сообщения
    string get_user() const;
    void set_text(string str);
    void set_user(string str);
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
    void addMess(string str, string str2);//добавление в список
    void addHead(string str, string str2);//добавлнеие в начало

    bool delMess(int n);//удаление сообщения из списк
    int get_size() const;
    Message getMess(int n) const;

};


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


void Message::set_text(string s)
{

    text = s;

}
void Message::set_user(string s)
{
    user = s;
}

string Message::get_text() const
{
    return text;
}

string Message::get_user() const
{
    return user;
}

void doubleList::addMess(string str, string str2)
{
    Message *mes = new Message;
    mes->set_text(str);
    mes->set_user(str2);
    if(Head == NULL)
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
    size++;
}

void doubleList::addHead(string str, string str2)
{
    Message *mes = new Message;
    mes->set_text(str);
    mes->set_user(str2);
    if(Head == NULL)
    {
        Head = mes;

    }
    else
    {
        mes->next = Head;
        Head = mes;
    }
    size++;
}

bool doubleList::delMess(int n)
{
//    Message *mes = Head;
//    if(mes == NULL)
//        return false;
//    while(mes != NULL )
//    {
//        if(str == mes->get_text())
//        {
//            if(mes == Head)
//            {
//                if(mes->next == NULL)
//                    Head = NULL;
//                else
//                {
//                    Head = mes->next;
//                    Head->prev = NULL;
//                }
//            }
//            else
//                if(mes == Tail)
//                {
//                    Tail = mes->prev;
//                    Tail->next = NULL;
//                }
//                else
//                {
//                    mes->prev->next = mes->next;
//                    mes->next->prev = mes->prev;
//                }
//            delete mes;
//            size--;
//            return true;
//        }
//        mes = mes->next;
//    }
//    return false;
    Message *mes = Head;
    if(n > 0 && n <= size)
    {
        for(int i = 0; i < n-1; i++)
        {
            mes = mes->next;
        }
        if (n == 1 && n == size)
        {
            if(mes->next == NULL)
                Head = NULL;
            else
            {
                Head = mes->next;
                Head->prev = NULL;
            }
        }
        else
        {
            if(size == n)
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
        size--;
        return true;

    }
    else
        return false;
}



void prn_lst(const doubleList &p)
{
    int l = p.get_size();
    for(int i = 0; i < l; i++)
    {
        cout<<p.getMess(i+1).get_text();
        cout <<endl;
   }
}

int main()
{
    doubleList Journal;
    bool t;
    int choice, n;
    string str, str2;
    do
    {
        printf("\nMENU:\n"
                "0. Exit\n"
                "1. Add message (to tail)\n"
                "2. Add to head\n"
                "3. Del message\n"
                "4. Get message #num = \n"
                "Enter your choice: "
                );
        scanf("%i", &choice);
        switch(choice)
        {
        case 1:
        {

            do
            {
                cout << "Enter message(max.length = 255)" << endl;
                cin >> str >> str2;
            }while(str.length() > 256);

            Journal.addMess(str, str2);
            break;
        }
        case 2:
        {
            do
            {
                cout << "Enter message(max.length = 255)" << endl;
                cin >> str >>str2;
            }while(str.length() > 256);
            Journal.addHead(str, str2);
            break;
        }
        case 3:
        {
            do
            {
                cout << "Enter message(max.length = 255) that delete" << endl;
                cin >> n;
            }while(n > 256);
            t = Journal.delMess(n);
            if(t)
                cout << "Delete complete" << endl;
            else
                cout << "Message don't find" << endl;
            break;
        }
        case 4:
        {

            cout <<"Enter num of message ";
            cin >>n;
            cout<<endl;
            str = Journal.getMess(n).get_text();
            if(str != "")
            {
                cout<<str<<endl;
            }
            else
            {
                cout<<"no message #num = "<<n<<endl;
            }
        }
        }
        cout << endl;
        cout<<Journal.get_size()<<endl;
        prn_lst(Journal);
        if(Journal.get_size() == 2)
        {
            doubleList l(Journal);
            prn_lst(l);
        }

    }while(choice);

    return 0;
}



