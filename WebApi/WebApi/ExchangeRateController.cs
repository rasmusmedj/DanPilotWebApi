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

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var rates = await _exchangeRateService.GetAllRatesAsync();

        if (rates is null || rates.Rates.Count is 0)
        {
            return NoContent();
        }
        
        return Ok(rates);
    }

    [HttpGet("{currencyCode}")]
    public async Task<IActionResult> ByCurrencyCode([FromRoute] string currencyCode)
    {
        var rate = await _exchangeRateService.GetByCurrencyCode(currencyCode);
        
        if (rate is null || rate.Count is 0)
        {
            return NotFound($"Currency Code: \"{currencyCode}\" was not found");
        }
        
        return Ok(rate);
    }
    
    [HttpGet("convert")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConversionResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ConvertByCurrencyCodes([FromQuery] string sourceCurrency, [FromQuery] string targetCurrency)
    {
        var rate = await _exchangeRateService.GetRateByCurrencyCodesAsync( sourceCurrency, targetCurrency);
    
        if (!rate.HasValue)
        {
            return NotFound("One of the specified currencies is not available.");
        }

        return Ok(new ConversionResponse(sourceCurrency, targetCurrency, rate));
    }
}