namespace ExchangeAPI.Modules.Wallet.Entities;

public class CurrencySettings
{
    public string Name { get; }
    public string Symbol { get; }
    public decimal ExchangeRateToDollar { get; }
    public decimal ExchangeRateToEuro { get; }
}

public abstract class Currency(string name, string symbol, decimal exchangeCurrencyRate)
{
    private string _name { get; } = name;
    private decimal _exchangeCurrencyRate { get; } = exchangeCurrencyRate;
    private string _symbol { get; } = symbol;
}

public class Dollar : Currency
{
    public Dollar(CurrencySettings currencySettings) : 
        base(currencySettings.Name, currencySettings.Symbol, currencySettings.ExchangeRateToEuro) { }
}

public class Euro : Currency
{
    public Euro(CurrencySettings currencySettings) : 
        base(currencySettings.Name, currencySettings.Symbol, currencySettings.ExchangeRateToDollar) { }
}