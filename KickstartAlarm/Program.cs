﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace KickstartAlarm
{
    class Program
    {
        public static void BruteForce()
        {
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                int N = tokens[0];
                int K = tokens[1];
                int x1 = tokens[2];
                int y1 = tokens[3];
                int C = tokens[4];
                int D = tokens[5];
                int E1 = tokens[6];
                int E2 = tokens[7];
                int F = tokens[8];

                List<int> x = new List<int>(N);
                List<int> y = new List<int>(N);
                List<int> A = new List<int>(N);

                x.Add(x1);
                y.Add(y1);
                A.Add((x[0] + y[0]) % F);
                for (int j = 1; j < N; j++)
                {
                    x.Add((C * x[j - 1] + D * y[j - 1] + E1) % F);
                    y.Add((D * x[j - 1] + C * y[j - 1] + E2) % F);
                    A.Add((x[j] + y[j]) % F);
                }

                double result = 0;

                for (int k = 0; k < K; k++)
                {
                    for (int L = 0; L < N; L++)
                    {
                        for (int R = L; R < N; R++)
                        {
                            for (int j = L; j <= R; j++)
                            {
                                result = result + A[j] * Math.Pow(j - L + 1, k + 1);
                                result %= 1000000007;
                            }
                        }
                    }
                }
                Console.WriteLine($"Case #{i + 1}: {result}");
            }
        }

        public static double mod = 1000000007;


        public static void Optimized()
        {
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                int N = tokens[0];
                int K = tokens[1];
                int x1 = tokens[2];
                int y1 = tokens[3];
                int C = tokens[4];
                int D = tokens[5];
                int E1 = tokens[6];
                int E2 = tokens[7];
                int F = tokens[8];

                List<int> x = new List<int>(N);
                List<int> y = new List<int>(N);
                List<int> A = new List<int>(N);

                x.Add(x1);
                y.Add(y1);
                A.Add((x[0] + y[0]) % F);
                for (int j = 1; j < N; j++)
                {
                    x.Add((C * x[j - 1] + D * y[j - 1] + E1) % F);
                    y.Add((D * x[j - 1] + C * y[j - 1] + E2) % F);
                    A.Add((x[j] + y[j]) % F);
                }

                double result = 0;

                for (int L = 0; L < N; L++)
                {
                    for (int R = L; R < N; R++)
                    {
                        for (int j = L; j <= R; j++)
                        {
                            int p = j - L + 1;
                            result = result + A[j] * (((p > 1) ? (p * (Math.Pow(p, K) - 1) / (p - 1)) : K));
                            result %= 1000000007;
                        }
                    }
                }
                Console.WriteLine($"Case #{i + 1}: {result}");
            }
        }

        public static void Optimized2()
        {
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                int N = tokens[0];
                int K = tokens[1];
                int x1 = tokens[2];
                int y1 = tokens[3];
                int C = tokens[4];
                int D = tokens[5];
                int E1 = tokens[6];
                int E2 = tokens[7];
                int F = tokens[8];

                List<int> x = new List<int>(N);
                List<int> y = new List<int>(N);
                List<int> A = new List<int>(N);

                x.Add(x1);
                y.Add(y1);
                A.Add((x[0] + y[0]) % F);
                for (int j = 1; j < N; j++)
                {
                    x.Add((C * x[j - 1] + D * y[j - 1] + E1) % F);
                    y.Add((D * x[j - 1] + C * y[j - 1] + E2) % F);
                    A.Add((x[j] + y[j]) % F);
                }

                double result = 0;

                for (int L = 0; L < N; L++)
                {
                    for (int j = 0; j <= L; j++)
                    {
                        int p = j + 1;

                        double geomProgrMult = (((p > 1) ? (p * (Math.Pow(p, K) - 1) / (p - 1)) : K));
                        //Console.WriteLine($"L: {L}, N: {N}, Diff: { N - L}, p: {j + 1}, mult: {geomProgrMult }");
                        //Console.WriteLine(A[j] * geomProgrMult);
                        result = result + A[L] * geomProgrMult * (N - L);
                        result %= 1000000007;
                        //Console.WriteLine(N-j);
                    }
                }
                Console.WriteLine($"Case #{i + 1}: {result}");
            }
        }

        public static void Optimized3()
        {
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                int N = tokens[0];
                int K = tokens[1];
                int x1 = tokens[2];
                int y1 = tokens[3];
                int C = tokens[4];
                int D = tokens[5];
                int E1 = tokens[6];
                int E2 = tokens[7];
                int F = tokens[8];

                List<int> x = new List<int>(N);
                List<int> y = new List<int>(N);
                List<int> A = new List<int>(N);

                x.Add(x1);
                y.Add(y1);
                A.Add((x[0] + y[0]) % F);
                for (int j = 1; j < N; j++)
                {
                    x.Add((C * x[j - 1] + D * y[j - 1] + E1) % F);
                    y.Add((D * x[j - 1] + C * y[j - 1] + E2) % F);
                    A.Add((x[j] + y[j]) % F);
                }

                double result = 0;

                double pMult = 0;
                for (int L = N-1; L >= 0; L--)
                {
                    pMult += A[L] * (N - L);
                        int p = L+1;
                        double geomProgrMult = (((p > 1) ? (p * (Math.Pow(p, K) - 1) / (p - 1)) : K));
                        result = result + pMult * geomProgrMult ;
                        result %= 1000000007;
   
                }
                Console.WriteLine($"Case #{i + 1}: {result}");
            }
        }

        static void Main(string[] args)
        {
            Optimized3();
        }
    }
}
