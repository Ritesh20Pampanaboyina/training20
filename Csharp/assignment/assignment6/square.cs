using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    class Square
    {
        static void Main()
        {

            Console.WriteLine("Enter numbers separated by spaces:");
            string input = Console.ReadLine();


            string[] numberStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numbers = new List<int>();
            foreach (var numString in numberStrings)
            {
                if (int.TryParse(numString, out int num))
                {
                    numbers.Add(num);
                }
            }


            List<string> results = new List<string>();
            foreach (var num in numbers)
            {
                int square = num * num;
                if (square > 20)
                {
                    results.Add($"{num} - {square}");
                }
            }


            Console.WriteLine("Output:");
            foreach (var result in results)
            {
                Console.WriteLine($"→ {result}");
                Console.Read();


            }
        }

    }
}
