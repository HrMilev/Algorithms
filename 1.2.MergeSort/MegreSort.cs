using System;
using System.Linq;

class MergeSort
{

    static void Merge(int[] arr, int first, int mid, int last)
    {
        int leftCount = mid - first + 1;
        int rightCount = last - mid;
        int[] leftArr = new int[leftCount];
        int[] rightArr = new int[rightCount];

        for (int i = 0; i < leftArr.Length; i++)
            leftArr[i] = arr[first - 1 + i];

        for (int i = 0; i < rightArr.Length; i++)
            rightArr[i] = arr[mid + i];

        int leftCurrent = 0;
        int rightCurrent = 0;
        for (int i = first-1; i < last; i++)
        {
            if (leftCurrent == leftArr.Length)
            {
                arr[i] = rightArr[rightCurrent];
                rightCurrent++;
            }
            else if (rightCurrent == rightArr.Length)
            {
                arr[i] = leftArr[leftCurrent];
                leftCurrent++;
            }
            else if (leftArr[leftCurrent]<=rightArr[rightCurrent])
            {
                arr[i] = leftArr[leftCurrent];
                leftCurrent++;
            }
            else
            {
                arr[i] = rightArr[rightCurrent];
                rightCurrent++;
            }
        }
    }

    static void GetMergeSort(int[] arr, int first, int last)
    {
        if (first<last)
        {
            int mid = (first + last) / 2;
            GetMergeSort(arr, first, mid);
            GetMergeSort(arr, mid + 1, last);

            Merge(arr, first, mid,last);
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Insert count of numbers: ");
        int count = int.Parse(Console.ReadLine());
        Console.WriteLine("Insert the numbers: ");
        string numberSequence = Console.ReadLine();
        int[] numbers = numberSequence.Split(' ').Select(x=>int.Parse(x)).ToArray();
        GetMergeSort(numbers,1,numbers.Length);
        foreach (var num in numbers)
        {
            Console.Write(num + " ");
        }
    }
}
