using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace MobileMarketplace
{
    public static class UserDatabase
    {
        private static readonly string ConnectionString = @"Server=KALI\SQLEXPRESS;Database=Mobilemarketplace;Trusted_Connection=True;";

        private static SqlConnection GetConnection() => new SqlConnection(ConnectionString);

        public static bool VerifyCredentials(string username, string password, out int userId)
        {
            userId = -1;

            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT UserID FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";

                using (var cmd = new SqlCommand(query, conn))
                {
                    AddParameters(cmd, username, HashPassword(password));

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result);
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CreateUser(string username, string email, string password)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    AddParameters(cmd, username, HashPassword(password));
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        // -------------------------------------------------------------
        // NEW METHOD: Retrieves FirstName for the given userId
        // -------------------------------------------------------------
        public static string GetFirstNameByUserId(int userId)
        {
            string firstName = null;
            string query = "SELECT FirstName FROM Users WHERE UserID = @UserID";

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        firstName = result.ToString();
                    }
                }
            }

            return firstName;
        }
        // -------------------------------------------------------------

        public static object ExecuteScalar(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result ?? 0; // Return 0 if NULL
                }
            }
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private static void AddParameters(SqlCommand cmd, string username, string hashedPassword)
        {
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            // same logic as your Database class
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable result = new DataTable();
                        adapter.Fill(result);
                        return result;
                    }
                }
            }
        }
    }
}

