using System;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Concurrent
                Matrix size = 500x500, average = 2.0561sec, standard deviation = 0.3650sec
                Matrix size = 500x1000, average = 3.5755sec, standard deviation = 0.1552sec
                Matrix size = 500x1500, average = 5.9006sec, standard deviation = 0.4510sec
                Matrix size = 500x2000, average = 8.0720sec, standard deviation = 0.4270sec
                Matrix size = 1000x1000, average = 7.6110sec, standard deviation = 0.6659sec
                Matrix size = 1000x1500, average = 12.4172sec, standard deviation = 0.9719sec
                Matrix size = 1000x2000, average = 15.7364sec, standard deviation = 1.0485sec
                Matrix size = 1500x1500, average = 15.9984sec, standard deviation = 1.0986sec
                Matrix size = 1500x2000, average = 22.3494sec, standard deviation = 0.7363sec
                Matrix size = 2000x2000, average = 30.6308sec, standard deviation = 0.5837sec
                Maximum elapsed time = 31.7553sec, matrix size = 2000x2000
                Minimum elapsed time = 1.7531sec, matrix size = 500x500
            -----------------------------------------------------------------------------------
            Sequential
                Matrix size = 500x500, average = 6.6471sec, standard deviation = 1.2587sec
                Matrix size = 500x1000, average = 11.8923sec, standard deviation = 0.6388sec
                Matrix size = 500x1500, average = 19.7157sec, standard deviation = 1.8099sec
                Matrix size = 500x2000, average = 25.8691sec, standard deviation = 0.8613sec
                Matrix size = 1000x1000, average = 23.7502sec, standard deviation = 0.6999sec
                Matrix size = 1000x1500, average = 37.5787sec, standard deviation = 1.9236sec
                Matrix size = 1000x2000, average = 50.6542sec, standard deviation = 4.2561sec
                Matrix size = 1500x1500, average = 59.4949sec, standard deviation = 6.8288sec
                Matrix size = 1500x2000, average = 72.7378sec, standard deviation = 2.2146sec
                Matrix size = 2000x2000, average = 97.7436sec, standard deviation = 1.7747sec
                Maximum elapsed time = 101.6491sec, matrix size = 2000x2000
                Minimum elapsed time = 5.4708sec, matrix size = 500x500
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