using WebApi.Models;

namespace WebApi.Interfaces;

public interface IExchangeRateService
{
    Task<ExchangeRates?> LatestRatesAsync();
    Task<Dictionary<string, double>?> SingleRateAsync(string currencyCode);
}