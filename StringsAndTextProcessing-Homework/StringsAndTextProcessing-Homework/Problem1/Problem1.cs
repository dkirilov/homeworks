using System;

namespace Problem1
{
    class Problem1 //Problem 1.	Reverse String
    {
        static void Main(string[] args)
        {
            string someText = Console.ReadLine();
            for (int i = someText.Length-1; i>=0 ; i--)
            {
                Console.Write(someText[i]);
            }
            Console.WriteLine(); 
        }
    }
}
