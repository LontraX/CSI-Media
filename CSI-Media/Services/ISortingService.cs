using CSI_Media.Models;
using CSI_Media.Models.DTOs;

namespace CSI_Media.Services
{
    public interface ISortingService
    {

        List<int> SortNumbersLinq(List<int> numbers, SortDirection sortDirection);
        List<int> SortNumbersQuickSort(List<int> numbers, SortDirection sortDirection);
        List<int> SortNumbersMergeSort(List<int> numbers, SortDirection sortDirection);
        List<int> SortNumbersHeapSort(List<int> numbers, SortDirection sortDirection);
        SortJobResponseDTO SortNumber(List<int> numbers, SortDirection sortDirection);



    }
}
