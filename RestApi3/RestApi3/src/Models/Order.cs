namespace RestApi3.Models;

public class Order
{
    public int IdOrder { get; init; }
    public int IdProduct { get; init; }
    public int Amount { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime FullFieldAt { get; init; }

    public Order(int idOrder, int idProduct, int amount, DateTime createdAt, DateTime fullFieldAt)
    {
        IdOrder = idOrder;
        IdProduct = idProduct;
        Amount = amount;
        CreatedAt = createdAt;
        FullFieldAt = fullFieldAt;
    }

    public Order()
    {   
        throw new NotImplementedException();
    }
}