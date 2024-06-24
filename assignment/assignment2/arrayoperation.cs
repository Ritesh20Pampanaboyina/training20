using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayoperations
{
    class arrayoperations
    {
        public static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };
            double average = calculateAverage(array);
            int min = FindMinimum(array);
            int max = FindMaximum(array);

            Console.WriteLine("average value of array elements:" + average);



            Console.WriteLine("Mimimum value in the array:" + min);
            Console.WriteLine("Maximum value in the array:" + max);
            Console.ReadLine();

        }
        static double calculateAverage(int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            return (double)sum / array.Length;
        }
        static int FindMinimum(int[] array)
        {
            int min = array[0];
            foreach (int num in array)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }
        static int FindMaximum(int[] array)
        {
            int max = array[0];
            foreach (int num in array)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            return max;
        }
    }
}