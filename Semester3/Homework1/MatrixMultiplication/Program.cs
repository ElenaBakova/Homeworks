using System;
using System.IO;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var rand = new Random();
            using (var stream = new StreamWriter("../../../MatrixA.txt"))
            {
                stream.WriteLine("500 250");
                for (int i = 0; i < 500; i++)
                {
                    for (int j = 0; j < 250; j++)
                    {
                        stream.Write((rand.Next() % 10).ToString() + " ");
                    }
                    stream.Write("\n");
                }
            }

            using (var stream = new StreamWriter("../../../MatrixB.txt"))
            {
                stream.WriteLine("250 500");
                for (int i = 0; i < 250; i++)
                {
                    for (int j = 0; j < 500; j++)
                    {
                        stream.Write((rand.Next() % 10).ToString() + " ");
                    }
                    stream.Write("\n");
                }
            }*/

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
            Console.WriteLine($"Elapsed time: {Matrix.MeasureElapsedTime(firstMatrix, secondMatrix, Matrix.MultiplicateMatricesUsually).TotalSeconds} sec");
            Console.WriteLine($"Elapsed time: {Matrix.MeasureElapsedTime(firstMatrix, secondMatrix, Matrix.MultiplicateMatrices).TotalSeconds} sec");
            // Matrix.WriteMatrixToTheFile(Matrix.MultiplicateMatrices(firstMatrix, secondMatrix));
            Matrix.WriteMatrixToTheFile(Matrix.MultiplicateMatricesUsually(firstMatrix, secondMatrix));
        }
    }
}