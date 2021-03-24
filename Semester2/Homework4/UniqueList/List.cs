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
        int listSize;

        /// <summary>
        /// Returns true if list is empty.
        /// </summary>
        public bool Empty
            => listSize == 0;

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
            ListElement current = head;
            for (int i = 0; i + 1 != position; i++)
            {
                current = current.Next;
            }
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
            ListElement current = head;
            for (int i = 0; i + 1 != position; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }

        /// <summary>
        /// Replaces elements value
        /// </summary>
        /// <param name="position">position of element</param>
        /// <param name="newValue">new value of the element</param>
        public virtual void ChangeElement(int position, int newValue)
        {
            if (position > listSize - 1 || position < 0)
            {
                return;
            }
            ListElement current = head;
            for (int i = 0; i != position; i++)
            {
                current = current.Next;
            }
            current.Value = newValue;
        }

        /// <summary>
        /// Checks whether value is in the list
        /// </summary>
        /// <returns>True if value is present</returns>
        public bool IsContain(int value)
        {
            ListElement current = head;
            for (int i = 1; i <= listSize; i++)
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
