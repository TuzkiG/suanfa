using System;

namespace suanfa
{
    class Program
    {
        /// <summary>
        /// http://gnetna.com/books/%E6%95%B0%E6%8D%AE%E7%BB%93%E6%9E%84%E4%B8%8E%E7%AE%97%E6%B3%95Data%20Structures%20and%20Algorithms%EF%BC%88%E4%B8%AD%E6%96%87%E7%89%88%EF%BC%89.pdf
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Midle2Last.Change("1+(2+3)*4+5+10+50");
            //Node p = new Node(1);
            //Node topP = p;
            //for (int i = 2; i <= 10; i++)
            //{
            //    p.Next = new Node(i);
            //    p = p.Next;
            //}

            //Node l = new Node(10);
            //Node topL = l;
            //Random random = new Random();
            //for (int i = 0; i < 99; i++)
            //{
            //    l.Next = new Node(random.Next(0,6999));
            //    l = l.Next;
            //}

            //STLExercise.exercise3_1(topL, topP);

            int hashVal = HashCS.HashFunc("s233232ssspppp",8);
            Console.WriteLine(hashVal);
        }
    }
}
