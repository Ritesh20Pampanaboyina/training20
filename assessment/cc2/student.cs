using System;

public abstract class Student
{
    public string Name { get; set; }
    public int StudentId { get; set; }
    public double Grade { get; set; }
    public abstract bool IsPassed(double grade);
}

public class Undergraduate : Student
{
    public Undergraduate(string name, int studentId, double grade)
    {
        Name = name;
        StudentId = studentId;
        Grade = grade;
    }

    public override bool IsPassed(double grade)
    {
        return grade > 70.0;
    }
}

public class Graduate : Student
{
    public Graduate(string name, int studentId, double grade)
    {
        Name = name;
        StudentId = studentId;
        Grade = grade;
    }

    public override bool IsPassed(double grade)
    {
        return grade > 80.0; 
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter name for Undergraduate:");
        string undergradName = Console.ReadLine();

        Console.WriteLine("Enter student ID for Undergraduate:");
        int undergradId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter grade for Undergraduate:");
        double undergradGrade = Convert.ToDouble(Console.ReadLine());

        Undergraduate undergrad = new Undergraduate(undergradName, undergradId, undergradGrade);

        Console.WriteLine("Enter name for Graduate:");
        string gradName = Console.ReadLine();

        Console.WriteLine("Enter student ID for Graduate:");
        int gradId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter grade for Graduate:");
        double gradGrade = Convert.ToDouble(Console.ReadLine());

        Graduate grad = new Graduate(gradName, gradId, gradGrade);

        Console.WriteLine("Undergraduate " + undergrad.Name + " with ID " + undergrad.StudentId + " has " +
                          (undergrad.IsPassed(undergrad.Grade) ? "passed." : "not passed."));

        Console.WriteLine("Graduate " + grad.Name + " with ID " + grad.StudentId + " has " +
                          (grad.IsPassed(grad.Grade) ? "passed." : "not passed."));
    }
}
