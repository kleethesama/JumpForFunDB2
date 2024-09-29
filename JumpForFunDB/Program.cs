using Microsoft.Data.SqlClient;

public static class DBManager
{
    public static string conn = "Server=localhost;Database=Cars;Integrated Security=True;;Encrypt=False";

    public static void FirstTimeSetup(string dbName)
    {
        using (SqlConnection myConn = new("Server=localhost;Integrated Security=True;database=master"))
        {
            string query = "";
            SqlCommand myCommand = new(query, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                Console.WriteLine($"DataBase {dbName} has been created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}