using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6
{
    class Problem6
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

            int numberOfSubsets = (int)Math.Pow(2,numbers.Count); 
            bool noMatchingSubsets = true;
            List<int> subset = new List<int>();

            for (int i = 0,subsetSum=0,mask=0,bit=0; i < numberOfSubsets; i++)
            {
                for (int j = 0; j < numbers.Count; j++) // extracts one subset
                {
                    mask = (int)Math.Pow(2,j);
                    bit = (mask & i) >> j;
                    if (bit == 1)
                        subset.Add(numbers[j]);
                }
                subsetSum = subset.Sum();
                if (subsetSum==sumLimit && subset.Count>0)
                {
                    Console.WriteLine("{0} = {1}",string.Join(" + ",subset.ToArray()),subsetSum);
                    if (noMatchingSubsets)
                      noMatchingSubsets = false;                    
                }
                subset.Clear();
            }

            if (noMatchingSubsets)
            {
                Console.WriteLine("No matching subsets.");
            }
        }
    }
}
