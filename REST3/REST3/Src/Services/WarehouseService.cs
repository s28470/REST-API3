using REST3.Models;
using REST3.Repos;

namespace REST3.Services;

public class WarehouseService : IWarehouseService
{
    public async Task<int> AddProductWarehouseAsync(ProductWarehouse productWarehouse)
    {
        bool validation =  await ValidateProductWarehouseAsync(productWarehouse);
        if (!validation)
        {
            return -1;
        }

        Order order = await _shopRepository.GetOrderAsync(productWarehouse.IdProduct, productWarehouse.Amount);
        await _shopRepository.UpdateOrderAsync(order.IdOrder, DateTime.Now);
        var product =await _shopRepository.GetProductAsync(productWarehouse.IdProduct);
        decimal price = productWarehouse.Amount * product.Price;
        int index = await _shopRepository.AddProductWarehouseAsync(productWarehouse, order.IdOrder, price);
        return index;
    }

    private IShopRepository _shopRepository;

    public WarehouseService(IShopRepository shopRepository)
    {
        _shopRepository = shopRepository;
    }

    private async Task<bool> ValidateProductWarehouseAsync(ProductWarehouse productWarehouse)
    {
        bool b1 = await _shopRepository.GetProductAsync(productWarehouse.IdProduct) != null;
        bool b2 = await _shopRepository.GetWarehouseAsync(productWarehouse.IdWarehouse) != null;
        Order order = await _shopRepository.GetOrderAsync(productWarehouse.IdProduct, productWarehouse.Amount);
        bool b3 = order != null && order.CreatedAt.CompareTo(productWarehouse.CreatedAt) < 0;
        bool b4 = await _shopRepository.GetProductWarehouseAsync(productWarehouse.IdProduct) == null;
        return b1 && b2 && b3 && b4;

    }

    public async Task<int> AddProductWarehouseProcedureAsync(ProductWarehouse productWarehouse)
    {
        return -1;
    }
}