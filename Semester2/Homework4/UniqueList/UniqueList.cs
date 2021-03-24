﻿namespace UniqueList
{
    public class UniqueList : List
    {
        /// <summary>
        /// Adds value into list
        /// </summary>
        public override void Add(int value, int position)
        {
            if (IsContain(value))
            {
                throw new AddingExistingValueException("Error: that value already exists");
            }
            base.Add(value, position);
        }

        /// <summary>
        /// Changes element in position
        /// </summary>
        public override void ChangeElement(int newValue, int position)
        {
            if (IsContain(newValue))
            {
                throw new AddingExistingValueException("Error: that value already exists");
            }
            base.ChangeElement(newValue, position);
        }
    }
}
