using System.Data.SqlClient;
using REST3.Models;

namespace REST3.Repos;

public class ShopRepository : IShopRepository
{
    private readonly string _connectionString = "Data Source=localhost;Initial Catalog=master;User ID=sa;Password=VeryStr0ngP@ssw0rd";
    
    public async Task<Product> GetProductAsync(int id)
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        string query = "select * from Product where Product.IdProduct = @id";
        await using SqlCommand command = new SqlCommand(query,connection);
        command.Parameters.AddWithValue("id", id);
        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Product
            {
                IdProduct = reader.GetInt32(0),
                Price = reader.GetDecimal(3)
            };
        }

        return null;
    }

    public async Task<Warehouse> GetWarehouseAsync(int id)
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var quary = "select * from Warehouse where IdWarehouse = @id;";
        await using SqlCommand command = new SqlCommand(quary, connection);
        command.Parameters.AddWithValue("id", id);
        var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Warehouse
            {
                IdWarehouse = reader.GetInt32(0),
                Address = reader.GetString(1),
                Name = reader.GetString(2)
            };
        }

        return null;
    }

    public async Task<Order> GetOrderAsync(int idProduct, int amount)
    {
        await using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        await sqlConnection.OpenAsync();
        string query = "select * from [Order] where IdProduct = @idProduct and Amount = @amount";
        await using SqlCommand command = new SqlCommand(query, sqlConnection);
        command.Parameters.AddWithValue("idProduct", idProduct);
        command.Parameters.AddWithValue("amount", amount);
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Order
            {
                IdOrder = reader.GetInt32(0),
                IdProduct = reader.GetInt32(1),
                Amount = reader.GetInt32(2),
                CreatedAt = reader.GetDateTime(3),
            };
        }

        return null;
    }

    public async Task<ProductWarehouse> GetProductWarehouseAsync(int idOrder)
    {
        await using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        await sqlConnection.OpenAsync();
        var query = "select * from Product_Warehouse where IdOrder = @idOrder";
        await using SqlCommand command = new SqlCommand(query, sqlConnection);
        command.Parameters.AddWithValue("idOrder", idOrder);
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new ProductWarehouse(
                idWarehouse: reader.GetInt32(1),
                idProduct: reader.GetInt32(2),
                amount: reader.GetInt32(4),
                createdAt: reader.GetDateTime(6)
            );
        }

        return null;
    }

    public async Task UpdateOrderAsync(int idOrder, DateTime fullFilledAt)
    {
        await using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        await sqlConnection.OpenAsync();
        var query = "UPDATE [Order] SET FulfilledAt = @FulfilledAt WHERE IdOrder = @IdOrder";
        await using SqlCommand command = new SqlCommand(query, sqlConnection);
        command.Parameters.AddWithValue("IdOrder", idOrder);
        command.Parameters.AddWithValue("FulfilledAt", fullFilledAt);
        await command.ExecuteNonQueryAsync();
    }   

    public async Task<int> AddProductWarehouseAsync(ProductWarehouse productWarehouse, int idOrder, decimal price)
    {
        await using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        await sqlConnection.OpenAsync();
        var query = "INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) VALUES (@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @CreatedAt);SELECT SCOPE_IDENTITY();";
        await using SqlCommand command = new SqlCommand(query, sqlConnection);
        command.Parameters.AddWithValue("IdWarehouse", productWarehouse.IdWarehouse);
        command.Parameters.AddWithValue("IdProduct", productWarehouse.IdProduct);
        command.Parameters.AddWithValue("IdOrder", idOrder);
        command.Parameters.AddWithValue("Amount", productWarehouse.Amount);
        command.Parameters.AddWithValue("Price", price);
        command.Parameters.AddWithValue("CreatedAt", productWarehouse.CreatedAt);
        return await command.ExecuteNonQueryAsync();
    }
}