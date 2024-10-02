using Microsoft.Data.SqlClient;

DatabaseManager testDB = new("JumpForFun");
testDB.FirstTimeSetup();

public class DatabaseManager
{
    public string DatabaseName { get; }
    public string Connection { get; }
    public bool SetupCompleted { get; set; } = false;

    public DatabaseManager(string dbName)
    {
        DatabaseName = dbName;
        Connection = $"Server=localhost;Database={DatabaseName};Integrated Security=True;Encrypt=False";
    }

    public void FirstTimeSetup()
    {
        if (!SetupCompleted)
        {
            CreateDatabase();
            SetupCompleted = true;
        }
    }

    private void CreateDatabase()
    {
        using (SqlConnection conn = new("Server=localhost;Integrated Security=True;database=master;Encrypt=False"))
        {
            try
            {
                conn.Open();
                string query = $"CREATE DATABASE {DatabaseName} ON PRIMARY " +
                               $"(NAME = {DatabaseName}_Data, " +
                               $"FILENAME = 'C:\\{DatabaseName}Data.mdf', " +
                               "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                               $"LOG ON (NAME = {DatabaseName}_Log, " +
                               $"FILENAME = 'C:\\{DatabaseName}Log.ldf', " +
                               "SIZE = 1MB, " +
                               "MAXSIZE = 5MB, " +
                               "FILEGROWTH = 10%)";
                SqlCommand command = new(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"DataBase {DatabaseName} has been created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}