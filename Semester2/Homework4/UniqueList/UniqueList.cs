namespace UniqueList
{
    class UniqueList : List
    {
        /// <summary>
        /// Adds value into list
        /// </summary>
        public override void Add(int value, int position)
        {
            if (IsContain(value))
            {
                return;
                // throw "This value already exist"
            }
            base.Add(value, position);
        }

        /// <summary>
        /// Changes element in position
        /// </summary>
        public override void ChangeElement(int position, int newValue)
        {
            if (IsContain(newValue))
            {
                return;
                // throw "This value already exist"
            }
            base.ChangeElement(newValue, position);
        }
}
