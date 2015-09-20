using System;

namespace Problem1
{
    class Problem1
    {
        static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);

            int tmp = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j < numbers.Length; j++)
                {
                    if(numbers[j-1]>numbers[j])
                    {
                        tmp = numbers[j];
                        numbers[j] = numbers[j - 1];
                        numbers[j - 1] = tmp;
                    }
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
