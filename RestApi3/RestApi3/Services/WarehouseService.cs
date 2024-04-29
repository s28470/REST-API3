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
        throw new NotImplementedException();
    }

    public int AddProductWarehouseProcedure(ProductWarehouse productWarehouse)
    {
        throw new NotImplementedException();
    }
}