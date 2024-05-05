namespace REST3.Models;

public class Order
{
    public int IdOrder { get; init;}
    public int IdProduct { get; init;}
    public int Amount { get;init; }
    public DateTime CreatedAt { get;init; }
    public DateTime FullFilledAt { get; init; }

    public Order()
    {
    }

    public Order(int idProduct, int amount, DateTime createdAt, DateTime fullFilledAt)
    {
        IdProduct = idProduct;
        Amount = amount;
        CreatedAt = createdAt;
        FullFilledAt = fullFilledAt;
    }

    public Order(int idOrder, int idProduct, int amount, DateTime createdAt, DateTime fullFilledAt)
    {
        IdOrder = idOrder;
        IdProduct = idProduct;
        Amount = amount;
        CreatedAt = createdAt;
        FullFilledAt = fullFilledAt;
    }
}