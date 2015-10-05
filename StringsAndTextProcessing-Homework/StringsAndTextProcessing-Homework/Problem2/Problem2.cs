using System;

namespace Problem2
{
    class Problem2 //Problem 2.	String Length
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            if (text.Length>20)
            {
                Console.WriteLine(text.Substring(0,20));
            }
            else
            {
                int stars = 20 - text.Length;
                Console.Write(text);
                for (int i = 0; i < stars; i++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
