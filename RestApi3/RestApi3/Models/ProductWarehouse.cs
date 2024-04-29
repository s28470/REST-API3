namespace RestApi3.Models;

public class ProductWarehouse
{
    public int IdProduct { get; init; }
    public int IdWarehouse { get; init; }
    public int Amount { get; init; }
    public DateTime CreatedAt { get; init; }
    
    public ProductWarehouse(int idProduct, int idWarehouse, int amount, DateTime createdAt)
    {
        IdProduct = idProduct;
        IdWarehouse = idWarehouse;
        Amount = amount;
        CreatedAt = createdAt;
    }
}