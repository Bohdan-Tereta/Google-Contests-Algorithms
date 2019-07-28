using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeJam2019D3
{
    class Program
    {
        static void Main(string[] args)
        {
            long T = long.Parse(Console.ReadLine());
            for (long i = 0; i < T; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                int K = tokens[0];
                int N = tokens[1];
                long[] X = Console.ReadLine().Split(' ').Select(e => long.Parse(e)).ToArray();
                long[] C = Console.ReadLine().Split(' ').Select(e => long.Parse(e)).ToArray();
                SortedSet<long> midDistances = new SortedSet<long>();
                for (long j = 0; j < N; j++)
                {
                    List<long> costDict = new List<long>();
                    for (long k = 0; k < N; k++)
                    {
                        if (k != j)
                        {
                            costDict.Add(C[k] + Math.Abs(X[j] - X[k]));
                        }
                    }
                    List<long> ks = costDict.OrderBy(k => k).Take(K).ToList();
                    midDistances.Add(C[j] + ks.Sum());
                }
                Console.WriteLine($"Case #{i + 1}: {midDistances.Min}");
            }
        }
    }
}
