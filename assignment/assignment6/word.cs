using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    class Word
    {
        static void Main()
        {

            Console.WriteLine("Enter words separated by spaces:");
            string input = Console.ReadLine();


            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            List<string> results = words.Where(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase)
                                                   && word.EndsWith("m", StringComparison.OrdinalIgnoreCase))
                                       .ToList();


            if (results.Count > 0)
            {
                Console.WriteLine($"Output: \"{results[0]}\"");
            }
            else
            {
                Console.WriteLine("No words found starting with 'a' and ending with 'm'.");

            }
            Console.ReadLine();
        }
    }
}