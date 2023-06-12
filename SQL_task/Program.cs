using Microsoft.Data.SqlClient;
using System.Data;

namespace SQL_task;

class Program
{
    static async Task Main(string[] args)
    {
        var tables = "CREATE TABLE Products " +
                     "(\r\n  " +
                     "ProductId INT PRIMARY KEY,\r\n  " +
                     "ProductName NVARCHAR(50)\r\n" +
                     ");\r\n\r\n" +
                     "CREATE TABLE Categories " +
                     "(\r\n  " +
                     "CategoryId INT PRIMARY KEY,\r\n" +
                     "  CategoryName NVARCHAR(50)\r\n" +
                     ");\r\n\r\n" +
                     "CREATE TABLE ProductCategories " +
                     "(\r\n" +
                     "ProductId INT,\r\n  " +
                     "CategoryId INT,\r\n  " +
                     "PRIMARY KEY (ProductId, CategoryId),\r\n  " +
                     "FOREIGN KEY (ProductId) REFERENCES Products(ProductId),\r\n  " +
                     "FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)\r\n" +
                     ");";

        var script = "SELECT p.ProductName, c.CategoryName\r\n" +
                     "FROM Products p\r\n" +
                     "LEFT JOIN ProductCategories pc " +
                     "ON p.ProductId = pc.ProductId\r\n" +
                     "LEFT JOIN Categories c " +
                     "ON pc.CategoryId = c.CategoryId\r\n" +
                     "ORDER BY p.ProductName;";
        string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True";
/*        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand();
            command.CommandText = tables;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();

            Console.WriteLine("Таблицы созданы");
        }*/

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand(script, connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                string columnName1 = reader.GetName(0);
                string columnName2 = reader.GetName(1);

                Console.WriteLine($"{columnName1}\t{columnName2}");

                while (await reader.ReadAsync()) // построчно считываем данные
                {
                    object product = reader.GetValue(0);
                    object category = reader.GetValue(1);

                    Console.WriteLine($"{product}\t{category}");
                }
            }

            await reader.CloseAsync();
        }
    }
}