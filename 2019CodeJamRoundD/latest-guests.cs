using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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
                int N = tokens[0];
                int G = tokens[1];
                int M = tokens[2];
                int[] H = new int[G];
                List<bool> C = new List<bool>();
                List<List<int>> na = new List<List<int>>(N);
                for (int k = 0; k < N; k++)
                {
                    na.Add(new List<int>())  ;
                }

                for (int g = 0; g < G; g++)
                {
                    string[] tmp = Console.ReadLine().Split(' ');
                    H[g] = (int.Parse(tmp[0]))-1;
                    C.Add(tmp[1] == "C");
                    na[H[g]].Add(g);

                }
                long[] H2 = new long[G];

                for (long m = 0; m < M; m++)
                {
                    bool[] visited = new bool[N];
                    for (int g = 0; g < G; g++)
                    {
                        if (C[g])
                        {

                            H[g] = (H[g] + 1) % N;
                            if (visited[H[g]]){
                                na[H[g]].Add(g);
                            } else
                            {
                                na[H[g]] = new List<int>() { g };
                                visited[H[g]] = true;
                            }
                        }
                        else
                        {
                            H[g] = H[g]== 0?N-1:(H[g] - 1) % N;
                            if (visited[H[g]])
                            {
                                na[H[g]].Add(g);
                            }
                            else
                            {
                                visited[H[g]] = true;
                                na[H[g]] = new List<int>() { g };
                            }
                        }
                    }
                }

                StringBuilder sb = new StringBuilder();
                sb.Append($"Case #{i + 1}: ");
                for (int g = 0; g < G; g++)
                {
                    sb.Append($"{na.Where(l => l.Contains(g)).Count()} ");
                }
                sb.Remove(sb.Length - 1, 1);


                Console.WriteLine(sb);
            }
        }
    }
}
