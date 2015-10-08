using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem3_WordCount
{
    class Problem3_WordCount
    {
        static void Main(string[] args)
        {
            using (StreamReader reader1 = new StreamReader("..\\..\\words.txt"),
                                reader2 = new StreamReader("..\\..\\text.txt"))
            {
                using(StreamWriter writer = new StreamWriter("..\\..\\result.txt"))
                {
                    StringBuilder text = new StringBuilder();
                    while (!reader2.EndOfStream)
                    {
                        text.Append(reader2.ReadLine());
                    }

                    string word = reader1.ReadLine();
                    uint repetitions = 0;
                    SortedDictionary<string, uint> words = new SortedDictionary<string, uint>();                   
                    while (word!=null)
                    {
                        repetitions = GetRepetitions(word,text.ToString());
                        words.Add(word,repetitions);
                        word = reader1.ReadLine();
                    }

                    foreach (var item in words.OrderByDescending(item => item.Value))
                    {
                        writer.WriteLine("{0} - {1}",item.Key,item.Value);
                    }
                }
            }
        }

        static uint GetRepetitions(string search, string text)
        {
            string pattern = "\\b"+search+"\\b";
            Regex regex = new Regex(pattern,RegexOptions.IgnoreCase);
            return (uint)regex.Matches(text).Count;
        }
    }
}
