using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem8_FullDirectoryTraversal
{
    class Problem8_FullDirectoryTraversal
    {
        static void Main(string[] args)
        {
            DirectoryReport(Console.ReadLine());
        }

        public static int dirCounter = 0;
        public static string[] subDirs;
        public static StringBuilder report = new StringBuilder();
        static void DirectoryReport(string dir)
        {
            string[] files = Directory.GetFiles(dir);
            SortedDictionary<string, int> filesExtensions = new SortedDictionary<string, int>();
            for (int i = 0; i < files.Length; i++)
            {
                string fileExt = CutExtension(files[i]);
                if (!filesExtensions.ContainsKey(fileExt))
                {
                    filesExtensions.Add(fileExt, GetExtensionRepetitions(files, fileExt));
                }
            }

            report.Append(String.Format("\r\nReport for the directory \"{0}\"", new DirectoryInfo(dir).FullName));
            report.Append("\r\n----------------------------");
            foreach (var item in filesExtensions.OrderByDescending(a => a.Value))
            {
                report.Append("\r\n"+item.Key);
                string[] currentExtensionFiles = files.Select(a => a).Where(a => CutExtension(a).Equals(item.Key)).ToArray();

                long fileSize = 0;
                foreach (string f in currentExtensionFiles.OrderBy(a => new FileInfo(a).Length))
                {
                    fileSize = new FileInfo(f).Length;
                    report.Append(String.Format("\r\n--{0} - {1:F2}kb", f.Substring(f.LastIndexOf('\\') + 1), fileSize / 1024d));
                }
                report.Append("\r\n");
            }

            if (dirCounter==0)
            {
                subDirs = Directory.GetDirectories(dir);
            }
            
            if(dirCounter == subDirs.Length)
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt"))
                {
                    writer.WriteLine(report.ToString());
                }
                return;
            }
            
            if(dirCounter<subDirs.Length)
            {
                DirectoryReport(subDirs[dirCounter]);
                dirCounter++;
            }
            
        }

        static int GetExtensionRepetitions(string[] files, string extension)
        {
            return files.Count(a => CutExtension(a).Equals(extension));
        }

        static string CutExtension(string file)
        {
            return file.Substring(file.LastIndexOf('.'));
        }
    }
}
