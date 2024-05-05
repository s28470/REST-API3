using RestApi3.Models;

namespace RestApi3.Repositories;

public interface IShopRepository
{
    Order GetOrder(int idProduct, int amount);

    Warehouse GetWarehouse(int id);
    ProductWarehouse GetProductWarehouseByOrderId(int id);

    Product GetProduct(int id);

    void UpdateOrderFullFilledAt(int id, DateTime dateTime);

    int AddProductWarehouse(ProductWarehouse productWarehouse, double productPrice);
    
}
    
    