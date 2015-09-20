using System;
using System.Collections.Generic;

namespace Problem5
{
    class Problem5
    {
        static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
           
            int prevNumber = numbers[0];
            List<int> sequence = new List<int>();
            List<int> longestSequence = new List<int>();
            
            for (int i = 0; i < numbers.Length; i++)
            {
                if (prevNumber<numbers[i])
                {
                    sequence.Add(numbers[i]);
                    Console.Write("{0} ",numbers[i]);
                }
                else
                {
                    sequence.Clear();
                    Console.Write("\n{0} ",numbers[i]);
                    sequence.Add(numbers[i]);
                }
                if (sequence.Count > longestSequence.Count)
                {
                    longestSequence.Clear();
                    longestSequence.AddRange(sequence);
                }
                prevNumber = numbers[i];
            }

            Console.WriteLine("\nLongest: {0}",string.Join(" ",longestSequence.ToArray()));
        }
    }
}
