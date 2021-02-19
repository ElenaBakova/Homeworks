using System;
using System.Collections;

namespace BurrowsWheeler
{
    class Transform
    {
        private class MyComparer : IComparer
        {
            int IComparer.Compare(Object first, Object second)
            {
                var x = (Tuple<string, int>)first;
                var y = (Tuple<string, int>)second;
                string stringFirst = x.Item1.Substring(x.Item1.Length - x.Item2) + x.Item1.Substring(0, x.Item1.Length - x.Item2);
                string stringSecond = y.Item1.Substring(y.Item1.Length - y.Item2) + y.Item1.Substring(0, y.Item1.Length - y.Item2);
                return String.Compare(stringFirst, stringSecond);
            }
        }

        private static Tuple<string, int>[] SortBySuffix(string inputString)
        {
            var array = new Tuple<string, int>[inputString.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Tuple<string, int>(inputString, i);
            }
            Array.Sort(array, new MyComparer());
            return array;
        }

        private static Tuple<string, int> GetResultString(Tuple<string, int>[] array)
        {
            string resultString = "";
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int current = array[i].Item2;
                if (current == 0)
                {
                    index = i;
                }
                resultString += array[i].Item1[current];
            }
            return new Tuple<string, int>(resultString, index);
        }

        public static Tuple<string, int> BWTMethod(string inputString)
        {
            Tuple<string, int>[] array = SortBySuffix(inputString);
            return GetResultString(array);
        }
}
}
