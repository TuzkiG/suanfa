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
            return t;
        }

        public T GetElem(int i)
        {
            if (i > data.Length)
                throw new Exception("索引超过最大数组");
            else
                return data[i];
        }

        public int getLength()
        {
            return mLast;   //因为是返回List长度  而不是创建的数组长度
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
                    {
                        data[i + 1] = data[i];
                    }

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

        }
        public bool isFull()
        {
            return mLast == maxsize - 1;
        }

        private bool indexIsValid(int index)
        {
            return !(index < 0 || index > mLast + 2);
        }
    }
}
