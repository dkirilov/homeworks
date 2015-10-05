using System;

namespace Problem3
{
    class Problem3 //Problem 3.	Count Substring Occurrences
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToUpper();
            string searchString = Console.ReadLine().ToUpper();

            int count = 0;
            int lastIndex = 0;
            while((lastIndex = text.IndexOf(searchString,lastIndex))!=-1)
            {
                count++;
                lastIndex++;
            }
            Console.WriteLine(count);
        }
    }
}
