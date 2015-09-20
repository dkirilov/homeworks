using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Problem3
    {
        static void Main(string[] args)
        {
            float[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '),float.Parse);

            List<float> zeroFloats = new List<float>();
            List<float> nonZeroFloats = new List<float>();

            foreach(float number in numbers)
            {
                int round = (int)number;
                float rest = number - round;
                if (rest==0)
                {
                    zeroFloats.Add(number);
                }
                else
                {
                    nonZeroFloats.Add(number);
                }
            }

            Console.WriteLine("[{0}] -> min:{1}, max:{2}, sum:{3}, avg:{4:F2}",string.Join(", ",nonZeroFloats),nonZeroFloats.Min(),nonZeroFloats.Max(),nonZeroFloats.Sum(),nonZeroFloats.Average());
            Console.WriteLine("[{0}] -> min:{1}, max:{2}, sum:{3}, avg:{4:F2}", string.Join(", ", zeroFloats),zeroFloats.Min(),zeroFloats.Max(),zeroFloats.Sum(),zeroFloats.Average());
        }
    }
}
