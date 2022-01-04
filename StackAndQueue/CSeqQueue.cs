using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa.StackAndQueue
{
    /// <summary>
    /// 循環順序隊列類
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class CSeqQueue<T> : IQueue<T>
    {
        /// <summary>
        /// 队头索引
        /// </summary>
        private int front;
        /// <summary>
        /// 队尾索引
        /// </summary>
        private int rear;
        private int maxSize;

        private T[] data;

        public int MaxSize { get => maxSize; set => maxSize = value; }
        public int Rear { get => rear; set => rear = value; }
        public int Front { get => front; set => front = value; }

        public T this[int index]
        {
            get { return data[index]; }
            set
            {
                data[index] = value;
            }
        }
        
        public CSeqQueue(int size)
        {
            MaxSize = size;
            data = new T[size];
            front = rear = -1;  //队头队尾都为-1
        }
        public void Clear()
        {
            front = rear = -1;
        }

        public T GetFront()
        {
            if (IsEmpty())
                throw new Exception("Queue is Empty");

            return data[front + 1];
        }

        public int GetLength()
        {
            return (rear - front + maxSize) % maxSize;
        }

        public void In(T item)
        {
            if (isFull())
                throw new Exception("Queue is full");

            data[++rear] = item;
            
        }

        public bool IsEmpty()
        {
            return rear == front;
        }

        public T Out()
        {
            T tmp = default(T);
            if(IsEmpty())
                throw new Exception("queue is empty");
            tmp = data[++front];

            return tmp;
        }

        public bool isFull()
        {
            return ((rear + 1) % maxSize == front);
        }
    }
}
