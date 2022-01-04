using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa.StackAndQueue
{
    interface IQueue<T>
    {
        /// <summary>
        /// 获取长度
        /// </summary>
        /// <returns></returns>
        int GetLength();
        /// <summary>
        /// 是否是空队列
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
        /// <summary>
        /// 清除
        /// </summary>
        void Clear();
        /// <summary>
        /// 入队
        /// </summary>
        void In(T item);
        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        T Out();
        /// <summary>
        /// 获取队头
        /// </summary>
        /// <returns></returns>
        T GetFront();
    }
}
