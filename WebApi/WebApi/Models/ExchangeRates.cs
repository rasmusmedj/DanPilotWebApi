using System.Text.Json.Serialization;

namespace WebApi.Models;

public class ExchangeRates
{
    [JsonPropertyName("table")]
    public string Table { get; set; }

    [JsonPropertyName("rates")]
    public Dictionary<string, double> Rates { get; set; }

    [JsonPropertyName("lastupdate")]
    public DateTime LastUpdate { get; set; }
}