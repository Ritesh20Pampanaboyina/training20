using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arraycopy
{
    class arraycopy
    {
        static void Main(string[] args)
        {
            int[] sourceArray = { 1, 2, 3, 4, 5 };
            int[] destinationArray = new int[sourceArray.Length];
            copyArray(sourceArray, destinationArray);
            Console.WriteLine("Elements of the destination array:" + string.Join(",", destinationArray));
            Console.Read();
        }
        static void copyArray(int[] source, int[] destination)
        {
            for (int i = 0; i < source.Length; i++)
            {
                destination[i] = source[i];
            }
        }
    }
}