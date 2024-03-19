// See https://aka.ms/new-console-template for more information
using CSIMediaSortingBenchmark;

Console.WriteLine("Hello, World!");
var result = BenchMarker.BenchmarkAlgorithms(1000, 10);
BenchMarker.PrintBenchmarkResults(result);