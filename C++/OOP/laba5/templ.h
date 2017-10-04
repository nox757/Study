#ifndef TEMPL_H
#define TEMPL_H

template <class T>class doubleList //шаблон класса двунаправленного списока
{
private:
    T *Head;//указатель на голову
    T *Tail;//указатель на хвост
    int size;
public:
    doubleList()
    {
        Head = NULL;
        Tail = NULL;
        size = 0;
    }
    doubleList(const doubleList &dlist)
    {
        int l = dlist.size;
        Head = NULL;
        Tail = NULL;

        for (int i = 0; i < l; i++)
        {
            this->addMess(dlist.getMess(i+1));
        }
        size = l;
    }
    ~doubleList()
    {
        while(Head != NULL)
        {
            T *t = Head->next;
            delete Head;
            Head = t;
        }
    }
    void addMess(T *mes);//добавление в список
    void addHead(T *mes);//добавлнеие в начало

    bool delMess(int n);//удаление сообщения из списк
    int get_size() const;//получение кол-ва элементов списка
    T* getMess(int n) const;//получение сообщения

};

template <class T>int doubleList<T>::get_size() const
{
    return size;
}



template <class T> T *doubleList<T>::getMess(int n) const
{
    if(n > 0 && n <= size)
    {
        T *mes = Head;

        for(int i = 0; i < n-1; i++)
        {
            mes = mes->next;
        }

        return mes;
    }
    else
    {

        return NULL;
    }
}



template <class T>void doubleList<T>::addMess(T *mes)
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

}



template <class T>void doubleList<T>::addHead(T *mes)
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
}


template <class T>bool doubleList<T>::delMess(int n)
{
    T *mes = Head;
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

#endif // TEMPL_H
