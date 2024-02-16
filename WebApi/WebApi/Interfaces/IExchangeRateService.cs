using WebApi.Models;

namespace WebApi.Interfaces;

public interface IExchangeRateService
{
    Task<ExchangeRates> GetLatestRatesAsync();
}