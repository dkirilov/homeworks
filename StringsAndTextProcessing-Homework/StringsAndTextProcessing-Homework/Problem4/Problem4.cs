using System;

namespace Problem4
{
    class Problem4 //Problem 4.	Text Filter
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(',');            
            string text = Console.ReadLine();

            foreach ( string word in bannedWords)
            {
                text = text.Replace(word.Trim(),"".PadLeft(word.Trim().Length,'*'));
            }
            Console.WriteLine("\n{0}",text);
        }
    }
}
