namespace REST3.Models;

public class Product
{
    public int IdProduct { get;init; }

    public string Name { get; init; }

    public string Description { get; init; }
    public decimal Price { get; init; }

    public Product()
    {
    }

    public Product(string name, string description, int price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public Product(int idProduct, string name, string description, int price)
    {
        IdProduct = idProduct;
        Name = name;
        Description = description;
        Price = price;
    }
}