using System;

namespace BTree
{
    /// <summary>
    /// Tree wich contains key(string) and value(string)
    /// </summary>
    class BTree
    {
        readonly int treeOrder;
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

            public int FindInNode(string key)
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
                int comparingResult = string.Compare(key, root.keys[i]);
                if (comparingResult == -1)
                {
                    break;
                }
                if (comparingResult == 0)
                {
                    return root;
                }
            }
            return root.isLeaf ? null : FindValueByKey(root.child[i], key);
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
            for (int i = first.countNodes; i >= position + 1; i--)
            {
                first.child[i + 1] = first.child[i];
            }
            first.child[position + 1] = temp;
            for (int i = first.countNodes - 1; i >= position; i--)
            {
                first.keys[i + 1] = first.keys[i];
            }
            first.keys[position] = second.keys[treeOrder - 1];
            first.countNodes++;
        }

        public void Insert(string key)
        {
            Node tempRoot = root;
            if (tempRoot.countNodes == 2 * treeOrder - 1)
            {
                Node newNode = new Node(treeOrder);
                root = newNode;
                newNode.isLeaf = false;
                newNode.countNodes = 0;
                newNode.child[0] = tempRoot;
                SplitNodes(newNode, tempRoot, 0);
                insertValue(newNode, key);
            }
            else
            {
                insertValue(tempRoot, key);
            }
        }

        private void insertValue(Node x, string k)
        {
            if (x.isLeaf)
            {
                int i = 0;
                for (i = x.countNodes - 1; i >= 0 && k < x.keys[i]; i--)
                {
                    x.keys[i + 1] = x.keys[i];
                }
                x.keys[i + 1] = k;
                x.countNodes = x.countNodes + 1;
            }
            else
            {
                int i = 0;
                for (i = x.countNodes - 1; i >= 0 && k < x.keys[i]; i--)
                {
                }
                i++;
                Node tmp = x.child[i];
                if (tmp.countNodes == 2 * treeOrder - 1)
                {
                    SplitNodes(x, tmp, i);
                    if (k > x.keys[i])
                    {
                        i++;
                    }
                }
                insertValue(x.child[i], k);
            }

        }
    }
}
