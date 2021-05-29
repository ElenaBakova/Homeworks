namespace BTree
{
    /// <summary>
    /// B-tree node class
    /// </summary>
    class Node
    {
        /// <summary>
        /// Shows whether current node is leaf
        /// </summary>
        public bool IsLeaf { get; set; }

        /// <summary>
        /// Number of keys in current node
        /// </summary>
        public int KeysCount { get; set; }

        /// <summary>
        /// B-tree nodes values
        /// </summary>
        public (string Key, string Value)[] Data { get; set; }

        /// <summary>
        /// Current node children
        /// </summary>
        public Node[] Children { get; set; }

        /// <summary>
        /// BTree node constructor
        /// </summary>
        /// <param name="degree">Tree degree</param>
        public Node(int degree)
        {
            Data = new (string Key, string Value)[2 * degree];
            Children = new Node[2 * degree];
            IsLeaf = true;
            KeysCount = 0;
        }

        public int FindInNode(string key)
        {
            for (int i = 0; i < KeysCount; i++)
            {
                if (string.Compare(Data[i].Key, key) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
