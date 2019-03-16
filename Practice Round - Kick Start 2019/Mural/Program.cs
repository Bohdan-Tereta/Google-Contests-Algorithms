using System;
using System.Linq;

namespace CodeJamTest
{

    class Program
    {
        public static int MaxSum(int[] arr, int k)
        {
            int n = arr.Length;

            // k must be greater 
            if (n < k)
            {
                Console.Write("Invalid");
                return int.MinValue;
            }

            // Compute sum of first window of size k 
            int res = 0;
            for (int i = 0; i < k; i++)
                res += arr[i];

            // Compute sums of remaining windows by 
            // removing first element of previous 
            // window and adding last element of  
            // current window. 
            int curr_sum = res;
            for (int i = k; i < n; i++)
            {
                curr_sum += arr[i] - arr[i - k];
                res = Math.Max(res, curr_sum);
            }

            return res;
        }

        static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int[] array = Console.ReadLine().ToCharArray().Select(e => (int)Char.GetNumericValue(e)).ToArray();
                int k = (int)Math.Ceiling((double)(array.Length) / 2);
                Console.WriteLine($"Case #{i+1}: {MaxSum(array, k)}");
            }
        }
    }
}
