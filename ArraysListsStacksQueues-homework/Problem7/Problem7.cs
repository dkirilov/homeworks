using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem7
{
    class Problem7
    {
        static void Main(string[] args)
        {
            int sumLimit = int.Parse(Console.ReadLine());
            string[] strNumbers = Console.ReadLine().Split(' ');
            List<int> numbers = new List<int>();

            foreach (string strNumber in strNumbers)
            {
                int number = int.Parse(strNumber);
                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }

            int numberOfSubsets = (int)Math.Pow(2, numbers.Count);
            bool noMatchingSubsets = true;
            List<int> subset = new List<int>();
            List<int[]> subsets = new List<int[]>();

            for (int i = 0, subsetSum = 0, mask = 0, bit = 0; i < numberOfSubsets; i++)
            {
                for (int j = 0; j < numbers.Count; j++) // extracts one subset
                {
                    mask = (int)Math.Pow(2, j);
                    bit = (mask & i) >> j;
                    if (bit == 1)
                        subset.Add(numbers[j]);
                }
                subsetSum = subset.Sum();
                if (subsetSum == sumLimit && subset.Count > 0)
                {
                    subset.Sort();
                    subsets.Add(subset.ToArray());
                    if (noMatchingSubsets)
                        noMatchingSubsets = false;
                }
                subset.Clear();
            }            

            if (noMatchingSubsets)
            {
                Console.WriteLine("No matching subsets.");
            }
            else
            {
                
                for (int i = 0; i < subsets.Count; i++) // Sorting the list of subsets using Selection sort algorithm
                {
                    for (int j = 0; j < subsets.Count; j++)
                    {
                        if ((subsets[i].Length < subsets[j].Length) || (subsets[i].Length == subsets[j].Length && subsets[i].Min() < subsets[j].Min()))
                        {
                            int[] tmp = subsets[j];
                            subsets[j] = subsets[i];
                            subsets[i] = tmp;
                        }
                    }
                }

                subsets.ForEach(s => Console.WriteLine("{0} = {1}",string.Join(" + ",s), sumLimit));
            }
        }
    }
}
