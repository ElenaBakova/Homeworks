using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTree
{
    /// <summary>
    /// Tree wich contains key(string) and value(string)
    /// </summary>
    class BTree
    {
        int treeOrder;
        private Node root;

        class Node
        {
            public int countNodes;
            public string[] keys;
            public Node[] child;
            public bool isLeaf;

            public Node(int order)
            {
                keys = new string[2 * order];
                child = new Node[2 * order];
                isLeaf = true;
                countNodes = 0;
            }

            public int Find(string key)
            {
                for (int i = 0; i < countNodes; i++)
                {
                    if (keys[i] == key)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public BTree(int order)
        {
            treeOrder = order;
            root = new Node(order);
        }

        private Node FindValueByKey(Node root, string key)
        {
            if (root == null)
            {
                return root;
            }
            int i = 0;
            for (; i < root.countNodes; i++)
            {
                int comparingResult = String.Compare(key, root.keys[i]);
                if (comparingResult == -1)
                {
                    break;
                }
                if (comparingResult == 0)
                {
                    return root;
                }
            }
            if (root.isLeaf)
            {
                return null;
            }
            return FindValueByKey(root.child[i], key);
        }

        private void SplitNodes(Node first, Node second, int position)
        {
            var temp = new Node(treeOrder);
            temp.isLeaf = second.isLeaf;
            temp.countNodes = treeOrder - 1;
            for (int i = 0; i < treeOrder - 1; i++)
            {
                temp.keys[i] = second.keys[i + treeOrder];
            }
            if (!second.isLeaf)
            {
                for (int i = 0; i < treeOrder; i++)
                {
                    temp.child[i] = second.child[i + treeOrder];
                }
            }
            second.countNodes = treeOrder - 1;
            for (int i = root.countNodes; i >= position + 1; i--)
            {

            }
        }
    }
}
