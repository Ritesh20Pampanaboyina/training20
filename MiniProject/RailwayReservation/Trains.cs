
using System;
using System.Data.SqlClient;

public static class Trains
{
    private static string connectionString = "data source=ICS-LT-7L8L103\\SQLEXPRESS; initial catalog=miniproject; User ID=sa; Password=@Rrrp2078";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static void ListTrains()
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Trains", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Train List:");
            while (reader.Read())
            {
                Console.WriteLine($"TrainID: {reader["TrainID"]}, TrainNo: {reader["TrainNo"]}, TrainName: {reader["TrainName"]}, From: {reader["FromStation"]}, To: {reader["ToStation"]}, Date: {reader["Date"]}, Price: {reader["Price"]}, Seats Available: {reader["NoOfSeats"]}, Status: {reader["Status"]}");
            }
        }
    }

    public static void AddTrains(string trainNo, string trainName, string fromStation, string toStation, DateTime date, decimal price, string status, int noOfSeats, string classes)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Trains (TrainNo, TrainName, FromStation, ToStation, Date, Price, Status, NoOfSeats, Classes) VALUES (@TrainNo, @TrainName, @FromStation, @ToStation, @Date, @Price, @Status, @NoOfSeats, @Classes)", conn);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@FromStation", fromStation);
                cmd.Parameters.AddWithValue("@ToStation", toStation);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@NoOfSeats", noOfSeats);
                cmd.Parameters.AddWithValue("@Classes", classes);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Train added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public static void UpdateTrains(int trainID, string trainNo, string trainName, string fromStation, string toStation, DateTime date, decimal price, string status, int noOfSeats, string classes)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Trains SET TrainNo = @TrainNo, TrainName = @TrainName, FromStation = @FromStation, ToStation = @ToStation, Date = @Date, Price = @Price, Status = @Status, NoOfSeats = @NoOfSeats, Classes = @Classes WHERE TrainID = @TrainID", conn);
                cmd.Parameters.AddWithValue("@TrainID", trainID);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@FromStation", fromStation);
                cmd.Parameters.AddWithValue("@ToStation", toStation);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@NoOfSeats", noOfSeats);
                cmd.Parameters.AddWithValue("@Classes", classes);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Train updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public static int GetAvailableSeats(int trainID)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT NoOfSeats FROM Trains WHERE TrainID = @TrainID", conn);
            cmd.Parameters.AddWithValue("@TrainID", trainID);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
    public static void ConfirmBooking(int trainID, int userID, int numberOfSeats)
    {
        using (var conn = GetConnection())
        {
            conn.Open();

            var trainDetails = GetTrainDetails(trainID);
            var userDetails = GetUserDetails(userID);
            decimal totalPrice = trainDetails.Price * numberOfSeats;

            string sql = @"INSERT INTO Booking 
                       (TrainID, UserID, NumberOfSeats, Status) 
                       VALUES 
                       (@TrainID, @UserID, @NumberOfSeats, @Status)";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TrainID", trainID);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@NumberOfSeats", numberOfSeats);
                cmd.Parameters.AddWithValue("@Status", "Confirmed");

                cmd.ExecuteNonQuery();
            }
        }
    }
    public static void UpdateSeatAvailability(int trainID, int bookedSeats)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Trains SET NoOfSeats = NoOfSeats - @BookedSeats WHERE TrainID = @TrainID", conn);
            cmd.Parameters.AddWithValue("@BookedSeats", bookedSeats);
            cmd.Parameters.AddWithValue("@TrainID", trainID);
            cmd.ExecuteNonQuery();
        }
    }

    public static void CancelBooking(int bookingID, int trainID, int numberOfSeats)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    SqlCommand updateBookingCmd = new SqlCommand("UPDATE Booking SET Status = 'Cancelled' WHERE BookingID = @BookingID", conn, transaction);
                    updateBookingCmd.Parameters.AddWithValue("@BookingID", bookingID);
                    int rowsAffected = updateBookingCmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Failed to update booking status.");
                    }

                    SqlCommand updateSeatsCmd = new SqlCommand("UPDATE Trains SET NoOfSeats = NoOfSeats + @NumberOfSeats WHERE TrainID = @TrainID", conn, transaction);
                    updateSeatsCmd.Parameters.AddWithValue("@NumberOfSeats", numberOfSeats);
                    updateSeatsCmd.Parameters.AddWithValue("@TrainID", trainID);
                    updateSeatsCmd.ExecuteNonQuery();

                    SqlCommand insertCancelledCmd = new SqlCommand("INSERT INTO CancelledBooking (BookingID, TrainID, NumberOfSeats) VALUES (@BookingID, @TrainID, @NumberOfSeats)", conn, transaction);
                    insertCancelledCmd.Parameters.AddWithValue("@BookingID", bookingID);
                    insertCancelledCmd.Parameters.AddWithValue("@TrainID", trainID);
                    insertCancelledCmd.Parameters.AddWithValue("@NumberOfSeats", numberOfSeats);
                    insertCancelledCmd.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Cancellation successful.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }

    public static void AddUser(string username, string password, string fullName, string email, string phoneNumber, string userRole)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserName, Password, FullName, Email, PhoneNumber, UserRole) VALUES (@UserName, @Password, @FullName, @Email, @PhoneNumber, @UserRole)", conn);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@UserRole", userRole);
            cmd.ExecuteNonQuery();
        }
    }

    public static int GetUserID(string username, string password)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT UserID FROM Users WHERE UserName = @UserName AND Password = @Password", conn);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }

    public static (string FullName, string Email, string PhoneNumber) GetUserDetails(int userID)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT FullName, Email, PhoneNumber FROM Users WHERE UserID = @UserID", conn);
            cmd.Parameters.AddWithValue("@UserID", userID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ((string)reader["FullName"], (string)reader["Email"], (string)reader["PhoneNumber"]);
            }
            return (null, null, null);
        }
    }

    public static (string TrainNo, string TrainName, string FromStation, string ToStation, DateTime Date, decimal Price, string Status) GetTrainDetails(int trainID)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TrainNo, TrainName, FromStation, ToStation, Date, Price, Status FROM Trains WHERE TrainID = @TrainID", conn);
            cmd.Parameters.AddWithValue("@TrainID", trainID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ((string)reader["TrainNo"], (string)reader["TrainName"], (string)reader["FromStation"], (string)reader["ToStation"], (DateTime)reader["Date"], (decimal)reader["Price"], (string)reader["Status"]);
            }
            return (null, null, null, null, DateTime.MinValue, 0, null);
        }
    }

    public static (int TrainID, int NumberOfSeats, string Status) GetBookingDetails(int bookingID)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TrainID, NumberOfSeats, Status FROM Booking WHERE BookingID = @BookingID", conn);
            cmd.Parameters.AddWithValue("@BookingID", bookingID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ((int)reader["TrainID"], (int)reader["NumberOfSeats"], (string)reader["Status"]);
            }
            return (0, 0, null);
        }
    }

    public static int GetLatestBookingID(int userID, int trainID)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(BookingID) FROM Booking WHERE UserID = @UserID AND TrainID = @TrainID", conn);
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@TrainID", trainID);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}
