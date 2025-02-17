using System;
using System.Collections.Generic;

public class Solution
{
    private static long Factorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    private static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private static long CalculateRooks(int n, int k)
    {
        if (k == 0)
        {
            return 1;
        }

        long result = 1;
        long denominator = 1;

        for (int i = 0; i < k; i++)
        {
            long term = (n - i) * (n - i);
            result *= term;
            denominator *= (i + 1);

            long gcd = GCD(result, denominator);
            result /= gcd;
            denominator /= gcd;
        }

        result *= Factorial(k);
        return result;
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<(int, int)> cases = new List<(int, int)>();
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(" ");
            int a = int.Parse(tokens[0]);
            int b = int.Parse(tokens[1]);
            cases.Add((a, b));
        }

        for (int i = 0; i < n; i++)
        {
            int a = cases[i].Item1;
            int b = cases[i].Item2;

            long result = CalculateRooks(a, b);
            Console.WriteLine($"Case {i + 1}: {result}");
        }
    }
}