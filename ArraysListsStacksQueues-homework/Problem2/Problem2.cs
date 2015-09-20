using System;

namespace Problem2
{
    class Problem2
    {
        static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int tmp = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        tmp = numbers[j];
                        numbers[j] = numbers[i];
                        numbers[i] = tmp;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
