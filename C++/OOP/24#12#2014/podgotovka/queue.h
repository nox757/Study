#ifndef QUEUE_H
#define QUEUE_H


//template <class Type>
//class QueueItem {
//public:
//   // ...
//private:

//   Type item;
//   QueueItem *next;
//};

// объявление QueueItem

template <class Type>
class QueueItem {
public:
   QueueItem( const Type & );
private:
   Type item;
   QueueItem *next;
};

template <class Type>
class Queue {
public:
   Queue() : front( 0 ), back ( 0 ) { }
   ~Queue();

   Type& remove();
   void add( const Type & );
   bool is_empty() const {
      return front == 0;
   }
private:
   QueueItem<Type> *front;
   QueueItem<Type> *back;
};



class Queue
{
public:
    Queue();
};

#endif // QUEUE_H
