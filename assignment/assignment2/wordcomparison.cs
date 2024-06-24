using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordcomparision
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the first word:");
            string word1 = Console.ReadLine();
            Console.WriteLine("enter the second word:");
            string word2 = Console.ReadLine();

            if (word1 == word2)
            {
                Console.WriteLine("the words are same");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("the words are different");
                Console.ReadLine();
            }
        }
    }
}