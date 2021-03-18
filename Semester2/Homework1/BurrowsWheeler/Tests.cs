using System;

namespace BurrowsWheeler
{
    class Tests
    {
        public static bool Test()
        {
            bool result = Check("abacaba", "bcabaaa");
            result &= Check("banana", "nnbaaa");
            result &= Check("ab", "ba");
            return result;
        }

        private static bool Check(string initialString, string resultingString)
        {
            bool result = true;
            var bwtResult = Transform.BWTMethod(initialString);
            result &= bwtResult.Item1 == resultingString;
            result &= Transform.BWTReverseMethod(bwtResult.Item1, bwtResult.Item2) == initialString;
            return result;
        }
    }
}
