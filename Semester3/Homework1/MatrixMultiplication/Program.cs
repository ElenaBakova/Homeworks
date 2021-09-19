using System;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            For a concurrent method:
            Matrix size = 500x500, average = 4.2586sec, standard deviation 1.0515sec
            Matrix size = 500x1000, average = 6.7921sec, standard deviation 0.2682sec
            Matrix size = 500x1500, average = 10.5981sec, standard deviation 0.9316sec
            Matrix size = 500x2000, average = 15.3977sec, standard deviation 1.1833sec
            Matrix size = 1000x1000, average = 13.4752sec, standard deviation 0.5519sec
            Matrix size = 1000x1500, average = 20.7799sec, standard deviation 1.3500sec
            Matrix size = 1000x2000, average = 29.1767sec, standard deviation 0.8327sec
            Matrix size = 1500x1500, average = 32.4731sec, standard deviation 3.5418sec
            Matrix size = 1500x2000, average = 46.3623sec, standard deviation 1.6939sec
            Matrix size = 2000x2000, average = 61.8461sec, standard deviation 1.7784sec
            Maximum elapsed time = 66.6235sec, matrix size = 2000x2000
            Minimum elapsed time = 3.2361sec, matrix size = 500x500
            
            For a sequential method:
            Matrix size = 500x500, average = 5.6543sec, standard deviation 0.8677sec
            Matrix size = 500x1000, average = 10.6306sec, standard deviation 0.1574sec
            Matrix size = 500x1500, average = 18.0218sec, standard deviation 0.8141sec
            Matrix size = 500x2000, average = 77.5747sec, standard deviation 143.8739sec
            Matrix size = 1000x1000, average = 27.7361sec, standard deviation 6.4724sec
            Matrix size = 1000x1500, average = 41.7132sec, standard deviation 4.8488sec
            Matrix size = 1000x2000, average = 55.9525sec, standard deviation 4.9415sec
            Matrix size = 1500x1500, average = 60.7748sec, standard deviation 2.8489sec
            Matrix size = 1500x2000, average = 219.7650sec, standard deviation 405.7366sec
            Matrix size = 2000x2000, average = 110.3666sec, standard deviation 4.4883sec
            Maximum elapsed time = 1436.9343sec, matrix size = 1500x2000
            Minimum elapsed time = 4.9235sec, matrix size = 500x500
             */

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