using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;

namespace WebApi;

[ApiController]
[Route("ExchangeRate")]
public class ExchangeRateController : ControllerBase
{
    private readonly IExchangeRateService _exchangeRateService;

    public ExchangeRateController(IExchangeRateService exchangeRateService)
    {
        _exchangeRateService = exchangeRateService;
    }

    [HttpGet("Latest")]
    public async Task<IActionResult> GetLatestRates()
    {
        var rates = await _exchangeRateService.GetLatestRatesAsync();
        return Ok(rates);
    }
}