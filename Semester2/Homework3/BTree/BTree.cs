using System;

namespace BTree
{
    /// <summary>
    /// Tree wich contains key and value
    /// </summary>
    public class BTree
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

        /// <summary>
        /// Returns number of keys in the root
        /// </summary>
        public int RootKeysCount => root.KeysCount;

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
            var tempRoot = root;
            var newNode = tempRoot;
            if (tempRoot.KeysCount == 2 * treeDegree - 1)
            {
                newNode = new Node(treeDegree);
                root = newNode;
                newNode.IsLeaf = false;
                newNode.KeysCount = 0;
                newNode.Children[0] = tempRoot;
                SplitNodes(newNode, tempRoot, 0);
            }
            InsertValue(newNode, key, value);
        }

        /// <summary>
        /// Replaces value if given value differs from actual value
        /// </summary>
        private void ReplaceByNewValue(string key, string value, Node node, int position)
            => node.Data[position].Value = value;

        private void InsertValue(Node root, string key, string value)
        {
            int i = root.KeysCount - 1;
            if (root.IsLeaf)
            {
                for (; i >= 0 && string.Compare(key, root.Data[i].Key) < 0; i--)
                {
                    root.Data[i + 1] = root.Data[i];
                }
                if (i >= 0 && string.Compare(key, root.Data[i].Key) == 0)
                {
                    ReplaceByNewValue(key, value, root, i);
                    return;
                }
                root.Data[i + 1] = Node.ConvertToTreeData(key, value);
                root.KeysCount++;
            }
            else
            {
                for (; i >= 0 && string.Compare(key, root.Data[i].Key) < 0; i--)
                {
                }
                if (i >= 0 && string.Compare(key, root.Data[i].Key) == 0)
                {
                    ReplaceByNewValue(key, value, root, i);
                    return;
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

        private void Remove(Node node, string key)
        {
            int position = node.FindInNode(key);
            if (position < node.KeysCount && string.Compare(node.Data[position].Key, key) == 0)
            {
                if (node.IsLeaf)
                {
                    for (int i = position; i < node.KeysCount - 1; i++)
                    {
                        node.Data[i] = node.Data[i + 1];
                    }
                    node.KeysCount--;
                }
                else
                {
                    RemoveFromNonLeaf(node, key, position);
                }
            }
            else
            {
                bool flag = position == node.KeysCount;
                Node temp = node.Children[position];
                if (temp.KeysCount < treeDegree)
                {
                    FillChild(position, node);
                }

                if (flag && position > node.KeysCount)
                {
                    Remove(node.Children[position - 1], key);
                }
                else
                {
                    Remove(node.Children[position], key);
                }
            }
        }

        private void FillChild(int position, Node node)
        {
            if (position != 0 && node.Children[position - 1].KeysCount >= treeDegree)
            {
                GetKeyFromPrevious(node, position);
            }
            else if (position != node.KeysCount && node.Children[position + 1].KeysCount >= treeDegree)
            {
                GetKeyFromNext(node, position);
            }
            else
            {
                if (position != node.KeysCount)
                {
                    MergeNodes(node, position);
                }
                else
                {
                    MergeNodes(node, position - 1);
                }
            }
        }

        private void GetKeyFromPrevious(Node node, int position)
        {
            var child = node.Children[position];
            var sibling = node.Children[position - 1];

            for (int i = child.KeysCount - 1; i >= 0; i--)
            {
                child.Data[i + 1] = child.Data[i];
            }
            if (!child.IsLeaf)
            {
                for (int i = child.KeysCount; i >= 0; i--)
                {
                    child.Children[i + 1] = child.Children[i];
                }
            }

            child.Data[0] = node.Data[position - 1];
            if (!child.IsLeaf)
            {
                child.Children[0] = sibling.Children[sibling.KeysCount];
            }
            node.Data[position - 1] = sibling.Data[sibling.KeysCount - 1];
            child.KeysCount++;
            sibling.KeysCount--;
        }

        private void GetKeyFromNext(Node node, int position)
        {
            var child = node.Children[position];
            var sibling = node.Children[position + 1];

            child.Data[child.KeysCount] = node.Data[position];
            if (!child.IsLeaf)
            {
                child.Children[child.KeysCount + 1] = sibling.Children[0];
            }

            node.Data[position] = sibling.Data[0];
            for (int i = 1; i < sibling.KeysCount; i++)
            {
                sibling.Data[i - 1] = sibling.Data[i];
            }
            if (!sibling.IsLeaf)
            {
                for (int i = 1; i <= sibling.KeysCount; i++)
                    sibling.Children[i - 1] = sibling.Children[i];
            }
            child.KeysCount++;
            sibling.KeysCount--;
        }

        private void RemoveFromNonLeaf(Node node, string key, int position)
        {
            var predecessor = node.Children[position];
            var currentKey = node.Data[position].Key;

            if (node.Children[position].KeysCount >= treeDegree)
            {
                var predecessorData = GetPredecessor(node.Children[position]);
                node.Data[position] = predecessorData;
                Remove(predecessor, predecessorData.Key);
            }
            else if (node.Children[position + 1].KeysCount >= treeDegree)
            {
                var successorData = GetSuccessor(node.Children[position + 1]);
                node.Data[position] = successorData;
                Remove(node.Children[position + 1], successorData.Key);
            }
            else
            {
                MergeNodes(node, position);
                Remove(predecessor, currentKey);
            }
        }

        private Node.TreeData GetSuccessor(Node node)
        {
            while (!node.IsLeaf)
            {
                node = node.Children[0];
            }
            return node.Data[0];
        }
        
        private Node.TreeData GetPredecessor(Node node)
        {
            while (!node.IsLeaf)
            {
                node = node.Children[node.KeysCount];
            }
            return node.Data[node.KeysCount - 1];
        }

        private void MergeNodes(Node node, int position)
        {
            var child = node.Children[position];
            var sibling = node.Children[position + 1];
            child.Data[node.KeysCount - 1] = node.Data[position];

            for (int i = 0; i < sibling.KeysCount; i++)
            {
                child.Data[i + node.KeysCount] = sibling.Data[i];
            }

            for (int i = position + 1; i < node.KeysCount; i++)
            {
                node.Data[i - 1] = node.Data[i];
            }

            for (int i = position + 2; i <= node.KeysCount; i++)
            {
                node.Children[i - 1] = node.Children[i];
            }

            child.KeysCount += sibling.KeysCount + 1;
            node.KeysCount--;
        }

        /// <summary>
        /// Removes key from the tree
        /// </summary>
        public void RemoveKey(string key)
        {
            if (!IsContain(key))
            {
                throw new ArgumentOutOfRangeException("Key not found");
            }
            Remove(root, key);
        }

        /// <summary>
        /// Replaces key value by new
        /// </summary>
        public void ReplaceValue(string key, string value)
            => InsertValue(root, key, value);
    }
}
