using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa
{
    interface IListDS<T>
    {
        /// <summary>
        /// 获取长度
        /// </summary>
        /// <returns></returns>
        int getLength();
        /// <summary>
        /// 清除所有元素
        /// </summary>
        void Clear();
        /// <summary>
        /// 查看是否是空表
        /// </summary>
        bool IsEmpty();
       /// <summary>
       /// 在最后添加
       /// </summary>
       /// <param name="item">数据</param>
        void Append(T item);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item">数据</param>
        void Remove(T item);
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item">数据</param>
        /// <param name="pos">位置</param>
        void Insert(T item,int pos);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="i">位置</param>
        /// <returns>删除的数据</returns>
        T Delect(int i);
        /// <summary>
        /// 获取位置的数据
        /// </summary>
        /// <param name="i">位置</param>
        /// <returns>对应位置的数据</returns>
        T GetElem(int i);
        /// <summary>
        /// 查看当前数据在什么位置
        /// </summary>
        /// <param name="value">数据</param>
        /// <returns>位置</returns>
        int locate(T value);

        /// <summary>
        /// 倒置链表
        /// </summary>
        void Reverse();

        /// <summary>
        /// 是否包含
        /// </summary>
        /// <param name="item"></param>
        bool Contains(T item);

    }
}
