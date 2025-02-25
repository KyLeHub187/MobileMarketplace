using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MobileMarketplace
{
    public class Database
    {
        private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=Mobilemarketplace;User Id=sa;Password=Password123;";

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        // Function to retrieve data as DataTable
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
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

                            // Debug: Show column names in a MessageBox
                            if (result.Columns.Count == 0)
                            {
                                MessageBox.Show("Query returned no columns! Check SQL query.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                         

                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }



        // Function to execute non-query commands (e.g., INSERT, UPDATE, DELETE)
        public void ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
