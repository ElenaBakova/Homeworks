using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MatrixMultiplication
{
    /// <summary>
    /// Class for a matrix
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Reads size of matrix and matrix from file
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
        /// Number of rows and columns in the matrix
        /// </summary>
        public (int rows, int columns) Size { get; private set; }
        private List<int>[] matrix;

        /// <summary>
        /// Method measures elapsed time to multiply matrices usual way
        /// </summary>
        /// <returns>Elapsed time</returns>
        public static TimeSpan MultiplicateMatrices(Matrix first, Matrix second)
        {
            if (first.Size.columns != second.Size.rows)
            {
                return TimeSpan.Zero;
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

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

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
