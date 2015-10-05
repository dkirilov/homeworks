using System;
using System.Collections.Generic;
using System.Text;

namespace Problem6
{
    class Problem6 // Problem 6.Palindromes
    {
        static void Main(string[] args)
        {
            string[] splittedInputText = Console.ReadLine().Split(new []{' ','?','!',',','.'},StringSplitOptions.RemoveEmptyEntries);

            List<string> listOfUniquePalindromes = new List<string>();
            foreach (string word in splittedInputText)
            {
                if (word.Equals(Reverse(word)) && !listOfUniquePalindromes.Contains(word))
                {
                    listOfUniquePalindromes.Add(word);
                }
            }
            listOfUniquePalindromes.Sort();
            Console.WriteLine(string.Join(",",listOfUniquePalindromes));
        }

        static string Reverse(string str)
        {
            StringBuilder reversedString = new StringBuilder();
            for (int i = str.Length-1; i>=0; i--)
            {
                reversedString.Append(str[i]);
            }
            return reversedString.ToString();
        }
    }
}
