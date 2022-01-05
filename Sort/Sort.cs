using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using suanfa.List;
namespace suanfa.Sort
{
    class Sort
    {
        /// <summary>
        /// 插入排序   效率在O(n) - O(n^2)
        /// </summary>
        /// <param name="sqList"></param>
        public static void InsertSort(SeqList<int> sqList)
        {
            for (int i = 1; i < sqList.getLength(); i++)
            {
                //说明是无序的
                if (sqList[i - 1] > sqList[i])
                {
                    int tmp = sqList[i];
                    int j = 0;
                    for (j = i; j >= 0 && tmp < sqList[j]; j--)
                    {
                        sqList[j + 1] = sqList[j];
                    }
                    sqList[j + 1] = tmp;
                }
            }

        }
        /// <summary>
        /// 冒泡排序是 O(n^2)
        /// </summary>
        /// <param name="sqList"></param>
        public static void BubbleSort(SeqList<int> sqList)
        {
            int tmp;
            for (int i = 0; i < sqList.getLength(); i++)
            {
                for (int j = sqList.getLength() - 1; j >= i; j--)
                {
                    if (sqList[j + 1] < sqList[j])
                    {
                        tmp = sqList[j + 1];
                        sqList[j + 1] = sqList[j];
                        sqList[j] = tmp;
                    }
                }
            }
        }
        /// <summary>
        /// 简单选择排序   O(n^2)
        /// </summary>
        public static void SimpleSelectSort(SeqList<int> sqList)
        {
            int min = 0;
            int t = 0;
            for (int i = 0; i < sqList.getLength(); i++)
            {
                t = i;
                for (int j = i + 1; j <= sqList.getLength(); j++)
                {
                    //比较最小的
                    if (sqList[t] > sqList[j])
                    {
                        t = j;
                    }
                }
                min = sqList[i];
                sqList[i] = sqList[t];
                sqList[t] = min;
            }
        }
        /// <summary>
        /// 快速排序  最优O(logn)  最快 O(n^2)  //不稳定
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void QuickSort(SeqList<int> sqList, int low, int high)
        {
            int i = low;
            int j = high;
            int tmp = sqList[low];   //取第一个为支点
            while (low < high)
            {
                //从高位与支点位比较
                while (low < high && sqList[high] >= tmp)
                {
                    --high;
                }
                sqList[low] = sqList[high];
                ++low;//因为支点位取的是第一个
                //低位比较
                while (low < high && sqList[low] <= tmp)
                {
                    ++low;
                }
                sqList[high] = sqList[low];
                --high;
            }
            sqList[low] = tmp;
            if (i < low - 1)
                QuickSort(sqList, i, low - 1);
            if (low + 1 < j)
                QuickSort(sqList, low + 1, j);
        }

        /// <summary>
        /// 创建最大最小堆
        /// </summary>
        /// <param name="seqList"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void CreateHeap(SeqList<int> seqList, int low, int high)
        {
            if (low < high && high <= seqList.getLength())
            {
                int j = 0, tmp = 0, k = 0;
                //从中间开始 往前
                for (int i = high / 2; i >= low; i--)
                {
                    k = i;
                    j = 2 * k + 1;
                    tmp = seqList[i];

                    while (j <= high)
                    {
                        if (j < high && j + 1 <= high && seqList[j] < seqList[j + 1])
                        {
                            ++j;
                        }
                        if (tmp < seqList[j])
                        {
                            seqList[k] = seqList[j];
                            k = j;
                            j = 2 * k + 1;
                        }
                        else
                            j = high + 1;
                        seqList[k] = tmp;
                    }
                }
            }
        }

        /// <summary>
        /// 堆排序  O(logN)
        /// </summary>
        /// <param name="seqList"></param>
        public static void HeapSort(SeqList<int> seqList)
        {
            int tmp = 0;
            CreateHeap(seqList, 0, seqList.mLast);
            for (int i = seqList.mLast; i > 0; i--)
            {
                tmp = seqList[0];
                seqList[0] = seqList[i];
                seqList[i] = tmp;

                CreateHeap(seqList, 0, i - 1);
            }

        }

        public static void Test()
        {
            SeqList<int> seqList = new SeqList<int>(10);
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                seqList.Append(random.Next(50));
            }
            QuickSort(seqList, 0, seqList.getLength() - 1);
        }
    }
}
