using System;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Concurrent method");
            MethodsComparison.Count(Matrix.MultiplicateMatrices);
            Console.WriteLine("---------------------\nSequential method");
            MethodsComparison.Count(Matrix.MultiplicateMatricesUsually);*/

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
            Console.WriteLine($"Elapsed time(sequential way): {Matrix.MeasureElapsedTime(firstMatrix, secondMatrix, Matrix.MultiplicateMatricesUsually).TotalSeconds} sec");
            Console.WriteLine($"Elapsed time(concurrent): {Matrix.MeasureElapsedTime(firstMatrix, secondMatrix, Matrix.MultiplicateMatrices).TotalSeconds} sec");
            Matrix.WriteMatrixToTheFile(Matrix.MultiplicateMatrices(firstMatrix, secondMatrix), "../../../Result.txt");
        }
    }
}