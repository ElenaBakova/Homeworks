using System;
using System.Collections.Generic;

namespace MapFilterFold
{
    public class MapFilterFold
    {
        /// <summary>
        /// Changes each element from list using function
        /// </summary>
        /// <typeparam name="TInput">type of the elements</typeparam>
        /// <param name="function">function that changes element in list</param>
        /// <returns>New list</returns>
        public static List<TOutput> Map<TInput, TOutput>(List<TInput> list, Func<TInput, TOutput> function)
        {
            var answerList = new List<TOutput>();
            foreach (var element in list)
            {
                answerList.Add(function(element));
            }
            return answerList;
        }
        
        /// <summary>
        /// Creates new list that contains elements for which function returned true
        /// </summary>
        /// <param name="function">Recieves element, returns true or false</param>
        /// <returns>New list</returns>
        public static List<TInput> Filter<TInput>(List<TInput> list, Func<TInput, bool> function)
            => list.FindAll(i => function(i));
        
        /// <summary>
        /// Accumulates result for each element from list
        /// </summary>
        /// <param name="value">starting value</param>
        /// <returns>Accumulated result</returns>
        public static TOutput Fold<TInput, TOutput>(List<TInput> list, TOutput value, Func<TOutput, TInput, TOutput> function)
        {
            foreach (var element in list)
            {
                value = function(value, element);
            }
            return value;
        }
    }
}
