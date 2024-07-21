using System;

public class Student
{
    private int rollNo;
    private string name;
    private string studentClass;
    private string semester;
    private string branch;
    private int[] marks = new int[5];

    public Student(int rollNo, string name, string studentClass, string semester, string branch)
    {
        this.rollNo = rollNo;
        this.name = name;
        this.studentClass = studentClass;
        this.semester = semester;
        this.branch = branch;
    }

    public void GetMarks(int[] marks)
    {
        if (marks.Length == 5)
        {
            this.marks = marks;
        }
        else
        {
            Console.WriteLine("Invalid number of marks provided. Expected 5 marks.");
        }
    }

    public void DisplayResult()
    {
        double averageMarks = CalculateAverageMarks();

        DisplayData();

        if (HasFailedInAnySubject())
        {
            Console.WriteLine("Result: Failed (Marks of at least one subject is less than 35)");
        }
        else if (averageMarks < 50)
        {
            Console.WriteLine("Result: Failed (Average marks are less than 50)");
        }
        else
        {
            Console.WriteLine("Result: Passed");
        }
    }

    private double CalculateAverageMarks()
    {
        int sum = 0;
        foreach (int mark in marks)
        {
            sum += mark;
        }
        return (double)sum / marks.Length;
    }

    private bool HasFailedInAnySubject()
    {
        foreach (int mark in marks)
        {
            if (mark < 35)
            {
                return true;
            }
        }
        return false;
    }

    public void DisplayData()
    {
        Console.WriteLine($"Roll No: {rollNo}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Class: {studentClass}");
        Console.WriteLine($"Semester: {semester}");
        Console.WriteLine($"Branch: {branch}");
        Console.WriteLine("Marks:");
        for (int i = 0; i < marks.Length; i++)
        {
            Console.WriteLine($"Subject {i + 1}: {marks[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        Student student1 = new Student(101, "Ritesh", "12th", "Second", "Science");

        int[] marks1 = { 80, 75, 60, 85, 70 };
        student1.GetMarks(marks1);

        student1.DisplayResult();
    }
}
