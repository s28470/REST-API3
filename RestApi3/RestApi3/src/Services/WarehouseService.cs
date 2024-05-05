using RestApi3.Models;
using RestApi3.Repositories;

namespace RestApi3.Services;

public class WarehouseService : IWarehouseService
{
    private IShopRepository _shopRepository;

    public WarehouseService(IShopRepository shopRepository)
    {
        _shopRepository = shopRepository;
    }

    public int AddProductWarehouse(ProductWarehouse productWarehouse)
    {
        bool validateProductWarehouse = ValidateProductWarehouse(productWarehouse);
        if (!validateProductWarehouse)
        {
            return -1;
        }
        UpdateOrderFullFilledAt(productWarehouse);
        productWarehouse.CreatedAt = DateTime.Now;
        return validateProductWarehouse ?  _shopRepository.AddProductWarehouse(productWarehouse, GetProductPrice(productWarehouse)) :  -1;
        
    }

    private void UpdateOrderFullFilledAt(ProductWarehouse productWarehouse)
    {
        Order order = _shopRepository.GetOrder(productWarehouse.IdProduct, productWarehouse.Amount);
        _shopRepository.UpdateOrderFullFilledAt(order.IdOrder, DateTime.Now);
    }

    private double GetProductPrice(ProductWarehouse productWarehouse)
    {
        double price = _shopRepository.GetProduct(productWarehouse.IdProduct).Price;
        return price * productWarehouse.Amount;
    }

    private bool ValidateProductWarehouse(ProductWarehouse productWarehouse)
    {
        bool productExists = _shopRepository.GetProduct(productWarehouse.IdProduct) is not null;
        bool amountIsPositive = productWarehouse.Amount > 0;
        bool warehouseExists = _shopRepository.GetWarehouse(productWarehouse.IdWarehouse) is not null;
        Order order = _shopRepository.GetOrder(productWarehouse.IdProduct, productWarehouse.Amount);
        if (order is null)
        {
            return false;
        }
        bool orderIsCorrect =  order.CreatedAt.CompareTo(productWarehouse.CreatedAt) == -1;
        bool orderWasNotServed = _shopRepository.GetProductWarehouseByOrderId(order.IdOrder) is not null;
        return productExists && amountIsPositive && warehouseExists && orderIsCorrect && orderWasNotServed;
    }


    public int AddProductWarehouseProcedure(ProductWarehouse productWarehouse)
    {
        throw new NotImplementedException();
    }
}