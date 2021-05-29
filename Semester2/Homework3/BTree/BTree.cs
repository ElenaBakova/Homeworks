using System;

namespace BTree
{
    /// <summary>
    /// Tree wich contains key and value
    /// </summary>
    class BTree
    {
        readonly int treeDegree;
        private Node root;
        
        /// <summary>
        /// B-tree constructor
        /// </summary>
        /// <param name="degree">Tree minimum degree</param>
        public BTree(int degree)
        {
            treeDegree = degree;
            root = new Node(degree);
        }

        private string FindValue(Node root, string key)
        {
            if (root == null)
            {
                return null;
            }
            int i = 0;
            for (; i < root.KeysCount; i++)
            {
                int comparingResult = string.Compare(key, root.Data[i].Key);
                if (comparingResult == -1)
                {
                    break;
                }
                if (comparingResult == 0)
                {
                    return root.Data[i].Value;
                }
            }
            return root.IsLeaf ? null : FindValue(root.Children[i], key);
        }

        /// <summary>
        /// Searches for a key in the tree
        /// </summary>
        /// <returns>Key's value</returns>
        public string FindValueByKey(string key)
            => FindValue(root, key);

        /// <summary>
        /// True if key is in the tree
        /// </summary>
        public bool IsContain(string key)
            => FindValue(root, key) != null;

        /// <summary>
        /// Inserts key-value into the tree
        /// </summary>
        public void Insert(string key, string value)
        {
            Node tempRoot = root;
            if (tempRoot.KeysCount == 2 * treeDegree - 1)
            {
                Node newNode = new Node(treeDegree);
                root = newNode;
                newNode.IsLeaf = false;
                newNode.KeysCount = 0;
                newNode.Children[0] = tempRoot;
                SplitNodes(newNode, tempRoot, 0);
                InsertValue(newNode, key, value);
            }
            else
            {
                InsertValue(tempRoot, key, value);
            }
        }

        private void InsertValue(Node root, string key, string value)
        {
            int i = root.KeysCount - 1;
            if (root.IsLeaf)
            {
                for (; i >= 0 && string.Compare(key, root.Data[i].Key) < 0; i--)
                {
                    root.Data[i + 1] = root.Data[i];
                }
                root.Data[i + 1] = (key, value);
                root.KeysCount++;
            }
            else
            {
                for (; i >= 0 && string.Compare(key, root.Data[i].Key) < 0; i--)
                {
                }
                i++;
                Node temp = root.Children[i];
                if (temp.KeysCount == 2 * treeDegree - 1)
                {
                    SplitNodes(root, temp, i);
                    if (string.Compare(key, root.Data[i].Key) > 0)
                    {
                        i++;
                    }
                }
                InsertValue(root.Children[i], key, value);
            }
        }

        private void SplitNodes(Node first, Node second, int position)
        {
            var temp = new Node(treeDegree);
            temp.IsLeaf = second.IsLeaf;
            temp.KeysCount = treeDegree - 1;
            for (int i = 0; i < treeDegree - 1; i++)
            {
                temp.Data[i] = second.Data[i + treeDegree];
            }
            if (!second.IsLeaf)
            {
                for (int i = 0; i < treeDegree; i++)
                {
                    temp.Children[i] = second.Children[i + treeDegree];
                }
            }
            second.KeysCount = treeDegree - 1;

            for (int i = first.KeysCount; i >= position + 1; i--)
            {
                first.Children[i + 1] = first.Children[i];
            }
            first.Children[position + 1] = temp;

            for (int i = first.KeysCount - 1; i >= position; i--)
            {
                first.Data[i + 1] = first.Data[i];
            }
            first.Data[position] = second.Data[treeDegree - 1];
            first.KeysCount++;
        }

