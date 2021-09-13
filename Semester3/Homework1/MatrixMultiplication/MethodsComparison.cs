using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
    /// <summary>
    /// Class for comparing multiplicating methods
    /// </summary>
    class MethodsComparison
    {
        /// <summary>
        /// Generates matrix with given size into the file
        /// </summary>
        /// <param name="size">Size of matrix</param>
        /// <param name="path">File path for the matrix</param>
        public void GenerateMatrix((int rows, int columns) size, string path)
        {
            var rand = new Random();
            using (var stream = new StreamWriter(path))
            {
                stream.WriteLine($"{size.rows} {size.columns}");
                for (int i = 0; i < size.rows; i++)
                {
                    for (int j = 0; j < size.columns; j++)
                    {
                        stream.Write((rand.Next() % 50).ToString() + " ");
                    }
                    stream.Write("\n");
                }
            }
        }
    }
}
