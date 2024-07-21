using System;
using System.Data.SqlClient;

namespace connection_sql
{
    class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;

        static void Main(string[] args)
        {
            try
            {
                InsertData();
                UpdateData();
                // SelectData();  // Uncomment if needed
                // Select_With_Parameters();  // Uncomment if needed
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            Console.Read();
        }

        private static SqlConnection GetConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-7L8L103\\SQLEXPRESS;Initial Catalog=Infinitedb;User ID=sa;Password=@Rrrp2078");
            con.Open();
            return con;
        }

        public static void SelectData()
        {
            con = GetConnection();
            cmd = new SqlCommand("SELECT * FROM EMP", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]} | {dr[1]} | {dr[2]}");
            }
            dr.Close();
            con.Close();
        }

        public static void Select_With_Parameters()
        {
            con = GetConnection();
            Console.WriteLine("Enter department number to select employees:");
            int deptid = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("SELECT * FROM EMP WHERE deptno = @did", con);
            cmd.Parameters.AddWithValue("@did", deptid);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]} | {dr[1]} | {dr[2]}");
            }
            dr.Close();
            con.Close();
        }

        public static void InsertData()
        {
            con = GetConnection();
            Console.WriteLine("Enter EMPNO:");
            int EMPNO = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter ENAME:");
            string ENAME = Console.ReadLine();
            Console.WriteLine("Enter JOB:");
            string JOB = Console.ReadLine();

            cmd = new SqlCommand("INSERT INTO EMP (EMPNO, ENAME, JOB) VALUES (@EMPNO, @ENAME, @JOB)", con);
            cmd.Parameters.AddWithValue("@EMPNO", EMPNO);
            cmd.Parameters.AddWithValue("@ENAME", ENAME);
            cmd.Parameters.AddWithValue("@JOB", JOB);

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
                Console.WriteLine("Insertion success");
            else
                Console.WriteLine("Could not insert data");

            DisplayEmployeeData();
            con.Close();
        }

        public static void UpdateData()
        {
            con = GetConnection();
            Console.WriteLine("Enter EMPNO of the record you want to update:");
            int EMPNO = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new ENAME:");
            string ENAME = Console.ReadLine();
            Console.WriteLine("Enter new JOB:");
            string JOB = Console.ReadLine();

            cmd = new SqlCommand("UPDATE EMP SET ENAME = @ENAME, JOB = @JOB WHERE EMPNO = @EMPNO", con);
            cmd.Parameters.AddWithValue("@EMPNO", EMPNO);
            cmd.Parameters.AddWithValue("@ENAME", ENAME);
            cmd.Parameters.AddWithValue("@JOB", JOB);

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
                Console.WriteLine("Update success");
            else
                Console.WriteLine("Could not update data");

            con.Close();
        }

        public static void DisplayEmployeeData()
        {
            con = GetConnection();
            cmd = new SqlCommand("SELECT EMPNO, ENAME, JOB FROM EMP", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"EMPNO: {dr[0]}, ENAME: {dr[1]}, JOB: {dr[2]}");
            }
            dr.Close();
            con.Close();
        }
    }
}
