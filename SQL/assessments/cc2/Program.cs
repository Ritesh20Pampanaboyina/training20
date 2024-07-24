using System;
using System.Data;
using System.Data.SqlClient;

namespace Connected_Eg1
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        static void Main(string[] args)
        {
            InsertData();
            SelectData();

            Console.ReadLine();
        }

        private static SqlConnection GetConnection()
        {
            con = new SqlConnection("data source = ICS-LT-7L8L103\\SQLEXPRESS; initial catalog = Employeemanagement;" +
                "User ID = sa; Password = @Rrrp2078");
            con.Open();
            return con;
        }

        public static void SelectData()
        {
            con = GetConnection();
            cmd = new SqlCommand("SELECT empno, empname, empsal, emptype FROM Employee_Details", con);
            dr = cmd.ExecuteReader();

            Console.WriteLine("Empno | Empname | Empsal | Emptype");
            Console.WriteLine("---------------------------------");

            while (dr.Read())
            {
                Console.WriteLine($"{dr["empno"]} | {dr["empname"]} | {dr["empsal"]} | {dr["emptype"]}");
            }

            dr.Close(); 
            con.Close(); 
        }

        public static void InsertData()
        {
            con = GetConnection();

            Console.WriteLine("Enter employee details:");

            Console.Write("Empname: ");
            string empName = Console.ReadLine();

            Console.Write("Empsal: ");
            decimal empSal = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Emptype (F/P): ");
            char empType = Convert.ToChar(Console.ReadLine());

            cmd = new SqlCommand("INSERT INTO Employee_Details (empname, empsal, emptype) VALUES (@EmpName, @EmpSal, @EmpType)", con);
            cmd.Parameters.AddWithValue("@EmpName", empName);
            cmd.Parameters.AddWithValue("@EmpSal", empSal);
            cmd.Parameters.AddWithValue("@EmpType", empType);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Employee added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add employee.");
            }

            con.Close(); 
        }
    }
}


