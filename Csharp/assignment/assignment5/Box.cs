using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    public class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public static Box operator +(Box b1, Box b2)
        {
            return new Box(b1.Length + b2.Length, b1.Breadth + b2.Breadth);
        }
    }

    public class Test
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(15.5, 2.5);
            Box box2 = new Box(8.5, 6.5);

            Box box3 = box1 + box2;

            Console.WriteLine("Box3 Dimensions: Length = " + box3.Length + ", Breadth = " + box3.Breadth);
            Console.ReadLine();
        }
    }
}