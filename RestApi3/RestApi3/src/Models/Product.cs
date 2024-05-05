namespace RestApi3.Models;

public class Product
{
    public int IdProduct { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public double Price { get; init; }

    public Product(int idProduct, string name, string description, int price)
    {
        IdProduct = idProduct;
        Name = name;
        Description = description;
        Price = price;
    }
}