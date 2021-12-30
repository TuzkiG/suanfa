using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa.List
{
    class LinkList<T> : IListDS<T>
    {
        public class Node
        {
            private T data;
            private Node next;

            public Node(T data, Node p)
            {
                this.data = data;
                next = p;
            }

            public Node(T data)
            {
                this.data = data;
                next = null;
            }

            public Node(Node next)
            {
                this.next = next;
            }

            public Node()
            {
                data = default(T);
                next = null;
            }

            public T Data
            {
                get
                { return data; }

                set
                { data = value; }
            }

            public Node Next
            {
                get
                { return next; }
                set
                { next = value; }
            }
        }

        private Node head;  //头结点
        private Node last;  //尾结点
        private int length; // 长度  单独记一个吧
        public Node Head { get => head; set => head = value; }

        public LinkList()
        {
            head = null;
            length = 0;
        }

        public void Append(T item)
        {
            Node p = new Node(item);
            if (head == null)   //如果是第一个结点 就需要复制给头尾结点
            {
                head = p;
                last = p;
            }
            last.Next = p;
        }

        public void Clear()
        {
            if (IsEmpty())
                return;
            //Node nowNode = null;
            //do
            //{
            //    nowNode = head.Next;
            //    head = null;
            //    head = nowNode;
            //} while (!head.Next.Equals(null));
            head = null;
        }

        public bool Contains(T item)
        {
            if (IsEmpty())
                return false;
            Node nowNode = head;
            do
            {
                if (nowNode.Data.Equals(item))
                    return true;
                else
                    nowNode = head.Next;
            } while (nowNode.Next != null);
            return false;
        }

        public T Delect(int i)
        {
            if (IsEmpty())
                return default(T);
            if (!indexIsValid(i))
                throw new Exception("index is error");
            Node nowNode = head;     //如果赋null的话  传出去也是null
            if (i == 0)   //头结点
                head = head.Next;
            else
            {
                int index = 0;
                Node tmpNode = head;
                do
                {
                    if (index == i - 1)   //当前索引就要删除  删除就吧指针引用到他的下一个
                    {
                        nowNode = tmpNode.Next;   //吧需要return的记录下来
                        tmpNode.Next = nowNode.Next;  //吧指针引用到删除node的下一个
                        if (tmpNode.Next == null)  //如果删除的是最后一个 就需要重新尾结点
                            last = tmpNode;
                        break;
                    }
                    tmpNode = tmpNode.Next;
                    index++;
                } while (tmpNode != null);
            }
            return nowNode.Data;
        }

        public T GetElem(int i)
        {
            if (IsEmpty())
                return default(T);
            if (!indexIsValid(i))
                throw new Exception("index is error");
            Node tmpNode = head;
            int index = 0;
            do
            {
                if (index == i)
                    return tmpNode.Data;
                tmpNode = tmpNode.Next;
                index++;
            } while (tmpNode != null);
            return default(T);
        }

        public int getLength()
        {
            return length;
        }

        public void Insert(T item, int pos)
        {
            if (IsEmpty())
                return;
            if (!indexIsValid(pos))  //在最后插入?
                throw new Exception("index is error");
            Node newNode = new Node(item);
            if (pos == 0)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }
            int index = 0;
            Node tmpNode = head;
            do
            {
                if (index == pos - 1)
                {
                    Node tmpNextNode = tmpNode.Next;  //获取当前结点的下一个结点
                    tmpNode.Next = newNode;            //吧当前结点的下一个结点转换为新结点
                    newNode.Next = tmpNextNode;         //新结点的下一个结点转换给当前结点的下一结点
                    if (newNode.Next == null)           //如果是最后一个结点  就需要重新设置
                        last = newNode;
                    break;
                }
                tmpNode = tmpNode.Next;
                index++;
            } while (tmpNode != null);
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public int locate(T value)
        {
            if (IsEmpty())
                return -1;
            Node tmpNode = head;
            int index = 0;
            do
            {
                if (tmpNode.Data.Equals(value))
                    return index;

                tmpNode = tmpNode.Next;
                index++;
            } while (tmpNode != null);
            return -1;
        }

        public void Remove(T item)
        {
            if (IsEmpty())
                return ;
            int index = locate(item);
            Delect(index);
        }

        public void Reverse()
        {




        }

        private bool indexIsValid(int i)
        {
            return i < 0 || i >= length;  //索引小于0就是不可用  大于等于长度也不可用
        }
    }
}
