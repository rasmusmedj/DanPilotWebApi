using System.Text.Json;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly HttpClient _httpClient;
    private string apiUrl = "https://cdn.forexvalutaomregner.dk/api/latest.json";

    public ExchangeRateService()
    {
        _httpClient = new HttpClient();
    }
    
    public async Task<ExchangeRates> GetLatestRatesAsync()
    {
        var response = await _httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        var exchangeRates = JsonSerializer.Deserialize<ExchangeRates>(jsonString);
        return exchangeRates;
    }
}