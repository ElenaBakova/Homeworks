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
        Node root;

        class Node
        {
            public int countNodes;
            public string[] keys;
            public Node[] child;
            public bool isLeaf;

            public Node(int order)
            {
                keys = new string[2 * order - 1];
                child = new Node[2 * order];
                isLeaf = true;
            }
        }

        public BTree(int order)
        {
            treeOrder = order;
            root = new Node(order);
        }
    }
}
