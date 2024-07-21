using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordreverse
{
    class reverseword
    {
        static void Main(string[] args)
        {
            Console.Write("enter a word:");
            string word = Console.ReadLine();
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reversedWord = new string(charArray);
            Console.WriteLine("the reverse of the word is:" + reversedWord);
            Console.Read();
        }
    }
}