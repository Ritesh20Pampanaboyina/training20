using System;

public class Box
{
    public double Length { get; set; }
    public double Breadth { get; set; }

    public Box(double length, double breadth)
    {
        Length = length;
        Breadth = breadth;
    }
    public static Box Add(Box box1, Box box2)
    {
        double combinedLength = box1.Length + box2.Length;
        double combinedBreadth = box1.Breadth + box2.Breadth;
        return new Box(combinedLength, combinedBreadth);
    }
    public void Display()
    {
        Console.WriteLine("BOX Details:");
        Console.WriteLine("##Length##: " + Length);
        Console.WriteLine("@@Breadth@@: " + Breadth);
        Console.Read();
    }
}

public class Test
{
    public static void Main(string[] args)
    {
        Box box1 = new Box(10.7, 7.3);
        Box box2 = new Box(6.5, 8.5);
        Box box3 = Box.Add(box1, box2);
        Console.WriteLine("Details of the Third BOX:");
        box3.Display();
    }
}
