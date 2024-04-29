using RestApi3.Models;

namespace RestApi3.Repositories;

public interface IShopRepository
{
    bool IsProductPresent(int productIdProduct);

    Order GetOrder(int id);

    Warehouse GetWarehouse(int id);

    ProductWarehouse GetProductWarehouse(int id);

    void UpdateOrderFullFilledAt(int id, DateTime dateTime);

    void AddProductWarehouse(ProductWarehouse productWarehouse, int productPrice);
    
}
    
    