using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;

namespace InventorySystem.Repositories;

public class MySqlProductRepository : IProductRepository //:(冒號)--代表實作
// java: implement interface
// java: extend ParentObj
{
    private readonly string _connectionString;
    //constructor
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
                Console.WriteLine("MySql初始化成功或已存在");
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"初始化MySql失敗 : {e.Message}");
            }
        }
    }

    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string selectSql = "SELECT * FROM products";
            using (MySqlCommand cmd = new MySqlCommand(selectSql, connection));
            {
                using (MySqlDataReader reader = cmd.ExecuteReader());
                {
                    while (reader.Read())
                    {
                        product.Add(new Product(reader.GetInt32("id"),
                            reader.GetString("name"),
                            reader.GetDecimal("price"),
                            reader.GetInt32("quantity"))
                        {
                            Status = (Product.ProductStatus)reader.GetInt32("status")
                        });
                    }
                }
            }
        }
        return products;
    }

    public Product GetProductById(int id)
    {
        Product products = null;
        
        return products;
    }
}