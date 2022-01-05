using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfa.Tree
{
    /// <summary>
    /// 哈夫曼结点
    /// </summary>
    class HuffmanNode
    {
        /// <summary>
        /// 权重
        /// </summary>
        private int weight;
        /// <summary>
        /// 左孩子的索引
        /// </summary>
        private int lChild;
        /// <summary>
        /// 右孩子的索引
        /// </summary>
        private int rChild;
        /// <summary>
        /// 父节点的索引
        /// </summary>
        private int parent;

        public int Weight { get => weight; set => weight = value; }
        public int LChild { get => lChild; set => lChild = value; }
        public int RChild { get => rChild; set => rChild = value; }
        public int Parent { get => parent; set => parent = value; }

        public HuffmanNode()
        {
            weight = 0;
            lChild = -1;
            rChild = -1;
            parent = -1;
        }

        public HuffmanNode(int w,int lc,int rc,int p)
        {
            weight = w;
            lChild = lc;
            rChild = rc;
            parent = p;
        }
    }

    /// <summary>
    /// 哈夫曼树
    /// </summary>
    class HuffmanTree
    {
        /// <summary>
        /// 结点数组
        /// </summary>
        private HuffmanNode[] data;
        /// <summary>
        /// 叶子结点数目
        /// </summary>
        private int leafNum;
        public HuffmanNode this[int index]
        {
            get { return data[index]; }
        }
        public int LeafNum { get => leafNum; set => leafNum = value; }
        public HuffmanTree(int n)
        {
            data = new HuffmanNode[2 * n - 1];  //哈夫曼树的大小为2n - 1
            leafNum = n;
        }

        public HuffmanTree(int[] weighs)
        {
            int n = weighs.Length;
            data = new HuffmanNode[2 * n - 1];
            leafNum = n;
            Create(weighs);
        }
        /// <summary>
        /// 创建一个哈夫曼树
        /// </summary>
        /// <param name="weighs">权值数组</param>
        public void Create(int[] weighs)
        {
            //优化一下  先进行排序  
            //因为lc rc都记录了结点索引  所以还是需要遍历一遍  --先用快排排序
            //Array.Sort(weighs);
            int max1, max2, tmp1, tmp2;
            for (int i = 0; i < this.leafNum; i++)
                data[i] = new HuffmanNode(weighs[i],-1,-1,-1);

            //因为先用了排序 所以最小的两个结点为前两个
            for (int i = 0; i < this.leafNum - 1; i++)
            {
                max1 = max2 = int.MaxValue;
                tmp1 = tmp2 = 0;
                //寻找两个最小结点   最大最小堆?
                for (int j = 0; j < this.leafNum + i; j++)
                {
                    if (data[i].Weight < max1 && data[i].Parent == -1) {
                        max2 = max1;
                        tmp2 = tmp1;
                        tmp1 = j;
                        max1 = data[j].Weight;
                    }
                    else if (data[i].Weight < max2 && data[i].Parent == -1)
                    {
                        max2 = data[j].Weight;
                        tmp2 = j;
                    }
                }

                data[tmp1].Parent = this.leafNum + i; //往数组后面扩充
                HuffmanNode huffmanNode = data[this.leafNum + i]; //引用类型
                huffmanNode.Weight = data[tmp1].Weight + data[tmp2].Weight;
                huffmanNode.LChild = tmp1;
                huffmanNode.RChild = tmp2;
            }

        }

        public static void Test()
        {
            int[] huffmanWeighs = new int[] {5,9,8,3,2,1,6 };
            HuffmanTree huffmanTree = new HuffmanTree(huffmanWeighs);
        }
    }
}
