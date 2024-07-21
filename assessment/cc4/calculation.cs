using System;

delegate int CalculatorOperation(int a, int b);

class Program
{
    static void Main()
    {
        Console.Write("Enter the first integer: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second integer: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        CalculatorOperation addDelegate = (a, b) => a + b;
        CalculatorOperation subtractDelegate = (a, b) => a - b;
        CalculatorOperation multiplyDelegate = (a, b) => a * b;

        int resultAddition = PerformOperation(addDelegate, num1, num2);
        Console.WriteLine($"Result of addition: {resultAddition}");

        int resultSubtraction = PerformOperation(subtractDelegate, num1, num2);
        Console.WriteLine($"Result of subtraction: {resultSubtraction}");

        int resultMultiplication = PerformOperation(multiplyDelegate, num1, num2);
        Console.WriteLine($"Result of multiplication: {resultMultiplication}");

        Console.ReadLine();
    }

    static int PerformOperation(CalculatorOperation operation, int a, int b)
    {
        return operation(a, b);
    }
}
