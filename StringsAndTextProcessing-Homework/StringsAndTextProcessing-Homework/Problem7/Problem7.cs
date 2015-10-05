using System;

namespace Problem7
{
    class Problem7 // Letters Change Numbers
    {
        static void Main(string[] args)
        {
            string[] sequence = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            double sum = 0;
            double number = 0;

            foreach (string aString in sequence)
            {
                number = double.Parse(aString.Substring(1, aString.Length - 2));

                if (IsUpper(aString[0]))
                {
                    number /= (alphabet.ToUpper().IndexOf(aString[0]) + 1);
                }
                else
                {
                    number *= (alphabet.IndexOf(aString[0]) + 1);
                }

                if (IsUpper(aString[aString.Length - 1]))
                {
                    number -= (alphabet.ToUpper().IndexOf(aString[aString.Length - 1]) + 1);
                }
                else
                {
                    number += (alphabet.IndexOf(aString[aString.Length - 1]) + 1);
                }
                sum += number;
            }
            Console.WriteLine("{0:F2}", sum);
        }

        static bool IsUpper(char letter)
        {
            string letterAsString = letter.ToString();
            return (letterAsString).Equals(letterAsString.ToUpper());
        }
    }
}
