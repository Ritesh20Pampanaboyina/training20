using System;
using System.Data;
using System.Data.SqlClient;

namespace connection_sql
{
    class Class1
    {
        public static SqlDataAdapter da;

        static void Main(string[] args)
        {
            Disconnected_approach();
            Console.Read();
        }

        public static void Disconnected_approach()
        {
            string connectionString = "data source=ICS-LT-7L8L103\\SQLEXPRESS;initial catalog=Northwind;User ID=sa;Password=@Rrrp2078";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                da = new SqlDataAdapter("select * from Region", con);
                DataSet ds = new DataSet();

                da.Fill(ds, "NorthwindRegion");
                DataTable dt = ds.Tables["NorthwindRegion"];

                // Output headers
                foreach (DataColumn dc in dt.Columns)
                {
                    Console.Write(dc.ColumnName + "\t");
                }
                Console.WriteLine();

                // Output data
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        Console.Write(dr[dc] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
