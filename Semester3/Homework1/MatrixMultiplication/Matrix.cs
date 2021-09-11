using System;
using System.Collections.Generic;
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
        /// Number of rows and columns in the matrix
        /// </summary>
        public (int rows, int columns) Size { get; private set; }
        private List<int>[] matrix;

        /// <summary>
        /// Method for multiplicating matrices
        /// </summary>
        /// <returns>Result matrix</returns>
        public Matrix MultiplicateMatrices(Matrix first, Matrix second)
        {
            if (first.Size.columns != second.Size.rows)
            {
                
            }
        }
    }
}
