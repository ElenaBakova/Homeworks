﻿using System;

namespace MatrixMultiplication
{
    /// <summary>
    /// Class for comparing multiplicating methods
    /// </summary>
    static class MethodsComparison
    {
        /// <summary>
        /// Counts max and min time, average and standard deviation
        /// </summary>
        /// <param name="func">Matrix multiplication function</param>
        public static void Count(Func<Matrix, Matrix, Matrix> func)
        {
            (int i, int j, double time) minTime = (0, 0, 1000000);
            (int i, int j, double time) maxTime = (0, 0, 0);
            const int countExperiments = 10;
            const int firstMatrixRows = 500;
            const int upperBound = 2000;
            const int lowerBound = 500;
            const int step = 500;
            for (int i = lowerBound; i <= upperBound; i += step)
            {
                for (int j = i; j <= upperBound; j += step)
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
                        if (maxTime.time < time)
                        {
                            maxTime = (i, j, time);
                        }
                        if (minTime.time > time)
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
