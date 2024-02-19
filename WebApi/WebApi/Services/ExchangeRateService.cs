using System.Text.Json;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly HttpClient _httpClient;
    private readonly string? _apiUrl;

    public ExchangeRateService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _apiUrl = configuration.GetValue<string>("ExchangeRatesApi:Url");
    }

    public async Task<ExchangeRates?> GetAllRatesAsync()
    {
        var response = await _httpClient.GetAsync(_apiUrl);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        var exchangeRates = JsonSerializer.Deserialize<ExchangeRates>(jsonString);

        return exchangeRates;
    }

    public async Task<Dictionary<string, double>?> GetByCurrencyCode(string currencyCode)
    {
        var exchangeRates = await GetAllRatesAsync();
        if (exchangeRates != null && exchangeRates.Rates.TryGetValue(currencyCode, out var rate))
        {
            return new Dictionary<string, double> {{currencyCode, rate}};
        }

        return null;
    }
    
    public async Task<double?> GetRateByCurrencyCodesAsync(string sourceCurrency, string targetCurrency)
    {
        var rates = await GetAllRatesAsync();
        if (rates == null || !rates.Rates.TryGetValue(sourceCurrency, out var v1) || !rates.Rates.TryGetValue(targetCurrency, out var v2))
        {
            return null;
        }

        var rate = v2 / v1;
        
        return rate;
    }
}