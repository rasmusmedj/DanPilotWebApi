using System.Text.Json;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly HttpClient _httpClient;
    private const string apiUrl = "https://cdn.forexvalutaomregner.dk/api/latest.json";

    public ExchangeRateService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<ExchangeRates?> LatestRatesAsync()
    {
        var response = await _httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        var exchangeRates = JsonSerializer.Deserialize<ExchangeRates>(jsonString);

        return exchangeRates;
    }

    public async Task<Dictionary<string, double>?> SingleRateAsync(string currencyCode)
    {
        var exchangeRates = await LatestRatesAsync();
        if (exchangeRates != null && exchangeRates.Rates.ContainsKey(currencyCode))
        {
            var rate = exchangeRates.Rates[currencyCode];
            return new Dictionary<string, double> {{currencyCode, rate}};
        }

        return null;
    }
}