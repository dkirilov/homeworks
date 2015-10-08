using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem7_DirectoryTraversal
{
    class Problem7_DirectoryTraversal
    {
        static void Main(string[] args)
        {
            DirectoryReport(Console.ReadLine());
        }

        static void DirectoryReport(string dir)
        {
            string[] files = Directory.GetFiles(dir);
            SortedDictionary<string, int> filesExtensions = new SortedDictionary<string, int>();
            for (int i = 0; i < files.Length; i++)
            {
                string fileExt = CutExtension(files[i]);
                if (!filesExtensions.ContainsKey(fileExt))
                {
                    filesExtensions.Add(fileExt,GetExtensionRepetitions(files,fileExt));
                }
            }
            using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\report.txt"))
            {
                writer.WriteLine("Report for the directory \"{0}\"",new DirectoryInfo(dir).FullName);
                writer.WriteLine("----------------------------\r\n");
                foreach (var item in filesExtensions.OrderByDescending(a => a.Value))
                {
                    writer.WriteLine(item.Key);
                    string[] currentExtensionFiles = files.Select(a => a).Where(a => CutExtension(a).Equals(item.Key)).ToArray();

                    long fileSize = 0;
                    foreach (string f in currentExtensionFiles.OrderBy(a => new FileInfo(a).Length))
                    {
                        fileSize = new FileInfo(f).Length;
                        writer.WriteLine("--{0} - {1:F2}kb", f.Substring(f.LastIndexOf('\\') + 1), fileSize / 1024d);
                    }
                }
            }
            Console.WriteLine("The report was generated successfully. You can find it in your Desktop folder.");
        }

        static int GetExtensionRepetitions(string[] files,string extension)
        {
            return files.Count(a=>CutExtension(a).Equals(extension));
        }

        static string CutExtension(string file)
        {
            return file.Substring(file.LastIndexOf('.'));
        }
    }
}
