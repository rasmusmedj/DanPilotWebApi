namespace WebApi.Models;

public class ExchangeRates
{
    public string table { get; set; }
    public Rates Rates { get; set; }
    public DateTime Lastupdate { get; set; }
}