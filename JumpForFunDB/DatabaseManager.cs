using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace JumpForFunDB;

internal class DatabaseManager
{
    public string DatabaseName { get; }
    public string ConnectionString { get; }

    public DatabaseManager(string dbName)
    {
        DatabaseName = dbName;
        ConnectionString = $"Server=localhost;Database={DatabaseName};Integrated Security=True;Encrypt=False";
    }

    public void CreateDataBaseAndTables()
    {
        using (SqlConnection conn = new("Server=localhost;Integrated Security=True;Encrypt=False"))
        {
            try
            {
                conn.Open();
                SqlCommand command1 = new($"CREATE DATABASE {DatabaseName}", conn);
                command1.ExecuteNonQuery();
                DirectoryInfo directoryInfo = new(Directory.GetCurrentDirectory());
                for (int i = 0; i < 4; i++)
                {
                    directoryInfo = Directory.GetParent(directoryInfo.FullName);
                }
                string scriptPath = Path.Combine(directoryInfo.FullName, "DB-Initial-Startup.sql");
                string query = File.ReadAllText(scriptPath);
                SqlCommand command2 = new(query, conn);
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static void RunSQLScript(string scriptName)
    {
        using (SqlConnection conn = new("Server=localhost;Integrated Security=True;Encrypt=False"))
        {
            try
            {
                DirectoryInfo directoryInfo = new(Directory.GetCurrentDirectory());
                for (int i = 0; i < 4; i++)
                {
                    directoryInfo = Directory.GetParent(directoryInfo.FullName);
                }
                string scriptPath = Path.Combine(directoryInfo.FullName, scriptName);
                string query = File.ReadAllText(scriptPath);
                conn.Open();
                SqlCommand command2 = new(query, conn);
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
