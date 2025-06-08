using Kolokwium.Data;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IPurchasesService _purchasesService;
    
    public CustomersController(IPurchasesService purchasesService)
    {
        _purchasesService = purchasesService;
    }

    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetPurchases(int id)
    {
        var purchases = _purchasesService.GetPurchases(id);
            
        return Ok(purchases);
    }
    
    // [HttpGet("{id}")] możemy getować po adres/nazwaKontrolera/1 itp..
    //Może się przydać
    // [HttpPost()]
    // [HttpPut()]
    //[HttpDelete("{id}")]
}