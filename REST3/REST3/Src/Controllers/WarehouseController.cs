using Microsoft.AspNetCore.Mvc;
using REST3.Models;
using REST3.Services;

namespace REST3.Controllers;
[ApiController]
[Route("api/shop")]
public class WarehouseController : ControllerBase
{
    private IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }
    

    [HttpPost]
    public async Task<IResult> SendInfo(ProductWarehouse productWarehouse, [FromRoute] bool procedure = false)
    {
        int result;
        result = procedure ?  await _warehouseService.AddProductWarehouseProcedureAsync(productWarehouse) : await _warehouseService.AddProductWarehouseAsync(productWarehouse);
        return result == -1 ? Results.BadRequest() : Results.Ok(result);
    }

    
}