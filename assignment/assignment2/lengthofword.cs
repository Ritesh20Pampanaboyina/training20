using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordlength
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word:");
            string word = Console.ReadLine();
            Console.WriteLine("The length of the word is:" + word.Length);
            Console.Read();
            Console.WriteLine("------------");
        }

    }
}