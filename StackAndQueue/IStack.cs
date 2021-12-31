using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa.StackAndQueue
{
    interface IStack<T>
    {
        /// <summary>
        /// 获取长度
        /// </summary>
        /// <returns></returns>
        int getLength();
        /// <summary>
        /// 是否为空栈
        /// </summary>
        /// <returns></returns>
        bool isEmpty();
        /// <summary>
        /// 清除
        /// </summary>
        void Clear();
        /// <summary>
        /// 入栈操作
        /// </summary>
        void Push(T item);
        /// <summary>
        /// 出栈操作
        /// </summary>
        /// <returns></returns>
        T Pop();
        /// <summary>
        /// 获取栈顶
        /// </summary>
        /// <returns></returns>
        T GetTop();
    }
}
