using WebApi.Models;

namespace WebApi.Interfaces;

public interface IExchangeRateService
{
    Task<ExchangeRates?> GetAllRatesAsync();
    Task<Dictionary<string, double>?> GetByCurrencyCode(string currencyCode);
    Task<double?> GetRateByCurrencyCodesAsync(string sourceCurrency, string targetCurrency);
}