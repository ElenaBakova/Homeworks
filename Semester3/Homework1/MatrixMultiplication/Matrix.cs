using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace MatrixMultiplication
{
    /// <summary>
    /// Class for a matrix
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Number of rows and columns in the matrix
        /// </summary>
        public (int rows, int columns) Size { get; private set; }
        private List<int>[] matrix;

        /// <summary>
        /// Reads matrix from file
        /// </summary>
        /// <param name="path">File path</param>
        public Matrix(string path)
        {
            using (StreamReader stream = File.OpenText(path))
            {
                var readString = stream.ReadLine();
                var numbers = readString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Size = new (int.Parse(numbers[0]), int.Parse(numbers[1]));
                matrix = new List<int>[Size.rows];
                for (int i = 0; i < Size.rows; i++)
                {
                    readString = stream.ReadLine();
                    matrix[i] = readString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                }
            }
        }

        /// <summary>
        /// Creates empty matrix with given size
        /// </summary>
        public Matrix(int rows, int columns)
        {
            Size = new(rows, columns);
            matrix = new List<int>[Size.rows];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[columns].ToList();
            }
        }

        /// <summary>
        /// Generates matrix with given size
        /// </summary>
        /// <param name="size">Size of matrix</param>
        public static Matrix GenerateMatrix((int rows, int columns) size)
        {
            var rand = new Random();
            var matrix = new Matrix(size.rows, size.columns);
            for (int i = 0; i < size.rows; i++)
            {
                for (int j = 0; j < size.columns; j++)
                {
                    matrix.matrix[i][j] = rand.Next() % 50;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Method measures elapsed time to multiply matrices
        /// </summary>
        /// <param name="func">Matrix multiplication function</param>
        /// <returns>Elapsed time</returns>
        public static TimeSpan MeasureElapsedTime(Matrix first, Matrix second, Func<Matrix, Matrix, Matrix> func)
        {
            if (first.Size.columns != second.Size.rows)
            {
                return TimeSpan.Zero;
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            func(first, second);

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        /// <summary>
        /// Sequential matrix multiplication
        /// </summary>
        /// <param name="first">First matrix</param>
        /// <param name="second">Second matrix</param>
        /// <returns>Product matrix</returns>
        public static Matrix MultiplicateMatricesUsually(Matrix first, Matrix second)
        {
            if (first.Size.columns != second.Size.rows)
            {
                return null;
            }

            var product = new Matrix(first.Size.rows, second.Size.columns);
            for (int i = 0; i < first.Size.rows; i++)
            {
                for (int j = 0; j < second.Size.columns; j++)
                {
                    for (int k = 0; k < first.Size.columns; k++)
                    {
                        product.matrix[i][j] += first.matrix[i][k] * second.matrix[k][j];
                    }
                }
            }
            return product;
        }

        /// <summary>
        /// Concurrent matrix multiplication
        /// </summary>
        /// <param name="first">First matrix</param>
        /// <param name="second">Second matrix</param>
        /// <returns>Product matrix</returns>
        public static Matrix MultiplicateMatrices(Matrix first, Matrix second)
        {
            if (first.Size.columns != second.Size.rows)
            {
                return null;
            }
            var product = new Matrix(first.Size.rows, second.Size.columns);
            var threads = new Thread[4];
            var length = first.Size.rows;
            var chunkSize = length / threads.Length + 1;

            for (int i = 0; i < threads.Length; ++i)
            {
                var localI = i;
                threads[i] = new Thread(() => {
                    for (int p = localI * chunkSize; p < (localI + 1) * chunkSize && p < length; p++)
                    {
                        for (int j = 0; j < second.Size.columns; j++)
                        {
                            for (int k = 0; k < first.Size.columns; k++)
                            {
                                product.matrix[p][j] += first.matrix[p][k] * second.matrix[k][j];
                            }
                        }
                    }
                }); 
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return product;
        }

        /// <summary>
        /// Writes matrix to the file
        /// </summary>
        /// <param name="path">File path</param>
        public static void WriteMatrixToTheFile(Matrix matrix, string path)
        {
            using (var stream = new StreamWriter(path))
            {
                for (int i = 0; i < matrix.Size.rows; i++)
                {
                    for (int j = 0; j < matrix.Size.columns; j++)
                    {
                        stream.Write($"{matrix.matrix[i][j]} ");
                    }
                    stream.Write("\n");
                }
            }
        }

        /// <summary>
        /// Checks whether matrices are equal
        /// </summary>
        /// <returns>True if two matrices equal</returns>
        public static bool AreEqual(Matrix first, Matrix second)
        {
            if (first.Size.rows != second.Size.rows || first.Size.columns != second.Size.columns)
            {
                return false;
            }
            
            for (int i = 0; i < first.Size.rows; i++)
            {
                if (first.matrix[i].SequenceEqual(second.matrix[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
