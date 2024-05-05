using REST3.Models;

namespace REST3.Services;

public interface IWarehouseService
{
    Task<int> AddProductWarehouseAsync(ProductWarehouse productWarehouse);
    Task<int> AddProductWarehouseProcedureAsync(ProductWarehouse productWarehouse);  
}