using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };


            // 1.
            Console.WriteLine("----------------1---------------------:");
            var employeesJoinedBefore2015 = empList.Where(emp => emp.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("Employees who joined before 1/1/2015:");
            DisplayEmployees(employeesJoinedBefore2015);


            // 2. 
            Console.WriteLine("----------------2--------------------:");
            var employeesBornAfter1990 = empList.Where(emp => emp.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("\nEmployees whose date of birth is after 1/1/1990:");
            DisplayEmployees(employeesBornAfter1990);

            // 3. 
            Console.WriteLine("----------------3---------------------:");
            var consultantOrAssociateEmployees = empList.Where(emp => emp.Title == "Consultant" || emp.Title == "Associate");
            Console.WriteLine("\nEmployees whose designation is Consultant or Associate:");
            DisplayEmployees(consultantOrAssociateEmployees);

            // 4.
            Console.WriteLine("----------------4----------------------:");
            int totalEmployees = empList.Count;
            Console.WriteLine($"\nTotal number of employees: {totalEmployees}");

            // 5.
            Console.WriteLine("----------------5--------------------:");
            int employeesInChennai = empList.Count(emp => emp.City == "Chennai");
            Console.WriteLine($"Total number of employees in Chennai: {employeesInChennai}");

            // 6.
            Console.WriteLine("------------------6--------------------:");
            int highestEmployeeID = empList.Max(emp => emp.EmployeeID);
            Console.WriteLine($"Highest Employee ID: {highestEmployeeID}");

            // 7. 
            Console.WriteLine("-----------------7--------------------:");
            int employeesJoinedAfter2015 = empList.Count(emp => emp.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"Total number of employees joined after 1/1/2015: {employeesJoinedAfter2015}");

            // 8. 
            Console.WriteLine("------------------8-------------------:");
            int employeesNotAssociate = empList.Count(emp => emp.Title != "Associate");
            Console.WriteLine($"Total number of employees not designated as 'Associate': {employeesNotAssociate}");

            // 9. 
            Console.WriteLine("-----------------9--------------------:");
            var employeesByCity = empList.GroupBy(emp => emp.City)
                                         .Select(g => new { City = g.Key, Count = g.Count() });
            Console.WriteLine("\nTotal number of employees based on City:");
            foreach (var group in employeesByCity)
            {
                Console.WriteLine($"{group.City}: {group.Count}");
            }

            // 10. 
            Console.WriteLine("-----------------10--------------------:");
            var employeesByCityAndTitle = empList.GroupBy(emp => new { emp.City, emp.Title })
                                                 .Select(g => new { City = g.Key.City, Title = g.Key.Title, Count = g.Count() });
            Console.WriteLine("\nTotal number of employees based on City and Title:");
            foreach (var group in employeesByCityAndTitle)
            {
                Console.WriteLine($"{group.City} - {group.Title}: {group.Count}");
            }

            // 11. 
            Console.WriteLine("---------------11----------------------:");
            DateTime youngestDOB = empList.Min(emp => emp.DOB);
            var youngestEmployees = empList.Where(emp => emp.DOB == youngestDOB);
            Console.WriteLine($"\nTotal number of employees who are youngest in the list (DOB: {youngestDOB.ToShortDateString()}):");
            DisplayEmployees(youngestEmployees);
        }

        static void DisplayEmployees(IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmployeeID} - {emp.FirstName} {emp.LastName}, {emp.Title}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
                Console.ReadLine();
            }
        }
    }
}