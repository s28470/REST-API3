namespace RestApi3.Models;

public class Warehouse
{
    public int IdWarehouse { get; init; }
    public string Name { get; init; }
    public string Address { get; init; }

    public Warehouse(int idWarehouse, string name, string address)
    {
        IdWarehouse = idWarehouse;
        Name = name;
        Address = address;
    }
}