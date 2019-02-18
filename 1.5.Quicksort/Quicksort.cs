using System;
using System.Linq;


class Quicksort
{

    static void Quick(int[] arr,int beginIndex,int endIndex)
    {
        if (beginIndex<endIndex)
        {
            int mid = Partition(arr, beginIndex, endIndex);
            Quick(arr, beginIndex,mid - 1);
            Quick(arr, mid + 1, endIndex);
        }
    }

    static int Partition(int[] arr, int beginIndex,int endIndex)
    {
        int x = arr[endIndex];
        int i = beginIndex - 1;
        int temp;
        for (int j = beginIndex; j <= endIndex-1; j++)
        {
            if (arr[j]<x)
            {
                i++;
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

        }
        temp = arr[i+1];
        arr[i+1] = arr[endIndex];
        arr[endIndex] = temp;
        return i + 1;
    }

    static void Main()
    {
        int[] arr = new int[] { 5, 2, 9, 4, 7, 11, 3, 6, 1 };
        Quick(arr,0,arr.Length-1);
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
    }
}
