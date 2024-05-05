using System.Text.Json.Serialization;

namespace REST3.Models;

public class ProductWarehouse
{
    // public int IdProductWarehouse { get; set; }
    public int IdWarehouse { get;  init;}
    public int IdProduct { get;  init;}
    public int Amount { get;  init;}
    // public int IdOrder { get; set; }
    // public decimal Price { get; set; }
    public DateTime CreatedAt { get; init; }
    
    public ProductWarehouse(int idWarehouse, int idProduct, int amount, DateTime createdAt)
    {
        IdProduct = idProduct;
        IdWarehouse = idWarehouse;
        Amount = amount;
        CreatedAt = createdAt;
    }


}