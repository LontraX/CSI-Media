using CSI_Media.Models;
using CSI_Media.Models.DTOs;
using System.Diagnostics;

namespace CSI_Media.Services
{
    public class SortingService : ISortingService
    {
        public List<int> SortNumbersLinq(List<int> numbers, SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
            {
                return numbers.OrderBy(n => n).ToList();
            }
            else
            {
                return numbers.OrderByDescending(n => n).ToList();
            }
        }

        public List<int> SortNumbersQuickSort(List<int> numbers, SortDirection sortDirection)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            var pivot = numbers[0];
            var left = new List<int>();
            var right = new List<int>();

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] < pivot)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            var sortedLeft = SortNumbersQuickSort(left, sortDirection);
            var sortedRight = SortNumbersQuickSort(right, sortDirection);

            if (sortDirection == SortDirection.Ascending)
            {
                return sortedLeft.Concat(new List<int> { pivot }).Concat(sortedRight).ToList();
            }
            else
            {
                return sortedRight.Concat(new List<int> { pivot }).Concat(sortedLeft).ToList();
            }
        }

        public List<int> SortNumbersMergeSort(List<int> numbers, SortDirection sortDirection)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            var mid = numbers.Count / 2;
            var left = numbers.Take(mid).ToList();
            var right = numbers.Skip(mid).ToList();

            var sortedLeft = SortNumbersMergeSort(left, sortDirection);
            var sortedRight = SortNumbersMergeSort(right, sortDirection);

            return MergeLists(sortedLeft, sortedRight, sortDirection);
        }

        private List<int> MergeLists(List<int> left, List<int> right, SortDirection sortDirection)
        {
            var mergedList = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (sortDirection == SortDirection.Ascending)
                {
                    if (left[leftIndex] <= right[rightIndex])
                    {
                        mergedList.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        mergedList.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
                else
                {
                    if (left[leftIndex] >= right[rightIndex])
                    {
                        mergedList.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        mergedList.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
            }

            mergedList.AddRange(left.Skip(leftIndex));
            mergedList.AddRange(right.Skip(rightIndex));

            return mergedList;
        }

        public List<int> SortNumbersHeapSort(List<int> numbers, SortDirection sortDirection)
        {
            var heap = new List<int>(numbers);
            BuildMaxHeap(heap);

            for (int i = numbers.Count - 1; i > 0; i--)
            {
                Swap(heap, 0, i);
                Heapify(heap, 0, i);
            }

            if (sortDirection == SortDirection.Descending)
            {
                heap.Reverse();
            }

            return heap;
        }

        private void BuildMaxHeap(List<int> heap)
        {
            for (int i = heap.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(heap, i, heap.Count);
            }
        }

        private void Heapify(List<int> heap, int index, int heapSize)
        {
            var largest = index;
            var left = 2 * index + 1;
            var right = 2 * index + 2;

            // Check if left child is larger than root
            if (left < heapSize && heap[left] > heap[largest])
            {
                largest = left;
            }

            // Check if right child is larger than largest so far
            if (right < heapSize && heap[right] > heap[largest])
            {
                largest = right;
            }

            // Swap if largest is not root
            if (largest != index)
            {
                Swap(heap, index, largest);
                Heapify(heap, largest, heapSize);
            }
        }

        private void Swap(List<int> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public SortJobResponseDTO SortNumber(List<int> numbers, SortDirection sortDirection)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var sortedList = SortNumbersHeapSort(new List<int>(numbers), sortDirection);
            stopwatch.Stop();
            return new SortJobResponseDTO{ 
                Numbers = string.Join(",", sortedList), 
                SortDirection = sortDirection,
                TimeTaken = stopwatch.Elapsed,
                Timestamp = DateTime.Now
            };
        }
    }
}
