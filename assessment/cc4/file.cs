using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cc4
{
    class TextFile
    {
        public static void Main(string[] args)
        {
            string filePath = "exam.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    Console.Write("Enter text to append to the file: ");
                    string input = Console.ReadLine();
                    writer.WriteLine(input);
                    Console.WriteLine("Text appended successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.Read();
        }
    }
}