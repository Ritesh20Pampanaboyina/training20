using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daynamefinder
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("enter a day number (1-7):");
            int dayNumber = int.Parse(Console.ReadLine());
            string dayName = GetDayName(dayNumber);
            Console.WriteLine("the day is:" + dayName);
            Console.Read();
        }
        static string GetDayName(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1:
                    return "monday";

                case 2:
                    return "tuesday";
                case 3:
                    return "wednesday";
                case 4:
                    return "thursday";
                case 5:
                    return "friday";
                case 6:
                    return "saturday";
                case 7:
                    return "sunday";
                default:
                    return "invalid dayNumber";

            }
        }
    }
}