using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa.Tree
{
    /// <summary>
    /// 二叉链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BiNode<T>
    {
        private T data;
        private BiNode<T> rChild;
        private BiNode<T> lChild;

        public T Data { get => data; set => data = value; }
        internal BiNode<T> RChild { get => rChild; set => rChild = value; }
        internal BiNode<T> LChild { get => lChild; set => lChild = value; }

        public BiNode(T data, BiNode<T> lp, BiNode<T> rp)
        {
            this.data = data;
            rChild = rp;
            lChild = lp;
        }

        public BiNode(BiNode<T> lp, BiNode<T> rp) {
            this.data = default(T);
            rChild = rp;
            lChild = lp;
        }
        public BiNode(T data) {
            this.data = data;
            rChild = null;
            lChild = null;
        }
    }

    /// <summary>
    /// 双亲表示法,  
    /// 用数组保存Node   pPos指父节点在数组的位置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class PNode<T>
    {
        public T data;
        public int pPos;
    }
    /// <summary>
    /// 儿子兄弟表示法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class CSNode<T>
    {
        public T Data;
        public CSNode<T> FirstChild;    //儿子结点
        public CSNode<T> nextSibling;  //兄弟结点

    }
}
