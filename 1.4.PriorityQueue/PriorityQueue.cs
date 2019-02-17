using System;
using System.Linq;

class PriorityQueue
{
    static int GetParent(int i)
    {
        return (int)Math.Ceiling((double)(i >> 1)) - 1;
    }
    static int GetLeft(int i)
    {
        return (i << 1) + 1;
    }
    static int GetRight(int i)
    {
        return (i << 1) + 2;
    }
    static void MaxHeapify(int[] arr, int index, int heapSize)
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
        if (largest != index)
        {
            int temp = arr[index];
            arr[index] = arr[largest];
            arr[largest] = temp;
            MaxHeapify(arr, largest, heapSize);
        }
    }

    static void BuildHeap(int[] arr)
    {
        for (int i = arr.Length / 2 - 1; i >= 0; i--)
        {
            MaxHeapify(arr, i, arr.Length);
        }
    }

    static int HeapExtractMax(ref int[] arr)
    {
        if (arr.Length<1)
        {
            throw new Exception();
        }

        int max = arr[0];
        arr[0] = arr[arr.Length - 1];
        Array.Resize(ref arr, arr.Length - 1);
        MaxHeapify(arr, 0, arr.Length);
        return max;
    }

    static void HeapIncreaseKey(int[] arr,int index,int newKey)
    {
        if (newKey< arr[index])
        {
            throw new Exception();
        }
        arr[index] = newKey;

        BuildHeap(arr);
    }

    static int HeapMaximum(int[] arr)
    {
        return arr[0];
    }
    
    static void MaxHeapInsert(ref int[] arr, int key)
    {
        Array.Resize(ref arr, arr.Length + 1);
        HeapIncreaseKey(arr, arr.Length-1, key);
    }

    static void Main()
    {
        int[] heap = new[] { 4,1,3,2,16,9,10,14,8,7};
        BuildHeap(heap);
        foreach (var item in heap)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        HeapIncreaseKey(heap, 5, 11);
        foreach (var item in heap)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        MaxHeapInsert(ref heap, 15);
        foreach (var item in heap)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        HeapExtractMax(ref heap);
        foreach (var item in heap)
        {
            Console.Write(item + " ");
        }

    }
}
