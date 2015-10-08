using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Problem5_SlicingFile
{
    class Problem5_SlicingFile
    {
        static void Main(string[] args)
        {
            Console.Write("Available operations:\n\t1. Slice \n\t2. Assemble\n-------------\nMake your choice and press enter: ");
            switch(Console.ReadLine().Trim())
            {
                case "1":
                  Console.WriteLine("Please give me the path to the file: ");
                  string sourceFilePath = Console.ReadLine();
                  Console.WriteLine("Now I want from you to give me the destination directory: ");
                  string destinationDir = Console.ReadLine();
                  Console.WriteLine("Finally, please tell me on how many parts you want to slice the file: ");
                  int sliceToParts = int.Parse(Console.ReadLine());

                  Slice(sourceFilePath,destinationDir,sliceToParts);
                  break;
                case "2":
                  List<string> filesToAssemble = new List<string>();
                  Console.WriteLine("On the next few lines, you must type the paths to the files you want to assemble:");
                  string input = "";
                  while (!String.IsNullOrEmpty(input = Console.ReadLine()))
                  {
                      filesToAssemble.Add(input);
                  }
                  Console.WriteLine("On the next line you must specify output directory for the assembled file:");
                  string destinDir = Console.ReadLine();
                  Assemble(filesToAssemble, destinDir);                  
                  break;
                default:
                  break;
            }
           
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            int partsCounter = 0;
            int dotPosition = sourceFile.LastIndexOf('.');
            int slashPosition = sourceFile.LastIndexOf('\\'); 
            string sourceFileName = sourceFile.Substring(slashPosition+1,dotPosition-slashPosition-1);
            string sourceFileExtension = sourceFile.Substring(dotPosition);
            if (destinationDirectory.LastIndexOf('\\')!=destinationDirectory.Length-1)
	        {
		      destinationDirectory+="\\";
	        }
           
            using (FileStream source = new FileStream(sourceFile,FileMode.Open,FileAccess.ReadWrite))
            {
                long partSize = source.Length/parts;
                while (partsCounter < parts)
                {
                    source.Position = partsCounter * partSize;
                    using (FileStream destination = new FileStream(destinationDirectory + sourceFileName + "-part" + partsCounter + sourceFileExtension, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        long byteCounter = 0;
                        while (byteCounter<=partSize)
                        {
                            destination.WriteByte((byte)source.ReadByte());
                            byteCounter++;
                        }
                    }
                    partsCounter++;
                }                
            }
            Console.WriteLine("The file was sliced successfully.");
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            if (destinationDirectory.LastIndexOf('\\') != destinationDirectory.Length - 1)
            {
                destinationDirectory += "\\";
            }

            foreach (string filePath in files)
            {
              int dotPosition =  filePath.LastIndexOf('.');
              int slashPosition = filePath.LastIndexOf('\\'); 
              string fileName = filePath.Substring(slashPosition+1,dotPosition-slashPosition-1);
              string fileExtension = filePath.Substring(dotPosition);

              using (FileStream destination = new FileStream(destinationDirectory + fileName.Remove(fileName.IndexOf("-part")) + fileExtension,FileMode.Append,FileAccess.Write),
                                source = new FileStream(filePath,FileMode.Open,FileAccess.Read))
              {
                  source.CopyTo(destination);
              }    
            }
            Console.WriteLine("The file is assembled successfully.");
        }
    }
}
