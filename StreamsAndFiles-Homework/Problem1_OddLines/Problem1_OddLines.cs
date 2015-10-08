using System;
using System.IO;

namespace Problem1_OddLines
{
    class Problem1_OddLines
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("..\\..\\textfile.txt");
            using(reader)
            {
                uint lineNumber = 0;
                string line = reader.ReadLine();
                while (line!=null)
                {
                    lineNumber++;
                    if (lineNumber%2==1)
                    {
                        Console.WriteLine("Line {0}: {1}",lineNumber,line);
                    }
                    line = reader.ReadLine();
                }
            }
            reader.Close();
        }
    }
}
