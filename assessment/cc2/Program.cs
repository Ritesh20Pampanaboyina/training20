using System;

public class Program
{
    public static void CheckNumber(int num)
    {
        if (num < 0)
        {
            throw new ArgumentException("number is negative so cannot accpet");
        }
        else
        {
            Console.WriteLine("Number " + num + " is valid.");
        }
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter a number: ");
            int inputnum = Convert.ToInt32(Console.ReadLine());

            CheckNumber(inputnum);
            Console.WriteLine("perfect number and not negative");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Input format error: " + ex.Message);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("given input is small or large");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
        Console.ReadLine();
    }
}

