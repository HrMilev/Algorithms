using System;
using System.Linq;

class InsertionSort
{
    static void GetInsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j>=0 && arr[j]>key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j+1] = key;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Insert count of numbers: ");
        int count = int.Parse(Console.ReadLine());
        Console.WriteLine("Insert the numbers: ");
        string numberSequence = Console.ReadLine();
        int[] numbers = numberSequence.Split(' ').Select(x=>int.Parse(x)).ToArray();
        GetInsertionSort(numbers);
        foreach (var num in numbers)
        {
            Console.Write(num + " ");
        }
    }
}
