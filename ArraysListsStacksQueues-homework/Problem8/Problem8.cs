using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem8
{
    class Problem8
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            int[][] first = new int[n][];
            int[][] second = new int[n][];
            
            for (int i = 0; i < n; i++)
            {
                first[i] =  Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            }
            for (int i = 0; i < n; i++)
            {
                second[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            }

            int[] lengths = new int[n];
            for (int i = 0; i < n; i++)
            {
                lengths[i] = first[i].Length + second[i].Length;
            }
            for (int i = 1; i < lengths.Length; i++)
            {
                if (lengths[i - 1] != lengths[i]) // Checks whether the arrays fit
                {
                    Console.WriteLine("The total number of cells is: {0}",lengths.Sum());
                    return;
                }
            }

            for (int i = 0; i < n; i++) //Reverse second array
            {
                int[] reversed = new int[second[i].Length];
                for (int j = 0, k = second[i].Length - 1; j < second[i].Length; j++, k--)
                {
                    reversed[j] = second[i][k];
                }
                second[i] = reversed;
            }

            for (int i = 0; i < n; i++) // Print the arrays
            {
                Console.WriteLine("[" + string.Join(", ", first[i]) + ", " + string.Join(", ", second[i]) + "]");
            }
        }
    }
}
