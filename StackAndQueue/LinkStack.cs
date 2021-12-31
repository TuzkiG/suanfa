using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using suanfa.List;

namespace suanfa.StackAndQueue
{
    class LinkStack<T> : IStack<T>
    {
        private LinkList<T>.Node top; //栈顶结点
        private int num;  //栈中节点的个数

        public LinkList<T>.Node Top { get => top; set => top = value; }
        public int Num { get => num; set => num = value; }

        public LinkStack()
        {
            top = null;
            num = 0;
        }
        public void Clear()
        {
            top = null;
            num = 0;
        }

        public int getLength()
        {
            return num;
        }

        public T GetTop()
        {
            return top.Data;
        }

        public bool isEmpty()
        {
            return top == null;
        }

        public T Pop()
        {
            if (isEmpty())
                throw new Exception("LinkStack is empty");

            T tmp = default(T);
            tmp = top.Data;
            top = top.Next;
            num--;
            return tmp;
        }

        public void Push(T item)
        {
            LinkList<T>.Node node = new LinkList<T>.Node(item);
            node.Next = top;
            top = node;
            num++;
        }

        public static void Conversion3_1(int num, em_System system)
        {
            LinkStack<int> s = new LinkStack<int>();
            while (num > 0)
            {
                s.Push(num % (int)system);
                num /= (int)system;
            }

            while (!s.isEmpty())
            {
                num = s.Pop();
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// 括号匹配。括号匹配问题也是计算机程序设计中常见的问题。为简化
        ///问题，假设表达式中只允许有两种括号：圆括号和方括号。嵌套的顺序是任意的，
        ///([]())或[()[()][]] 等都为正确的格式，而[(])或(([)])等都是不正确的格式。检验括号
        ///匹配的方法要用到栈
        /// </summary>
        /// <param name="charlist"></param>
        public static void MatchBracket3_3(char[] charlist)
        {
            SeqStack<char> seqStack = new SeqStack<char>(charlist.Length);
            seqStack.Push(charlist[0]);
            for (int i = 1; i < charlist.Length; i++)
            {
                char tmpChar = charlist[i];
                if (seqStack.GetTop() == '(' && tmpChar == ')')
                    seqStack.Pop();
                else if (seqStack.GetTop() == '[' && tmpChar == ']')
                    seqStack.Pop();
                else
                    seqStack.Push(tmpChar);
            }
            if(seqStack.isEmpty())
                Console.WriteLine("括号匹配完成");
            else
                Console.WriteLine("括号匹配失败");
        }

        public static void Test()
        {
            Conversion3_1(500, em_System.Binary);
            Console.WriteLine((1 & 2));
            MatchBracket3_3("(()()()()()()()()()[]))".ToCharArray());
        }
    }

    enum em_System
    {
        Binary = 2,
        Octonary = 8,
        Decimalism = 10,
        Hex = 16,
    }
}
