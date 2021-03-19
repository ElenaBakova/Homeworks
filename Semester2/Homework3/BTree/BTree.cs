using System;

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
            Node r = root;
            if (r.countNodes == 2 * treeOrder - 1)
            {
                Node s = new Node(treeOrder);
                root = s;
                s.isLeaf = false;
                s.countNodes = 0;
                s.child[0] = r;
                SplitNodes(s, r, 0);
                insertValue(s, key);
            }
            else
            {
                insertValue(r, key);
            }
        }
}
