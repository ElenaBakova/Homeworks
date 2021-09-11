using System;
using System.IO;
using System.Threading;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstMatrixPath;
            string secoindMatrixPath;
            if (args.Length < 2)
            {
                Console.WriteLine("Couldn't find input files path\nPlease enter Matrix A path");
                firstMatrixPath = Console.ReadLine();
                Console.WriteLine("Please enter Matrix B path");
                secoindMatrixPath = Console.ReadLine();
            }
            else
            {
                firstMatrixPath = args[0];
                secoindMatrixPath = args[1];
            }

            using (StreamReader stream = File.OpenText(firstMatrixPath))
            {

            }
        }
    }
}
