using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using suanfa.List;

namespace suanfa.StackAndQueue
{
    class SeqStack<T> : IStack<T>
    {
        /// <summary>
        /// 最大数量
        /// </summary>
        private int maxsize;
        /// <summary>
        /// 数据
        /// </summary>
        private T[] data;
        /// <summary>
        /// 栈顶索引
        /// </summary>
        private int top;

        public int Maxsize { get => maxsize; }
        //public int Top { get => top; set => top = value; }

        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        public SeqStack(int size)
        {
            data = new T[size];
            maxsize = size;
            top = -1;
        }
        public void Clear()
        {
            top = -1;
        }

        public int getLength()
        {
            return top + 1;
        }

        public T GetTop()
        {
            if (isEmpty())
                return default(T);

            return data[top];
        }

        public bool isEmpty()
        {
            return top == -1;
        }
        public bool isFull()
        {
            return top == maxsize - 1;
        }
        public T Pop()
        {
            T tmp = default(T);
            if (isEmpty())
                throw new Exception("Stack is empty");
            tmp = data[top--];
            return tmp;
        }

        public void Push(T item)
        {
            if (isFull())
                throw new Exception("Stack is full");
            data[++top] = item;
        }
    }
}
