using RestApi3.Models;

namespace RestApi3.Services;

public interface IWarehouseService
{
    int AddProductWarehouse(ProductWarehouse productWarehouse);
    int AddProductWarehouseProcedure(ProductWarehouse productWarehouse);
}