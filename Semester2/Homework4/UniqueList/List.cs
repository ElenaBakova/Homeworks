namespace UniqueList
{
    /// <summary>
    /// Contains integer values
    /// </summary>
    public class List
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
        private int listSize;

        /// <summary>
        /// Returns true if list is empty.
        /// </summary>
        public bool Empty
            => listSize == 0;
        
        /// <summary>
        /// Returns list size
        /// </summary>
        public int Size
            => listSize;

        public int GetValueByPosition(int position)
            => FindPosition(position, head).Value;

        private ListElement FindPosition(int position, ListElement current)
        {
            for (int i = 0; i != position; i++)
            {
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// Adds value into list
        /// </summary>
        /// <param name="value">New value</param>
        public virtual void Add(int value, int position)
        {
            if (position > listSize || position < 0)
            {
                return;
            }
            listSize++;
            if (position == 0)
            {
                head = new ListElement(value, head);
                return;
            }
            ListElement current = FindPosition(position - 1, head);
            current.Next = new ListElement(value, current.Next);
        }
        
        /// <summary>
        /// Deletes element from list by position
        /// </summary>
        /// <param name="position">position of element</param>
        public void Delete(int position)
        {
            if (position > listSize - 1 || (position < 0 && !Empty))
            {
                throw new DeletingNonPresentElementException();
            }
            listSize--;
            if (position == 0)
            {
                head = head.Next;
                return;
            }
            ListElement current = FindPosition(position - 1, head);
            current.Next = current.Next.Next;
        }

        /// <summary>
        /// Replaces elements value
        /// </summary>
        /// <param name="position">position of element</param>
        /// <param name="newValue">new value of the element</param>
        public virtual void ChangeElement(int newValue, int position)
        {
            if (position > listSize - 1 || position < 0)
            {
                return;
            }
            FindPosition(position, head).Value = newValue;
        }

        /// <summary>
        /// Checks whether value is in the list
        /// </summary>
        /// <returns>True if list contains value</returns>
        public bool Contains(int value)
        {
            ListElement current = head;
            for (int i = 0; i < listSize; i++)
            {
                if (current.Value == value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}
