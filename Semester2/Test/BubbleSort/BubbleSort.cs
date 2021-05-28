using System;
using System.Collections.Generic;

namespace BubbleSort
{
	/// <summary>
	/// Class for generic bubble sort
	/// </summary>
	class BubbleSort
    {
		/// <summary>
		/// Sorting method
		/// </summary>
		/// <typeparam name="TValue">The type of elements in the list</typeparam>
		/// <param name="list">List that should be sorted</param>
		/// <param name="comparator">Function for comparing two elements</param>
        public void Sorting<TValue>(List<TValue> list, Func<TValue, TValue, int> comparator)
        {
			int size = list.Count;
			for (int i = 0; i < size - 1; ++i)
			{
				for (int j = 0; j < size - i - 1; ++j)
				{
					if (comparator(list[j], list[j + 1]) > 0)
					{
						var temp = list[j];
						list[j] = list[j + 1];
						list[j + 1] = temp;
					}
				}
			}
		}
    }
}
