using System;

class Program
{
    static void Main()
    {
        int[] marks = new int[10];

        Console.WriteLine("Enter ten marks:");
        for (int i = 0; i < marks.Length; i++)
        {
            Console.Write($"Enter mark {i + 1}: ");
            marks[i] = int.Parse(Console.ReadLine());
        }

        int total = 0;
        for (int i = 0; i < marks.Length; i++)
        {
            total += marks[i];
        }
        double average = (double)total / marks.Length;

        int minMark = marks[0];
        int maxMark = marks[0];
        for (int i = 1; i < marks.Length; i++)
        {
            if (marks[i] < minMark)
                minMark = marks[i];
            if (marks[i] > maxMark)
                maxMark = marks[i];
        }

        Array.Sort(marks);

        Console.WriteLine("\nResults:");
        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Average: {average:F2}");
        Console.WriteLine($"Minimum marks: {minMark}");
        Console.WriteLine($"Maximum marks: {maxMark}");
        Console.WriteLine("Marks in ascending order:");
        for (int i = 0; i < marks.Length; i++)
        {
            Console.Write($"{marks[i]} ");
        }
        Console.WriteLine("\nMarks in descending order:");
        for (int i = marks.Length - 1; i >= 0; i--)
        {
            Console.Write($"{marks[i]} ");
        }
        Console.WriteLine();
    }
}

