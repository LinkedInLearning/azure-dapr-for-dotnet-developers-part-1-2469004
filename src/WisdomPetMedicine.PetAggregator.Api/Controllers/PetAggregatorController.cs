using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace WisdomPetMedicine.PetAggregator.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PetAggregatorController : ControllerBase
{
    private readonly DaprClient daprClient;

    public PetAggregatorController(DaprClient daprClient)
    {
        this.daprClient = daprClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return null;
    }
}
