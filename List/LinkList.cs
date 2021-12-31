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
            else
            {
                last.Next = p;
                last = p;
            }
            length++;
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
            last = null;
            length = 0;
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
                    nowNode = nowNode.Next;
            } while (nowNode!= null);
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
                        length--;
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
                return;
            int index = locate(item);
            Delect(index);
        }

        public void Reverse()
        {
            if (IsEmpty())
                return;
            //可以不创建新链表就可以反转
            Node tmpNode = head;
            Node nextNode = null;
            for (int i = 0; i < getLength() - 1; i++) //  1->2->3->4      其实就需要转换为 1<-2<-3<-4
            {
                if (nextNode != null)
                {
                    Node t = nextNode.Next;
                    nextNode.Next = tmpNode;
                    tmpNode = nextNode;
                    nextNode = t;
                }
                else
                if (tmpNode.Next != null)
                {
                    nextNode = tmpNode.Next.Next;
                    tmpNode.Next.Next = tmpNode;
                    tmpNode = tmpNode.Next;
                    head.Next = null;
                }
            }
            head = tmpNode;
        }

        private bool indexIsValid(int i)
        {
            return !(i < 0 || i >= length);  //索引小于0就是不可用  大于等于长度也不可用
        }
        /// <summary>
        /// 【例 2-5】有数据类型为整型的单链表 Ha 和 Hb，其数据元素均按从小到大的升
        ///序排列，编写一个算法将它们合并成一个表 Hc，要求 Hc 中结点的值也是升序排
        ///列
        /// </summary>
        /// <param name="Ha"></param>
        /// <param name="Hb"></param>
        public static LinkList<int> Merge2_5(LinkList<int> Ha, LinkList<int> Hb)
        {
            LinkList<int> Hc = new LinkList<int>();
            var HaNode = Ha.head;
            var HbNode = Hb.head;
            do
            {
                if (HaNode == null || HaNode.Data > HbNode.Data)
                {
                    Hc.Append(HbNode.Data);
                    if (HbNode != null)
                        HbNode = HbNode.Next;
                }
                else
                {
                    Hc.Append(HaNode.Data);
                    if (HaNode != null)
                        HaNode = HaNode.Next;
                }
            } while (HaNode != null || HbNode != null);
            return Hc;
        }

        public static LinkList<int> Purge2_6(LinkList<int> Ha)
        {
            LinkList<int> Hb = new LinkList<int>();
            var HaNode = Ha.head;
            do
            {
                if (!Hb.Contains(HaNode.Data))
                    Hb.Append(HaNode.Data);
                HaNode = HaNode.Next;
            } while (HaNode != null);
            return Hb;
        }

        public static void Test()
        {
            LinkList<int> linkList = new LinkList<int>();
            for (int i = 0; i < 5; i++)
                linkList.Append(i);
            linkList.Reverse();
            for (int i = 0; i < linkList.getLength(); i++)
                Console.WriteLine(linkList.GetElem(i));


            LinkList<int> Ha = new LinkList<int>();
            LinkList<int> Hb = new LinkList<int>();
            for (int i = 0; i < 5; i++)
                Ha.Append(i);
            for (int i = 4; i < 10; i++)
                Hb.Append(i);
            LinkList<int> Hc = Merge2_5(Ha, Hb);
            for (int i = 0; i < Hc.length; i++)
                Console.WriteLine("Merge2_5:{0}", Hc.GetElem(i));
            LinkList<int> Hd = new LinkList<int>();
            for (int i = 1; i < 10; i++)
                Hd.Append(i/2);
            LinkList<int> Hf = Purge2_6(Hd);
            for (int i = 0; i < Hf.length; i++)
                Console.WriteLine("Purge2_6:{0}", Hf.GetElem(i));
        }
    }
}
