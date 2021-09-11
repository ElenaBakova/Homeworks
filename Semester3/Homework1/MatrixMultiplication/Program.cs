using System;

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

            var firstMatrix = new Matrix(firstMatrixPath);
            var secondMatrix = new Matrix(secoindMatrixPath);
            // var resultMatrix = MultiplicationMatrixesMethod;
            // Write resultMatrix to file
            Console.WriteLine($"Elapsed time: {Matrix.MultiplicateMatrices(firstMatrix, secondMatrix).TotalSeconds} sec");
        }
    }
}