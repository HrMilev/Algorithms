using System;
using System.Linq;

class Heapsort
{
    static int GetParent(int i)
    {
        return (int)Math.Ceiling((double)(i >>1)) -1;
    }
    static int GetLeft(int i)
    {
        return (i << 1) + 1;
    }
    static int GetRight(int i)
    {
        return (i << 1) + 2;
    }
    static void MaxHeapify(int[] arr,int index,int heapSize)
    {
        int l = GetLeft(index);
        int r = GetRight(index);
        int largest = int.MinValue;
        if (l < heapSize && arr[l] > arr[index])
            largest = l;
        else
            largest = index;
        if (r < heapSize && arr[r] > arr[largest])
            largest = r;
        if (largest!=index)
        {
            int temp = arr[index];
            arr[index] = arr[largest];
            arr[largest] = temp;
            MaxHeapify(arr, largest,heapSize);
        }
    }

    static void BuildHeap(int[] arr)
    {
        for (int i = arr.Length/2-1; i >= 0; i--)
        {
            MaxHeapify(arr, i, arr.Length);
        }
    }

    static void MaxHeapsort(int[] arr)
    {
        BuildHeap(arr);
        for (int i = arr.Length-1; i > 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;
            MaxHeapify(arr, 0,i);
        }
    }

    static void Main()
    {
        int[] heap = new[] { 4,1,3,2,16,9,10,14,8,7};
        MaxHeapsort(heap);
        foreach (var item in heap)
        {
            Console.Write(item + " ");
        }
    }
}
