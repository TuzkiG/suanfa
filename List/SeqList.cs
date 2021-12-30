using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa.List
{
    class SeqList<T> : IListDS<T>
    {
        private int maxsize;  //数组最大容量
        private T[] data;   //数组
        public int mLast { private set; get; }   //数组最后一个元素的位置

        public int MaxSize
        {
            get { return maxsize; }
            set { maxsize = value; }
        }
        public T this[int index]
        {
            get
            {
                return GetElem(index);
            }

            set
            {
                Insert(value, index);
            }
        }


        public SeqList(int size)
        {
            data = new T[size];
            maxsize = size;
            mLast = -1;
        }

        public void Append(T item)
        {
            if (isFull())
                throw new Exception("List is full");
            else
                data[++mLast] = item;
        }

        public void Clear()
        {
            mLast = -1;
        }

        public T Delect(int i)
        {
            T t = default(T);

            if (IsEmpty())
                throw new Exception("list is empty");

            if (!indexIsValid(i))
                throw new Exception("index not valid");

            if (i == mLast)
                t = data[mLast];   //最后一个的话就直接return出去
            else
            {
                t = data[i];
                for (int j = i + 1; j <= mLast; j++)
                    data[j - 1] = data[j];
            }

            --mLast;
            return t;
        }

        public T GetElem(int i)
        {
            if (!indexIsValid(i))
                throw new Exception("索引超过最大数组");
            else
                return data[i];
        }

        public int getLength()
        {
            return mLast + 1;   //因为是返回List长度  而不是创建的数组长度
        }

        public void Insert(T item, int pos)
        {
            if (indexIsValid(pos) && !isFull())
            {
                if (pos == mLast + 2)
                    data[mLast + 1] = item;
                else
                {
                    for (int i = mLast; i >= pos - 1; i--)   //插入的话 需要吧当前索引之后的数据往后挪动
                        data[i + 1] = data[i];
                    data[pos - 1] = item;
                }
                ++mLast;
            }
        }

        public bool IsEmpty()
        {
            return mLast == -1;
        }

        public int locate(T value)
        {
            int mlocate = 0;

            return mlocate;
        }

        public void Remove(T item)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Equals(item))
                {
                    Delect(i);
                    return;
                }
            }
        }
        public bool isFull()
        {
            return mLast == maxsize - 1;
        }

        public bool Contains(T items)
        {
            for (int i = 0; i < data.Length; i++)
                if (items.Equals(data[i]))
                    return true;
            return false;
        }

        private bool indexIsValid(int index)
        {
            return !(index < 0 || index > mLast + 2);
        }

        

        public void Reverse()
        {
            if (IsEmpty())
                throw new Exception("List is Null");
            T tmp = default(T);
            int length = getLength();
            for (int i = 0; i < getLength() / 2; i++)    // 5 / 2  = 2  向下取整
            {
                tmp = data[i];
                data[i] = data[length - i - 1];     //需要多 - 1
                data[length - i - 1] = tmp;
            }
        }

        /// <summary>
        /// 例2-2中  条件: list均为从小到大的顺序排列
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static SeqList<int> Merge2_2(SeqList<int> list1,SeqList<int> list2)
        {
            if (list1.IsEmpty() || list2.IsEmpty())
                throw new Exception("param is empty");
            //list1.length = M   list2.length = N   从头遍历的话会很多    那就从尾调用
            SeqList<int> list = new SeqList<int>(list1.getLength() + list2.getLength());
            //从尾到头加入
            do
            {
                if (list1[list1.mLast] > list2[list2.mLast])
                {
                    list.Append(list1[list1.mLast]);
                    list1.Delect(list1.mLast);
                }
                else
                {
                    list.Append(list2[list2.mLast]);
                    list2.Delect(list2.mLast);
                }
            } while (!list1.IsEmpty()&&!list2.IsEmpty());
            list.Reverse();   //翻转一下   时间复杂度就为O(m*n)
            return list;
        }

        /// <summary>
        /// 例2-3
        /// </summary>
        /// <param name="La"></param>
        /// <returns></returns>
        public static SeqList<int> Purge2_3(SeqList<int> La)
        {
            if (La.IsEmpty())
                throw new Exception("La is Empty");

            SeqList<int> Lb = new SeqList<int>(La.MaxSize);
            for (int i = 0; i < La.getLength(); i++)  
            {
                if (!Lb.Contains(La[i]))
                    Lb.Append(La[i]);
            }
            return Lb;
        }

        public static void Test()
        {
            SeqList<int> test1 = new SeqList<int>(10);
            for (int i = 0; i < test1.MaxSize; i++)
                test1.Append(i/2);// 1 / 2 = 0 2 / 2= 1 3 / 2 = 1
            for (int i = 0; i < test1.getLength(); i++)
                Console.WriteLine("Test1[0]:{0}", test1[i]);
            var test2 =  Purge2_3(test1);
            for (int i = 0; i < test2.getLength(); i++)
                Console.WriteLine(test2[i]);
        }
    }
}
