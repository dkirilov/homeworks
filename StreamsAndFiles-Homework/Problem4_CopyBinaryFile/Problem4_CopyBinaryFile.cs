using System.IO;

namespace Problem4_CopyBinaryFile
{
    class Problem4_CopyBinaryFile
    {
        static void Main(string[] args)
        {
            using (FileStream filestream1 = new FileStream("..\\..\\temple.png",FileMode.Open,FileAccess.Read),
                              filestream2 = new FileStream("..\\..\\temple_copy.png",FileMode.OpenOrCreate,FileAccess.Write))
            {
                filestream1.CopyTo(filestream2);
            }
        }
    }
}
