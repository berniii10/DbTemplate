using System.Data;

public class Program
{
    public static void Main()
    {
        DatabaseHelper dbHelper = new DatabaseHelper("your_server", "your_database", "your_userId", "your_password");

        dbHelper.Connect();

        // Example query
        string query = "SELECT * FROM your_table";
        DataTable result = dbHelper.ExecuteQuery(query);

        // Print the results
        foreach (DataRow row in result.Rows)
        {
            foreach (var item in row.ItemArray)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        dbHelper.Disconnect();
    }
}