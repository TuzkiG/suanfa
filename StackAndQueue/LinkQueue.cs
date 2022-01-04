using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using suanfa.List;


namespace suanfa.StackAndQueue
{
    class LinkQueue<T> : IQueue<T>
    {
        private LinkList<T>.Node front;//头
        private LinkList<T>.Node rear;//尾
        private int num;

        internal LinkList<T>.Node Front { get => front; set => front = value; }
        internal LinkList<T>.Node Rear { get => rear; set => rear = value; }
        public int Num { get => num; set => num = value; }

        public LinkQueue()
        {
            Front = Rear = null;
            Num = 0;
        }
        public void Clear()
        {
            Front = Rear = null;
            Num = 0;
        }

        public T GetFront()
        {
            return Front.Data;
        }

        public int GetLength()
        {
            return Num;
        }
        /// <summary>
        /// 遵循先进先出原则,但存入顺序不同
        /// </summary>
        /// <param name="item"></param>
        public void In(T item)
        {
            //当前队列没有数据的时候  第一个入队的就是队头
            LinkList<T>.Node node = new LinkList<T>.Node(item);

            if (Front == null)
                Front = node;
            else
            {
                Front.Next = node;
                Front = node;
            }
            if (Rear == null)
                Rear = node;
            Num++;
        }

        public bool IsEmpty()
        {
            return (Front == Rear && Num == 0);
        }

        public T Out()
        {
            if (IsEmpty())
                throw new Exception("Queue is Empty");
            T tmp = default(T);
            tmp = Rear.Data;
            Rear = Rear.Next;
            return tmp;
        }

        public static void Test()
        {
            LinkQueue<int> csq1 = new LinkQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                csq1.In(i);
            }
            for (int i = 0; i < csq1.GetLength(); i++)
                Console.WriteLine(csq1.Out());

            huiwen3_4("AABCAA");
        }

        /// <summary>
        /// 判断当前字符是否是回文
        /// 书中是一个堆栈 + 队列比较
        /// </summary>
        /// <param name="str"></param>
        public static void huiwen3_4(string str)
        {
            LinkQueue<char> q = new LinkQueue<char>();
            LinkStack<char> s = new LinkStack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                char tmp = str[i];
                q.In(tmp);
                s.Push(tmp);
            }

            while (!q.IsEmpty() && !s.isEmpty())
            {
                if (q.Out() != s.Pop())
                {
                    Console.WriteLine("不是回文");
                    return;
                }
            }
            Console.WriteLine("是回文");

        }
    }
}
