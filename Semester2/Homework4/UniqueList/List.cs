namespace UniqueList
{
    /// <summary>
    /// Contains integer values
    /// </summary>
    class List
    {
        private class ListElement
        {
            public ListElement(int value, ListElement next)
            {
                Value = value;
                Next = next;
            }

            public int Value { get; set; }

            public ListElement Next { get; set; }
        }

        private ListElement head;

        /// <summary>
        /// Returns true if list is empty.
        /// </summary>
        public bool Empty => head == null;

        /// <summary>
        /// Adds value into list
        /// </summary>
        /// <param name="value">New value</param>
        public void Add(int value, int position)
        {
            
        }
    }
}
