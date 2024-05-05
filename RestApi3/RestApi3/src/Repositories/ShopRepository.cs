using System.Data.SqlClient;
using RestApi3.Models;

namespace RestApi3.Repositories;

public class ShopRepository : IShopRepository
{
    private string _connectionString;

    public ShopRepository()
    {
        _connectionString = "Data Source=localhost;Initial Catalog=master;User ID=sa;Password=VeryStr0ngP@ssw0rd";
    }

    public Order GetOrder(int idProduct, int amount)
    {
         using SqlConnection connection = new SqlConnection(_connectionString);
         string query = "SELECT * FROM ORDER WHERE IdProduct = @IdProd AND Amount = @AMOUNT";
         using SqlCommand command = new SqlCommand(query,connection);
         command.Parameters.AddWithValue("IdProd", idProduct);
         command.Parameters.AddWithValue("AMOUNT", amount);
         SqlDataReader sqlDataReader = command.ExecuteReader();
         int idOrder = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdOrder"));
         DateTime createdAt = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("CreatedAt")); 

         Order order = new Order
         {
            IdOrder = idOrder,
            IdProduct = idProduct,
            Amount = amount,
            CreatedAt = createdAt
         };

         return order;
    }

    public Warehouse GetWarehouse(int id)
    {
        throw new NotImplementedException();
    }

    public ProductWarehouse GetProductWarehouseByOrderId(int id)
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateOrderFullFilledAt(int id, DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public int AddProductWarehouse(ProductWarehouse productWarehouse, double productPrice)
    {
        throw new NotImplementedException();
    }
}