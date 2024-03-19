using CSI_Media.Models;
using CSI_Media.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIMediaSortingBenchmark
{
    public class BenchMarker
    {
        public static List<int> GenerateRandomNumbers(int size)
        {
            var random = new Random();
            var numbers = new List<int>(size);

            for (int i = 0; i < size; i++)
            {
                numbers.Add(random.Next()); // Generate random integer
            }

            return numbers;
        }


        public static Dictionary<string, double> BenchmarkAlgorithms(int dataSize, int iterations)
        {
            var unsortedNumbers = GenerateRandomNumbers(dataSize);
            var results = new Dictionary<string, double>();

            results.Add("Linq OrderBy", BenchmarkLinqSort(unsortedNumbers, iterations));
            results.Add("QuickSort", BenchmarkQuickSort(unsortedNumbers, iterations));
            results.Add("MergeSort", BenchmarkMergeSort(unsortedNumbers, iterations));
            results.Add("HeapSort", BenchmarkHeapSort(unsortedNumbers, iterations));


            return results;
        }
        public static void PrintBenchmarkResults(Dictionary<string, double> results)
        {
            Console.WriteLine("Benchmark Results:");
            Console.WriteLine("| Algorithm Name | Average Time (ms) |");
            Console.WriteLine("|---|---|");
            foreach (var kvp in results)
            {
                Console.WriteLine($"| {kvp.Key} | {kvp.Value:F2} |");
            }
        }

        private static double BenchmarkQuickSort(List<int> numbers, int iterations)
        {
            var _sortingService = new SortingService();
            var totalTime = 0.0;
            for (int i = 0; i < iterations; i++)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                _sortingService.SortNumbersQuickSort(new List<int>(numbers), SortDirection.Ascending);
                stopwatch.Stop();
                totalTime += stopwatch.ElapsedMilliseconds;
            }
            return totalTime / iterations;
        }
        private static double BenchmarkMergeSort(List<int> numbers, int iterations)
        {
            var _sortingService = new SortingService();
            var totalTime = 0.0;
            for (int i = 0; i < iterations; i++)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                _sortingService.SortNumbersMergeSort(new List<int>(numbers), SortDirection.Ascending);
                stopwatch.Stop();
                totalTime += stopwatch.ElapsedMilliseconds;
            }
            return totalTime / iterations;
        }
        private static double BenchmarkHeapSort(List<int> numbers, int iterations)
        {
            var _sortingService = new SortingService();
            var totalTime = 0.0;
            for (int i = 0; i < iterations; i++)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                _sortingService.SortNumbersHeapSort(new List<int>(numbers), SortDirection.Ascending);
                stopwatch.Stop();
                totalTime += stopwatch.ElapsedMilliseconds;
            }

            return totalTime / iterations;
        }
        private static double BenchmarkLinqSort(List<int> numbers, int iterations)
        {
            var _sortingService = new SortingService();
           
            var totalTime = 0.0;

            for (int i = 0; i < iterations; i++)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                _sortingService.SortNumbersLinq(new List<int>(numbers), SortDirection.Ascending);
                stopwatch.Stop();
                totalTime += stopwatch.ElapsedMilliseconds;
            }

            return totalTime / iterations;
        }
    }
}

