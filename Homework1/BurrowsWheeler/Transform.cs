using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        private static SortedDictionary<char, int> GetAlphabet(string inputString)
        {
            var alphabet = new SortedDictionary<char, int>();
            for (int i = 0; inputString.Length > 0; )
            {
                int count = inputString.Where(x => x == inputString[i]).Count();
                char symbol = inputString[i];
                inputString = inputString.Replace(inputString[i].ToString(), null);
                alphabet.Add(symbol, count);
                
            }
            int index = 0;
            int carryover = 0;
            foreach (char symbol in alphabet.Keys)
            {
                if (index == 0)
                {
                    carryover = alphabet[symbol];
                    alphabet[symbol] = 0;
                    index++;
                    continue;
                }
                int temp = alphabet[symbol];
                alphabet[symbol] = carryover;
                carryover = temp + alphabet[symbol];
            }
            return alphabet;
        }

        private static int[] MakeArray(string inputString)
        {
            var alphabet = GetAlphabet(inputString);
            var transitionArray = new int[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                transitionArray[i] = alphabet[inputString[i]];
                alphabet[inputString[i]]++;
            }
            return transitionArray;
        }

        public static void BWTReverseMethod(string inputString, int index)
        {
            int[] tansitionArray = MakeArray(inputString);
        }
    }
}
