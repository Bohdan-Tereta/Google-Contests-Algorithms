using System;

namespace CodeJamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                int a = int.Parse(tokens[0]) + 1;
                int b = int.Parse(tokens[1]);
                int n = int.Parse(Console.ReadLine());
                while (n > 0)
                {
                    int guess = (b - a) / 2;
                    Console.WriteLine(guess);
                    string response = Console.ReadLine();
                    if (response == "TOO_BIG")
                    {
                        b = guess - 1;
                    }
                    else if (response == "TOO_SMALL")
                    {
                        a = guess + 1;
                    }
                    else if (response == "CORRECT")
                    {
                        break;
                    }

                    else if (response == "WRONG_ANSWER")
                    {
                        throw new Exception("WRONG_ANSWER");
                    }
                    n--;
                }
            }
        }
    }
}
