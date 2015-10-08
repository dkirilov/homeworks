using System;
using System.IO;

namespace Problem2_LineNumbers
{
    class Problem2_LineNumbers
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("..\\..\\textfile.txt"))
            {
                using (var writer = new StreamWriter("..\\..\\textfile_with_line_numbers.txt"))
                {
                    uint lineNumber = 0;
                    string line = reader.ReadLine();
                    while (line!=null)
                    {
                        lineNumber++;
                        writer.WriteLine("{0}. {1}",lineNumber,line);
                        line = reader.ReadLine();
                    }
                }                
            }
        }
    }
}
