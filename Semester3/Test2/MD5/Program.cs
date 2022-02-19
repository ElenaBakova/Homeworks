global using System.Security.Cryptography;
using MD5Algorithm;
using System.Diagnostics;

const string path = "../../../../Files";
var singleThreadedMD5 = new SingleThreadedCounting();
var multiThreadedMD5 = new MultiThreadedCounting();
const int testsCount = 10;

var stopwatch = new Stopwatch();
TimeSpan averageSingleThreaded = TimeSpan.Zero;
for (int i = 0; i < testsCount; i++)
{
    stopwatch.Start();
    singleThreadedMD5.CountCheckSum(path);
    stopwatch.Stop();
    averageSingleThreaded += stopwatch.Elapsed / testsCount;
}

TimeSpan averageMultiThreaded = TimeSpan.Zero;
for (int i = 0; i < testsCount; i++)
{
    stopwatch.Start();
    multiThreadedMD5.CountCheckSum(path);
    stopwatch.Stop();
    averageMultiThreaded += stopwatch.Elapsed / testsCount;
}

Console.WriteLine($"Single-threaded MD5 average time: {averageSingleThreaded.Milliseconds}");
Console.WriteLine($"Multi-threaded MD5 average time: {averageMultiThreaded.Milliseconds}");