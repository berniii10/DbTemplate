using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseHelper
{
    // Database connection parameters
    private string server;
    private string database;
    private string userId;
    private string password;

    // SqlConnection object
    private SqlConnection connection;

    // Constructor to initialize the parameters
    public DatabaseHelper(string server, string database, string userId, string password)
    {
        this.server = server;
        this.database = database;
        this.userId = userId;
        this.password = password;
    }

    // Method to establish a connection to the database
    public void Connect()
    {
        if (connection == null)
        {
            string connectionString = $"Server={server};Database={database};User Id={userId};Password={password};";
            connection = new SqlConnection(connectionString);
        }

        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
            Console.WriteLine("Connection opened successfully.");
        }
    }

    // Method to disconnect from the database
    public void Disconnect()
    {
        if (connection != null && connection.State == ConnectionState.Open)
        {
            connection.Close();
            Console.WriteLine("Connection closed successfully.");
        }
    }

    // Method to execute a generic query
    public DataTable ExecuteQuery(string query)
    {
        DataTable dataTable = new DataTable();

        try
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("Connection must be open to execute queries.");
            }

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return dataTable;
    }
}
