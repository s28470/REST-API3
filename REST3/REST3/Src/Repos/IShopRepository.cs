using REST3.Models;

namespace REST3.Repos;

public interface IShopRepository
{
    Task<Product> GetProductAsync(int id);

    Task<Warehouse> GetWarehouseAsync(int id);

    Task<Order> GetOrderAsync(int idProduct, int amount);

    Task<ProductWarehouse> GetProductWarehouseAsync(int idOrder);

    Task UpdateOrderAsync(int idOrder, DateTime fullFilledAt);

    Task<int> AddProductWarehouseAsync(ProductWarehouse productWarehouse, int idOrder, decimal price);

}