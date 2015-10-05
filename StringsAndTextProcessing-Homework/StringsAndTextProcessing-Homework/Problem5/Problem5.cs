using System;

namespace Problem5
{
    class Problem5 //Problem 5.	Unicode Characters
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            foreach (int symbol in text)
            {
                string unicode = Convert.ToString(symbol,16);
                Console.Write("\\u{0}",unicode.PadLeft(6-unicode.Length,'0'));
            }
            Console.WriteLine();
        }
	}            
}
