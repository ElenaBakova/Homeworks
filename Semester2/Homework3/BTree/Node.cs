namespace BTree
{
    /// <summary>
    /// B-tree node class
    /// </summary>
    class Node
    {
        /// <summary>
        /// Tree data type class
        /// </summary>
        public struct TreeData
        {
            public string Key;
            public string Value;
            
            public override string ToString()
                => Key + ": " + Value;
        }

        public static TreeData ConvertToTreeData(string key, string value)
            => new TreeData { Key = key, Value = value };

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
        public TreeData[] Data { get; set; }

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
            Data = new TreeData[2 * degree];
            Children = new Node[2 * degree];
            IsLeaf = true;
            KeysCount = 0;
        }

        /// <summary>
        /// Returns the index of the first key that is equal or greater than given key
        /// </summary>
        public int FindInNode(string key)
        {
            int i = 0;
            for (; i < KeysCount && string.Compare(Data[i].Key, key) < 0; i++)
            {
            }
            return i;
        }
    }
}
