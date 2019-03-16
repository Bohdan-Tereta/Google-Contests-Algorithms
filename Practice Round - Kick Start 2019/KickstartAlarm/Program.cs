using System;
using System.Collections.Generic;
using System.Linq;

namespace KickstartAlarm
{
    class Program
    {
        public static long mod = 1000000007;

        //This is the fastest implementation
        public static long CalculatePowers4(int N, long K, List<long> A)
        {
            long result = 0;
            long pMult = 0;
            for (int L = N - 1; L >= 0; L--)
            {
                pMult += Multiply(A[L], (N - L));
                long p = L + 1;
                long geomProgrMult = (((p > 1) ? ModGeometricProgressionSum(p, K) : K));
                result = result + Multiply(pMult, geomProgrMult);
                result %= mod;
            }
            return result;
        }

        private static long ModGeometricProgressionSum(long a, long b)
        {
            //As we don't have modular division, we use modular inverse ( if m is prime it's a^(m-2) mod m)
            return Multiply(Multiply(a, ModPower(a, b) - 1 + mod), ModPower(a - 1, mod - 2));
        }

        private static long Multiply(long a, long b)
        {
            if (a >= mod)
                a %= mod;

            if (b >= mod)
                b %= mod;

            return (a * b) % mod;
        }

        private static long ModPower(long a, long b)
        {
            long aa = 1;

            while (b > 0)
            {
                if ((b & 1) == 1)
                    aa = Multiply(aa, a);
                b >>= 1;
                a = Multiply(a, a);
            }

            return aa;
        }

        //Brute-force approach
        private static double CalculatePowers0(int N, long K, List<long> A)
        {
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
                            result %= mod;
                        }
                    }
                }
            }

            return result;
        }

        //Slightly better than CalculatePowers0
        private static double CalculatePowers1(long N, long K, List<long> A)
        {
            double result = 0;

            for (int L = 0; L < N; L++)
            {
                for (int R = L; R < N; R++)
                {
                    for (int j = L; j <= R; j++)
                    {
                        int p = j - L + 1;
                        result = result + A[j] * (((p > 1) ? (p * (Math.Pow(p, K) - 1) / (p - 1)) : K));
                        result %= mod;
                    }
                }
            }

            return result;
        }

        //Slightly better than CalculatePowers1
        private static double CalculatePowers2(int N, long K, List<long> A)
        {
            double result = 0;
            for (int L = 0; L < N; L++)
            {
                for (int j = 0; j <= L; j++)
                {
                    int p = j + 1;
                    double geomProgrMult = (((p > 1) ? (p * (Math.Pow(p, K) - 1) / (p - 1)) : K));
                    result = result + A[L] * geomProgrMult * (N - L);
                    result %= mod;
                }
            }
            return result;
        }

        //Slightly bettert than CalculatePowers2
        private static double CalculatePowers3(int N, long K, List<long> A)
        {
            double result = 0;
            double pMult = 0;
            for (int L = N - 1; L >= 0; L--)
            {
                pMult += A[L] * (N - L);
                int p = L + 1;
                double geomProgrMult = (((p > 1) ? (p * (Math.Pow(p, K) - 1) / (p - 1)) : K));
                result = result + pMult * geomProgrMult;
                result %= mod;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                int N = tokens[0];
                long K = tokens[1];
                long x1 = tokens[2];
                long y1 = tokens[3];
                long C = tokens[4];
                long D = tokens[5];
                long E1 = tokens[6];
                long E2 = tokens[7];
                long F = tokens[8];

                List<long> x = new List<long>(N);
                List<long> y = new List<long>(N);
                List<long> A = new List<long>(N);

                x.Add(x1);
                y.Add(y1);
                A.Add((x[0] + y[0]) % F);
                for (int j = 1; j < N; j++)
                {
                    x.Add((C * x[j - 1] + D * y[j - 1] + E1) % F);
                    y.Add((D * x[j - 1] + C * y[j - 1] + E2) % F);
                    A.Add((x[j] + y[j]) % F);
                }

                long result = CalculatePowers4(N, K, A);
                Console.WriteLine($"Case #{i + 1}: {result}");
            }
        }
    }
}
