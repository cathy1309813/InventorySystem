using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;

namespace InventorySystem.Repositories;

public class MySqlProductRepository : IProductRepository
{
    private readonly string _connectionString;
    public MySqlProductRepository(string connectionString)
    {
        _connectionString = connectionString;
        InitializeDatabase();
    }
    private void InitializeDatabase()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string createTableSql = @"
                create table if not exists products(
                    id int primary key auto increment,
                    name varchar(100) not null,
                    price decimal not null,
                    quantity int not null,
                    status int not null -- 對應enum的整數值
                );";
                using MySqlCommand cmd = new MySqlCommand(createTableSql, connection);
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"初始化MySql失敗 : {e.Message}");
            }
        }
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int id)
    {
        throw new NotImplementedException();
    }
}