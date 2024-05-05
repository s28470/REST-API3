using Microsoft.AspNetCore.Mvc;
using RestApi3.Models;
using RestApi3.Services;

namespace RestApi3.Controllers;
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
    public IResult SendInfo(ProductWarehouse productWarehouse, [FromRoute] bool procedure = false)
    {
        int result;
        result = procedure ? _warehouseService.AddProductWarehouseProcedure(productWarehouse) : _warehouseService.AddProductWarehouse(productWarehouse);
        return result == -1 ? Results.BadRequest() : Results.Ok(result);
    }
    
}