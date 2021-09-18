using System;

namespace MatrixMultiplication
{
    /// <summary>
    /// Class for comparing multiplicating methods
    /// </summary>
    class MethodsComparison
    {
        public static void Compare(Func<Matrix, Matrix, Matrix> func)
        {
            const int countExperiments = 10;
            const int firstMatrixRows = 500;
            (int i, int j, double time) maxTime = (0, 0, 0);
            (int i, int j, double time) minTime = (0, 0, 1000000);
            for (int i = 500; i <= 2000; i += 500)
            {
                for (int j = i; j <= 2000; j += 500)
                {
                    double average = 0;
                    double variance = 0;
                    var first = Matrix.GenerateMatrix((i, firstMatrixRows));
                    var second = Matrix.GenerateMatrix((firstMatrixRows, j));
                    for (int k = 0; k < countExperiments; k++)
                    {
                        var time = Matrix.MeasureElapsedTime(first, second, func).TotalSeconds;
                        average += time;
                        variance += time * time;
                        if (maxTime.time - time < 1e-4)
                        {
                            maxTime = (i, j, time);
                        }
                        if (time - minTime.time < 1e-4)
                        {
                            minTime = (i, j, time);
                        }
                    }
                    average /= countExperiments;
                    variance /= countExperiments;
                    variance -= average * average;
                    Console.WriteLine($"Matrix size = {i}x{j}, average = {average:f4}sec, standard deviation = {Math.Sqrt(variance):f4}sec");
                }
            }
            Console.WriteLine($"Maximum elapsed time = {maxTime.time:f4}sec, matrix size = {maxTime.i}x{maxTime.j}");
            Console.WriteLine($"Minimum elapsed time = {minTime.time:f4}sec, matrix size = {minTime.i}x{minTime.j}");
        }
    }
}
