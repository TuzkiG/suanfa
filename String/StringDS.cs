using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa.String
{
    /// <summary>
    /// 不止为何,对比书中的例子 自己写的更直观
    /// </summary>
    class StringDS
    {
        private char[] data;
        private int length;

        public int Length { get => data.Length; }

        public char this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public StringDS(char[] arr)
        {
            arr.CopyTo(data, arr.Length);
        }
        public StringDS(StringDS stringDS)
        {
            stringDS.data.CopyTo(data, stringDS.data.Length);
        }
        public StringDS(int len)
        {
            data = new char[len];
        }

        public int GetLength()
        {
            return data.Length;
        }
        /// <summary>
        /// 串比较  只需要比较长度 以及每个位置的字符是否一样
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Compare(StringDS s)
        {
            if (Length != s.Length)
                return false;
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (data[i] != s[i])
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取子串
        /// </summary>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public StringDS SubString(int index, int len)
        {
            if (index < 0 || index > Length - 1 || len < 0 || len > Length - index)
            {
                throw new Exception("pos or length is error");
            }
            StringDS stringDS = new StringDS(len);
            for (int i = 0; i < len; i++)
            {
                stringDS[i] = this[i + index];
            }
            return stringDS;
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        public StringDS Concat(StringDS str)
        {
            StringDS s1 = new StringDS(str.Length + this.Length);
            for (int i = 0; i < this.Length; i++)
                s1[i] = data[i];
            for (int i = 0; i < str.Length; i++)
                s1[i + this.Length] = str[i];

            return s1;
        }

        /// <summary>
        /// 在某个位置插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public StringDS Insert(int index, StringDS str)
        {
            if (index < 0 || index > Length)
                throw new Exception("pos is error");

            StringDS s1 = new StringDS(this.Length + str.Length);
            for (int i = 0; i < index; i++)
                s1[i] = this[i];
            for (int i = index; i < index + str.Length; i++)
                s1[i] = str[i - index];
            for (int i = index + str.Length; i < str.Length + this.Length; i++)
                s1[i] = this[i - str.Length];
            return s1;
        }
        /// <summary>
        /// 删除子串
        /// </summary>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns>删除后的新串</returns>
        public StringDS Delect(int index, int len)
        {
            if (index < 0 || index > this.Length || len < 0 || len + index > this.Length)
                throw new Exception("length or index is error");
            StringDS s1 = new StringDS(this.Length - len);
            for (int i = 0; i < index; i++)
                s1[i] = this[i];
            for (int i = index + len; i < this.Length; i++)
                s1[i] = this[i];
            return s1;
        }

        /// <summary>
        /// 定位串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int Index(StringDS str)
        {
            if (str.Length > this.Length || str.Length <= 0)
                throw new Exception("str is error");

            int index = 0;
            bool isCompare = true;
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == str[0])
                {
                    isCompare = true;
                    for (int j = 1; j < str.Length; j++)
                    {
                        if (this[i + j] != str[j])
                        {
                            isCompare = false;
                            break;
                        }
                    }
                    if (isCompare)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }


        public static void Test()
        {
            StringDS stringDS = new StringDS(new char[] { '0', '2' });
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(stringDS[i]);
            }
        }

    }
}
