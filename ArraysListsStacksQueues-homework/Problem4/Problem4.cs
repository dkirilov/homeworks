using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4
{
    class Problem4
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ');
            string prevString = strings[0];

            for (int i = 0; i < strings.Length; i++)
            {
                if (!strings[i].Equals(prevString))
                {
                    Console.WriteLine();
                }
                Console.Write("{0} ",strings[i]);
                prevString = strings[i];
            }
            Console.WriteLine();
        }
    }
}
