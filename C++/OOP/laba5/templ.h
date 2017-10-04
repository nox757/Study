#ifndef TEMPL_H
#define TEMPL_H

template <class T>class doubleList //������ ������ ���������������� �������
{
private:
    T *Head;//��������� �� ������
    T *Tail;//��������� �� �����
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
    void addMess(T *mes);//���������� � ������
    void addHead(T *mes);//���������� � ������

    bool delMess(int n);//�������� ��������� �� �����
    int get_size() const;//��������� ���-�� ��������� ������
    T* getMess(int n) const;//��������� ���������

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

}



template <class T>void doubleList<T>::addHead(T *mes)
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
}


template <class T>bool doubleList<T>::delMess(int n)
{
    T *mes = Head;
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

#endif // TEMPL_H
