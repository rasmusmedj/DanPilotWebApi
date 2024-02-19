using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

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
        var rates = await _exchangeRateService.LatestRatesAsync();

        if (rates is null || rates.Rates.Count is 0)
        {
            return NoContent();
        }
        
        return Ok(rates);
    }

    [HttpGet("Single")]
    public async Task<IActionResult> GetSingleRate(string currencyCode)
    {
        var rate = await _exchangeRateService.SingleRateAsync(currencyCode);
        
        if (rate is null || rate.Count is 0)
        {
            return NotFound();
        }
        
        return Ok(rate);
    }
}