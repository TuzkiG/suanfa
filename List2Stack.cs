using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa
{
    class List2Stack
    {
        public Node Top = null;
        public int size = 0;
        public void push(Node node)
        {
            if (Top == null)
                Top = node;
            else
                node.Next = Top;
            Top = node;
            size++;
        }

        public Node pop()
        {
            //Top = Top.Next;
            Node popTop = Top;
            Top = Top.Next;
            size--;
            return popTop;
        }
    }

    class Node
    {
        public Node Next;
        public object data;
        public Node() { }

        public Node(object data)
        {
            this.data = data;
        }
    }

    class Midle2Last
    {
        public static void Change(string str)
        {
            //str = "1+2+3+(5+8)*9-2+10/5"
            //char[] equation = str.ToCharArray();
            StringBuilder sb = new StringBuilder();
            List2Stack operatorStack = new List2Stack();
            for (int i = 0; i < str.Length; i++)
            {
                char index = str[i];
                switch (index)
                {
                    case '+':
                    case '-':
                        while (true)
                        {
                            if (operatorStack.size == 0)
                                break;

                            char topChar = (char)(operatorStack.Top.data); //没有比+ -更低的运算符
                            if (topChar == '(')//括号特殊处理
                                break;
                            operatorStack.pop();
                            sb.Append(topChar);
                        }
                        operatorStack.push(new Node(index));
                        break;
                    case '/':
                    case '*':
                        operatorStack.push(new Node(index));
                        break;
                    case '(':
                        operatorStack.push(new Node(index));
                        break;
                    case ')':
                        do
                        {
                            Node node = operatorStack.pop();
                            if ((char)node.data == '(')
                                break;
                            sb.Append((char)node.data);

                        } while (true);

                        break;
                    default:
                        sb.Append(index);
                        break;
                }
            }
            do
            {
                sb.Append(operatorStack.pop().data);
            } while (operatorStack.size != 0);
            Console.WriteLine(sb.ToString());

        }

    }

    class LastCount
    {
        public static void Count(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {

            }
        }

    }

    class STLExercise
    {
        public static void exercise3_1(Node L,Node P)
        {
            //∵L 以及P为升序
            //∴不用循环去取值
            if (L == null || L.data == null)
                return;

            //int index = 0;
            Node Pptr = P;
            Node Lptr = L;
            int NowIndex = 0;
            int index = (int)Pptr.data;
            do
            {
                if (NowIndex == index)
                {
                    Pptr = Pptr.Next;
                    if (Pptr == null)
                        break;
                    index = (int)Pptr.data;
                    Console.WriteLine(Lptr.data);
                }
                Lptr = Lptr.Next;
                NowIndex++;
            } while (Lptr.Next != null);
        }
        public static void exercise3_6(int num) {
        
        }

    }

}
