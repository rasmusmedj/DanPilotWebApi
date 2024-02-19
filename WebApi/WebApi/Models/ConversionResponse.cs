namespace WebApi.Models;

public class ConversionResponse(string sourceCurrency, string targetCurrency, double? rate)
{
    public string SourceCurrency { get; set; } = sourceCurrency;
    public string TargetCurrency { get; set; } = targetCurrency;
    public double? Rate { get; set; } = rate;
}