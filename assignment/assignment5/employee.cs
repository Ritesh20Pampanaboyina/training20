using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    public class Employee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public float Salary { get; set; }

        public Employee(int empid, string empname, float salary)
        {
            Empid = empid;
            Empname = empname;
            Salary = salary;
        }
    }

    public class ParttimeEmployee : Employee
    {
        public float Wages { get; set; }

        public ParttimeEmployee(int empid, string empname, float salary, float wages)
            : base(empid, empname, salary)
        {
            Wages = wages;
        }
    }

    class employee
    {
        static void Main(string[] args)
        {
            ParttimeEmployee partTimeEmp = new ParttimeEmployee(1, "ritesh", 25000, 250);
            Console.WriteLine("Emp ID: " + partTimeEmp.Empid + ", Name: " + partTimeEmp.Empname + ", Salary: " + partTimeEmp.Salary + ", Wages: " + partTimeEmp.Wages);
            Console.Read();
        }
    }
}