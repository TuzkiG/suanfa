using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using suanfa.StackAndQueue;

namespace suanfa.Tree
{
    class BiTree<T>
    {
        /// <summary>
        /// 根节点
        /// </summary>
        private BiNode<T> root;

        public BiNode<T> Root { get => root; set => root = value; }


        public BiTree()
        {
            root = null;
        }

        public BiTree(T data)
        {
            BiNode<T> node = new BiNode<T>(data);
            root = node;
        }
        public BiTree(T data, BiNode<T> lp, BiNode<T> rp)
        {
            BiNode<T> node = new BiNode<T>(data, lp, rp);
            root = node;
        }
        /// <summary>
        /// 是否是空的二叉树
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return root == null;
        }
        /// <summary>
        /// 获取结点的左孩子
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static BiNode<T> GetLChild(BiNode<T> p)
        {
            if (p == null)
                throw new Exception("Node is null");
            return p.LChild;
        }
        /// <summary>
        /// 获取节点的右孩子
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static BiNode<T> GetRChild(BiNode<T> p)
        {
            if (p == null)
                throw new Exception("Node is null");
            return p.RChild;
        }

        /// <summary>
        /// 将节点p的左子树插入值为val的新结点,
        /// 原来的左子树成为新结点的左子树  p -> new node -> p.lchild
        /// </summary>
        /// <param name="val"></param>
        /// <param name="p"></param>
        public static void InsertL(T val, BiNode<T> p)
        {
            BiNode<T> tmp = new BiNode<T>(val);
            tmp.LChild = p.LChild;
            p.LChild = tmp;
        }
        /// <summary>
        /// 将节点p的右子树插入值为val的新结点,
        /// 原来的右子树成为新结点的右子树  p -> new node -> p.rchild
        /// </summary>
        /// <param name="val"></param>
        /// <param name="p"></param>
        public static void InsertR(T val, BiNode<T> p)
        {
            BiNode<T> tmp = new BiNode<T>(val);
            tmp.RChild = p.RChild;
            p.RChild = tmp;
        }

        /// <summary>
        /// 如果p非空,就删除p的左子树
        /// </summary>
        /// <param name="p"></param>
        public static BiNode<T> DelectL(BiNode<T> p)
        {
            if (p == null || p.LChild == null)
                throw new Exception("p is null");
            BiNode<T> lchild = p.LChild;
            p.LChild = null;

            return lchild;
        }
        /// <summary>
        /// 如果p非空,就删除p的右子树
        /// </summary>
        /// <param name="p"></param>
        public static BiNode<T> DelectR(BiNode<T> p)
        {
            if (p == null || p.RChild == null)
                throw new Exception("p is null");
            BiNode<T> rchild = p.RChild;
            p.RChild = null;

            return rchild;
        }

        /// <summary>
        /// 是否为叶子结点   左右子树都为null的就是叶子结点
        /// </summary>
        /// <returns></returns>
        public static bool IsLeaf(BiNode<T> p)
        {
            return p != null && p.LChild == null && p.RChild == null;
        }

        /// <summary>
        /// 先序(DLR)
        /// </summary>
        /// <param name="root"></param>
        public static void PreOrder(BiNode<T> root) {
            if (root == null)
                return;
            Console.WriteLine("{0}",root.Data);

            PreOrder(root.LChild);
            PreOrder(root.RChild);
        }

        /// <summary>
        /// 中序(LDR)
        /// </summary>
        public static void InOrder(BiNode<T> root)
        {
            if (root == null)
                return;
            InOrder(root.LChild);

            Console.WriteLine(root.Data);

            InOrder(root.RChild);
        }

        /// <summary>
        /// 后序遍历(LRD)
        /// </summary>
        /// <param name="root"></param>
        public static void PostOrder(BiNode<T> root)
        {
            if (root == null)
                return;

            PostOrder(root.LChild);
            PostOrder(root.RChild);
            Console.WriteLine(root.Data);
        }

        /// <summary>
        /// 层次遍历
        /// </summary>
        /// <param name="root"></param>
        public static void LevelOrder(BiNode<T> root)
        {
            if (root == null)
                throw new Exception("treen is empty") ;

            LinkQueue<BiNode<T>> linkQueue = new LinkQueue<BiNode<T>>();
            while (!linkQueue.IsEmpty())
            {
                BiNode<T> tmp = linkQueue.Out(); //先进先出  

                Console.WriteLine(tmp.Data);

                if (tmp.LChild != null)
                    linkQueue.In(tmp.LChild);
                if (tmp.RChild != null)
                    linkQueue.In(tmp.RChild);
            }
        }
    }
}
