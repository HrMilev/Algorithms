using System;
using System.Linq;

class MaxSubarray
{
    static Tuple<int,int,int> FindMaxCrossingSubarray(int[] arr, int first, int mid, int last)
    {
        int leftSum = int.MinValue;
        int sum = 0;
        int maxLeft = 0;
        for (int i = mid; i >= first; i--)
        {
            sum += arr[i];
            if (sum>leftSum)
            {
                leftSum = sum;
                maxLeft = i;
            }
        }
        int rightSum = int.MinValue;
        int maxRight = 0;
        sum = 0;
        for (int i = (mid+1); i <= last; i++)
        {
            sum += arr[i];
            if (sum>rightSum)
            {
                rightSum = sum;
                maxRight = i;
            }
        }
        return new Tuple<int, int, int>(maxLeft, maxRight, (leftSum + rightSum));
    }

    static Tuple<int,int,int> FindMaxSubarray(int[] arr, int first, int last)
    {
        if (first == last)
        {
            return new Tuple<int, int, int>(first, last, arr[first]);
        }
        else
        {
            int mid = (first + last) / 2;
            Tuple<int, int, int> left = FindMaxSubarray(arr, first, mid);
            Tuple<int, int, int> right = FindMaxSubarray(arr, mid + 1, last);
            Tuple<int, int, int> cross = FindMaxCrossingSubarray(arr, first, mid, last);
            if (left.Item3>=right.Item3 && left.Item3>=cross.Item3)
            {
                return left;
            }
            else if (left.Item3 <= right.Item3 && right.Item3 >= cross.Item3)
            {
                return right;
            }
            else
            {
                return cross;
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Insert the leght of the array:");
        int count = int.Parse(Console.ReadLine());
        Console.WriteLine("Insert the array:");
        int[] arr = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();
        Tuple<int, int, int> max = FindMaxSubarray(arr, 0, arr.Length - 1);
        Console.WriteLine("Max sum is:");
        Console.WriteLine(max.Item3);
        Console.WriteLine("From element " + (max.Item1+1) + " till element " + (max.Item2+1));
    }
}
