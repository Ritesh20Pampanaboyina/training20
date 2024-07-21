using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumortriple
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the first integer: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the second integer: ");
            int num2 = int.Parse(Console.ReadLine());
            int result = SumOrTriple(num1, num2);
            Console.WriteLine("The result is: " + result);
            Console.ReadLine();
        }
        static int SumOrTriple(int a, int b)
        {
            if (a == b)
            {
                return 3 * (a + b);
            }
            else
            {
                return a + b;
            }
        }
    }
}