        /*private void RemoveKey(Node node, string key)
        {
            int pos = node.FindInNode(key);
            if (pos != -1)
            {
                if (node.IsLeaf)
                {
                    int i = 0;
                    for (i = 0; i < node.KeysCount && node.keys[i] != key; i++)
                    {
                    }

                    for (; i < node.KeysCount; i++)
                    {
                        if (i != 2 * treeDegree - 2)
                        {
                            node.keys[i] = node.keys[i + 1];
                        }
                    }
                    node.KeysCount--;
                }
                else if (!node.IsLeaf)
                {

                    Node pred = node.GetChild(pos);
                    string predKey = "";
                    if (pred.KeysCount >= treeDegree)
                    {
                        for (; ; )
                        {
                            if (pred.IsLeaf)
                            {
                                predKey = pred.keys[pred.KeysCount - 1];
                                break;
                            }
                            else
                            {
                                pred = pred.GetChild(pred.KeysCount);
                            }
                        }
                        Remove(pred, predKey);
                        node.keys[pos] = predKey;
                        return;
                    }

                    Node nextNode = node.GetChild(pos + 1);
                    if (nextNode.KeysCount >= treeDegree)
                    {
                        string nextKey = nextNode.keys[0];
                        if (!nextNode.IsLeaf)
                        {
                            nextNode = nextNode.GetChild(0);
                            for (; ; )
                            {
                                if (nextNode.IsLeaf)
                                {
                                    nextKey = nextNode.keys[nextNode.KeysCount - 1];
                                    break;
                                }
                                else
                                {
                                    nextNode = nextNode.GetChild(nextNode.KeysCount);
                                }
                            }
                        }
                        Remove(nextNode, nextKey);
                        node.keys[pos] = nextKey;
                        return;
                    }

                    int temp = pred.KeysCount + 1;
                    pred.keys[pred.KeysCount] = node.keys[pos];
                    pred.KeysCount++;
                    for (int i = 0, j = pred.KeysCount; i < nextNode.KeysCount; i++)
                    {
                        pred.keys[j] = nextNode.keys[i];
                        j++;
                        pred.KeysCount++;
                    }
                    for (int i = 0; i < nextNode.KeysCount + 1; i++)
                    {
                        pred.AssignChild(temp, nextNode.GetChild(i));
                        temp++;
                    }

                    node.AssignChild(pos, pred);
                    for (int i = pos; i < node.KeysCount; i++)
                    {
                        if (i != 2 * treeDegree - 2)
                        {
                            node.keys[i] = node.keys[i + 1];
                        }
                    }
                    for (int i = pos + 1; i < node.KeysCount + 1; i++)
                    {
                        if (i != 2 * treeDegree - 1)
                        {
                            node.AssignChild(i, node.GetChild(i + 1));
                        }
                    }
                    node.KeysCount--;
                    if (node.KeysCount == 0)
                    {
                        if (node == root)
                        {
                            root = node.GetChild(0);
                        }
                        node = node.GetChild(0);
                    }
                    Remove(pred, key);
                    return;
                }
            }
            else
            {
                for (pos = 0; pos < node.KeysCount; pos++)
                {
                    if (string.Compare(node.keys[pos], key) > 0)
                    {
                        break;
                    }
                }
                Node tmp = node.GetChild(pos);
                if (tmp.KeysCount >= treeDegree)
                {
                    Remove(tmp, key);
                    return;
                }
                if (true)
                {
                    Node nb = null;
                    string devider = "";

                    if (pos != node.KeysCount && node.GetChild(pos + 1).KeysCount >= treeDegree)
                    {
                        devider = node.keys[pos];
                        nb = node.GetChild(pos + 1);
                        node.keys[pos] = nb.keys[0];
                        tmp.keys[tmp.KeysCount++] = devider;
                        tmp.AssignChild(tmp.KeysCount, nb.GetChild(0));
                        for (int i = 1; i < nb.KeysCount; i++)
                        {
                            nb.keys[i - 1] = nb.keys[i];
                        }
                        for (int i = 1; i <= nb.KeysCount; i++)
                        {
                            nb.AssignChild(i - 1, nb.GetChild(i));
                        }
                        nb.KeysCount--;
                        Remove(tmp, key);
                        return;
                    }
                    else if (pos != 0 && node.GetChild(pos - 1).KeysCount >= treeDegree)
                    {

                        devider = node.keys[pos - 1];
                        nb = node.GetChild(pos - 1);
                        node.keys[pos - 1] = nb.keys[nb.KeysCount - 1];
                        Node child = nb.GetChild(nb.KeysCount);
                        nb.KeysCount--;

                        for (int i = tmp.KeysCount; i > 0; i--)
                        {
                            tmp.keys[i] = tmp.keys[i - 1];
                        }
                        tmp.keys[0] = devider;
                        for (int i = tmp.KeysCount + 1; i > 0; i--)
                        {
                            tmp.AssignChild(i, tmp.GetChild(i - 1));
                        }
                        tmp.AssignChild(0, child);
                        tmp.KeysCount++;
                        Remove(tmp, key);
                        return;
                    }
                    else
                    {
                        Node leftSubtree;
                        Node rightSubtree;
                        bool last;
                        if (pos != node.KeysCount)
                        {
                            devider = node.keys[pos];
                            leftSubtree = node.GetChild(pos);
                            rightSubtree = node.GetChild(pos + 1);
                        }
                        else
                        {
                            devider = node.keys[pos - 1];
                            leftSubtree = node.GetChild(pos - 1);
                            rightSubtree = node.GetChild(pos);
                            last = true;
                            pos--;
                        }
                        for (int i = pos; i < node.KeysCount - 1; i++)
                        {
                            node.keys[i] = node.keys[i + 1];
                        }
                        for (int i = pos + 1; i < node.KeysCount; i++)
                        {
                            node.AssignChild(i, node.GetChild(i + 1));
                        }
                        node.KeysCount--;
                        leftSubtree.keys[leftSubtree.KeysCount++] = devider;

                        for (int i = 0, j = leftSubtree.KeysCount; i < rightSubtree.KeysCount + 1; i++, j++)
                        {
                            if (i < rightSubtree.KeysCount)
                            {
                                leftSubtree.keys[j] = rightSubtree.keys[i];
                            }
                            leftSubtree.AssignChild(j, rightSubtree.GetChild(i));
                        }
                        leftSubtree.KeysCount += rightSubtree.KeysCount;
                        if (node.KeysCount == 0)
                        {
                            if (node == root)
                            {
                                root = node.GetChild(0);
                            }
                            node = node.GetChild(0);
                        }
                        Remove(leftSubtree, key);
                        return;
                    }
                }
            }
        }*/

        /// <summary>
        /// Removes key from the tree
        /// </summary>
        public void RemoveKey(string key)
        {
            if (FindValue(root, key) == null)
            {
                return;
            }
            Remove(root, key);
        }
    }
}
