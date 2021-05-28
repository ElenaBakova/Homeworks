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

        private class Node
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
                for (i = x.countNodes - 1; i >= 0 && string.Compare(k, x.keys[i]) < 0; i--)
                {
                    x.keys[i + 1] = x.keys[i];
                }
                x.keys[i + 1] = k;
                x.countNodes = x.countNodes + 1;
            }
            else
            {
                int i = 0;
                for (i = x.countNodes - 1; i >= 0 && string.Compare(k, x.keys[i]) < 0; i--)
                {
                }
                i++;
                Node tmp = x.child[i];
                if (tmp.countNodes == 2 * treeOrder - 1)
                {
                    SplitNodes(x, tmp, i);
                    if (string.Compare(k, x.keys[i]) > 0)
                    {
                        i++;
                    }
                }
                insertValue(x.child[i], k);
            }
        }

        public bool IsContain(string key)
            => FindValueByKey(root, key) != null;

        private void Remove(Node node, string key)
        {
            int pos = node.FindInNode(key);
            if (pos != -1)
            {
                if (node.isLeaf)
                {
                    int i = 0;
                    for (i = 0; i < node.countNodes && node.keys[i] != key; i++)
                    {
                    }

                    for (; i < node.countNodes; i++)
                    {
                        if (i != 2 * treeOrder - 2)
                        {
                            node.keys[i] = node.keys[i + 1];
                        }
                    }
                    node.countNodes--;
                }
                else if (!node.isLeaf)
                {

                    Node pred = node.child[pos];
                    string predKey = "";
                    if (pred.countNodes >= treeOrder)
                    {
                        for (; ; )
                        {
                            if (pred.isLeaf)
                            {
                                predKey = pred.keys[pred.countNodes - 1];
                                break;
                            }
                            else
                            {
                                pred = pred.child[pred.countNodes];
                            }
                        }
                        Remove(pred, predKey);
                        node.keys[pos] = predKey;
                        return;
                    }

                    Node nextNode = node.child[pos + 1];
                    if (nextNode.countNodes >= treeOrder)
                    {
                        string nextKey = nextNode.keys[0];
                        if (!nextNode.isLeaf)
                        {
                            nextNode = nextNode.child[0];
                            for (; ; )
                            {
                                if (nextNode.isLeaf)
                                {
                                    nextKey = nextNode.keys[nextNode.countNodes - 1];
                                    break;
                                }
                                else
                                {
                                    nextNode = nextNode.child[nextNode.countNodes];
                                }
                            }
                        }
                        Remove(nextNode, nextKey);
                        node.keys[pos] = nextKey;
                        return;
                    }

                    int temp = pred.countNodes + 1;
                    pred.keys[pred.countNodes] = node.keys[pos];
                    pred.countNodes++;
                    for (int i = 0, j = pred.countNodes; i < nextNode.countNodes; i++)
                    {
                        pred.keys[j] = nextNode.keys[i];
                        j++;
                        pred.countNodes++;
                    }
                    for (int i = 0; i < nextNode.countNodes + 1; i++)
                    {
                        pred.child[temp] = nextNode.child[i];
                        temp++;
                    }

                    node.child[pos] = pred;
                    for (int i = pos; i < node.countNodes; i++)
                    {
                        if (i != 2 * treeOrder - 2)
                        {
                            node.keys[i] = node.keys[i + 1];
                        }
                    }
                    for (int i = pos + 1; i < node.countNodes + 1; i++)
                    {
                        if (i != 2 * treeOrder - 1)
                        {
                            node.child[i] = node.child[i + 1];
                        }
                    }
                    node.countNodes--;
                    if (node.countNodes == 0)
                    {
                        if (node == root)
                        {
                            root = node.child[0];
                        }
                        node = node.child[0];
                    }
                    Remove(pred, key);
                    return;
                }
            }
            else
            {
                for (pos = 0; pos < node.countNodes; pos++)
                {
                    if (string.Compare(node.keys[pos], key) > 0)
                    {
                        break;
                    }
                }
                Node tmp = node.child[pos];
                if (tmp.countNodes >= treeOrder)
                {
                    Remove(tmp, key);
                    return;
                }
                if (true)
                {
                    Node nb = null;
                    string devider = "";

                    if (pos != node.countNodes && node.child[pos + 1].countNodes >= treeOrder)
                    {
                        devider = node.keys[pos];
                        nb = node.child[pos + 1];
                        node.keys[pos] = nb.keys[0];
                        tmp.keys[tmp.countNodes++] = devider;
                        tmp.child[tmp.countNodes] = nb.child[0];
                        for (int i = 1; i < nb.countNodes; i++)
                        {
                            nb.keys[i - 1] = nb.keys[i];
                        }
                        for (int i = 1; i <= nb.countNodes; i++)
                        {
                            nb.child[i - 1] = nb.child[i];
                        }
                        nb.countNodes--;
                        Remove(tmp, key);
                        return;
                    }
                    else if (pos != 0 && node.child[pos - 1].countNodes >= treeOrder)
                    {

                        devider = node.keys[pos - 1];
                        nb = node.child[pos - 1];
                        node.keys[pos - 1] = nb.keys[nb.countNodes - 1];
                        Node child = nb.child[nb.countNodes];
                        nb.countNodes--;

                        for (int i = tmp.countNodes; i > 0; i--)
                        {
                            tmp.keys[i] = tmp.keys[i - 1];
                        }
                        tmp.keys[0] = devider;
                        for (int i = tmp.countNodes + 1; i > 0; i--)
                        {
                            tmp.child[i] = tmp.child[i - 1];
                        }
                        tmp.child[0] = child;
                        tmp.countNodes++;
                        Remove(tmp, key);
                        return;
                    }
                    else
                    {
                        Node leftSubtree = null;
                        Node rightSubtree = null;
                        bool last = false;
                        if (pos != node.countNodes)
                        {
                            devider = node.keys[pos];
                            leftSubtree = node.child[pos];
                            rightSubtree = node.child[pos + 1];
                        }
                        else
                        {
                            devider = node.keys[pos - 1];
                            rightSubtree = node.child[pos];
                            leftSubtree = node.child[pos - 1];
                            last = true;
                            pos--;
                        }
                        for (int i = pos; i < node.countNodes - 1; i++)
                        {
                            node.keys[i] = node.keys[i + 1];
                        }
                        for (int i = pos + 1; i < node.countNodes; i++)
                        {
                            node.child[i] = node.child[i + 1];
                        }
                        node.countNodes--;
                        leftSubtree.keys[leftSubtree.countNodes++] = devider;

                        for (int i = 0, j = leftSubtree.countNodes; i < rightSubtree.countNodes + 1; i++, j++)
                        {
                            if (i < rightSubtree.countNodes)
                            {
                                leftSubtree.keys[j] = rightSubtree.keys[i];
                            }
                            leftSubtree.child[j] = rightSubtree.child[i];
                        }
                        leftSubtree.countNodes += rightSubtree.countNodes;
                        if (node.countNodes == 0)
                        {
                            if (node == root)
                            {
                                root = node.child[0];
                            }
                            node = node.child[0];
                        }
                        Remove(leftSubtree, key);
                        return;
                    }
                }
            }
        }

        public void Remove(string key)
        {
            Node x = FindValueByKey(root, key);
            if (x == null)
            {
                return;
            }
            Remove(root, key);
        }
    }
}
