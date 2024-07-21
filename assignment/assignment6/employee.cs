using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmpId { get; set; }
    public string EmpName { get; set; }
    public string EmpCity { get; set; }
    public double EmpSalary { get; set; }
}

public class Program
{
    public static void Main()
    {

        List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 1, EmpName = "Bindu", EmpCity = "canada", EmpSalary = 50000 },
            new Employee { EmpId = 2, EmpName = "Vyshnavi", EmpCity = "Bangalore", EmpSalary = 60000 },
            new Employee { EmpId = 3, EmpName = "Rohith", EmpCity = "Bangalore", EmpSalary = 80000 },
            new Employee { EmpId = 4, EmpName = "Mani", EmpCity = "USA", EmpSalary = 45000 }
        };


        Console.WriteLine("All employees:");
        Console.WriteLine("------------");
        DisplayAllEmployees(employees);


        Console.WriteLine("Employees with salary > 45000:");
        Console.WriteLine("------------");
        DisplaySalaryAbove(employees, 45000);



        Console.WriteLine("Employees from Bangalore:");
        Console.WriteLine("------------");
        DisplayEmployeesFromCity(employees, "Bangalore");



        Console.WriteLine("Employees sorted by name:");
        Console.WriteLine("------------");
        DisplayEmployeesSortedByName(employees);
    }

    public static void DisplayAllEmployees(List<Employee> employees)
    {
        foreach (var emp in employees)
        {
            Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpCity: {emp.EmpCity}, EmpSalary: {emp.EmpSalary}");
            Console.Read();
        }
    }

    public static void DisplaySalaryAbove(List<Employee> employees, double threshold)
    {
        var filteredEmployees = employees.Where(emp => emp.EmpSalary > threshold);
        foreach (var emp in filteredEmployees)
        {
            Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpCity: {emp.EmpCity}, EmpSalary: {emp.EmpSalary}");
            Console.Read();
        }
    }

    public static void DisplayEmployeesFromCity(List<Employee> employees, string city)
    {
        var filteredEmployees = employees.Where(emp => emp.EmpCity.Equals(city, StringComparison.OrdinalIgnoreCase));
        foreach (var emp in filteredEmployees)
        {
            Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpCity: {emp.EmpCity}, EmpSalary: {emp.EmpSalary}");
            Console.Read();
        }
    }

    public static void DisplayEmployeesSortedByName(List<Employee> employees)
    {
        var sortedEmployees = employees.OrderBy(emp => emp.EmpName);
        foreach (var emp in sortedEmployees)
        {
            Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpCity: {emp.EmpCity}, EmpSalary: {emp.EmpSalary}");
            Console.Read();
        }
    }

}